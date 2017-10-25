using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : TurnOrderSubscriber {
    private TurnOrderObject unit;
    private Ability currentAbility;
    private List<Ability> abilities = new List<Ability> ();
    private bool abilityPrepared;
    private bool abilityUsed;
    private List<Tile> targetable = new List<Tile> ();

    private GameObject preparedEffect;

    public override void UpdateSubscriber () {
        if (abilityUsed || unit != currentUnit) {
            abilityUsed = false;

            abilities = currentUnit.Abilities;
        }

        OnAbilityManagerUpdated ();
    }

    public EventHandler<AbilityManagerUpdate> AbilityManagerUpdated;

    protected virtual void OnAbilityManagerUpdated () {
        if (AbilityManagerUpdated != null) {
            AbilityManagerUpdated (this, new AbilityManagerUpdate (currentUnit, abilities));
        }
    }

    //Prepares the ability if it is not prepared
    public void UseAbility (TurnOrderObject unit, Ability ability) {
        this.unit = unit;
        if (!abilityUsed && ability != currentAbility) {
            PrepareAbility (unit, ability);
        }
    }

    private void PrepareAbility (TurnOrderObject unit, Ability ability) {
        InputManager.GetInstance ().BackPressed += ResetAbility;
        this.unit = unit;
        this.currentAbility = ability;

        //Ability is marked as using
        ability.usingAbility = true;

        //Changes the unit state machine to the Use state (ability state)
        battleManager.combatStateMachine.UnitStateMachine.ChangeState (new UnitStateUse (battleManager.combatStateMachine.UnitStateMachine));

        //Creates a grid
        battleManager.board.interaction.MarkTiles (unit.GetComponent<GridOccupant> ().CurrentTile, ability.ability.range, Color.blue);

        //Gets the valid tiles where the ability can be used
        targetable = battleManager.board.interaction.FindUsableTiles (battleManager.board.interaction.GetTilesArea (unit.GetComponent<GridOccupant> ().CurrentTile, ability.ability.range), Tile.Status.occupied);
        targetable.Remove (unit.GetComponent<GridOccupant> ().CurrentTile);

        //Ability is now prepared
        abilityPrepared = true;

        //If ability has a start effect, create it
        if (currentAbility.ability.startEffect) {
            preparedEffect = Instantiate (currentAbility.ability.startEffect, unit.transform.position, Quaternion.identity, unit.transform);
            preparedEffect.transform.rotation = unit.transform.rotation;

            if (currentAbility.ability.startSound) {
                AudioSource audioSource = preparedEffect.AddComponent<AudioSource> ();
                audioSource.outputAudioMixerGroup = currentAbility.ability.startSound.Clip.mixerGroup;
                // audioSource.clip = currentAbility.ability.startSound;
                // audioSource.Play ();

                audioSource.PlayOneShot (currentAbility.ability.startSound.Clip.clip, currentAbility.ability.startSound.Clip.volume);
                // audioSource.loop = false;
            }
        }

        //Trigger user animation
        unit.GetComponent<AnimateObject> ().TriggerAnimation (currentAbility.ability.startAnimation);

        //battleController.combatStateMachine.UpdateUnitState();

        //Send out update to subscribers
        OnAbilityManagerUpdated ();

    }

    //If an ability is prepared, execute the ability
    public void ExecuteAbility (Health target) {
        //Trigger animation on user
        unit.GetComponent<AnimateObject> ().TriggerAnimation (currentAbility.ability.usingAnimation);

        //Change ability status and cooldown
        abilityUsed = true;
        currentAbility.StartCooldown ();

        //If a prepare effect exists, destroy it
        if (preparedEffect) {
            Destroy (preparedEffect);
        }

        //Look at target
        currentUnit.transform.LookAt (target.transform.position);

        //Create effects
        GameObject usingEffect = CreateEffect (currentAbility.ability.usingEffect, unit.transform.position, unit.transform.rotation);

        GameObject endEffect = CreateEffect (currentAbility.ability.endEffect, target.transform.position, currentAbility.ability.endEffect.transform.rotation);

        if (endEffect && currentAbility.ability.endSound) {
            AudioSource audioSource = endEffect.AddComponent<AudioSource> ();
            audioSource.outputAudioMixerGroup = currentAbility.ability.endSound.Clip.mixerGroup;

            audioSource.PlayOneShot (currentAbility.ability.endSound.Clip.clip, currentAbility.ability.endSound.Clip.volume);
        }

        //Make the target unit take damage and heal.
        AbilityDataOffensive ability = (AbilityDataOffensive) currentAbility.ability;
        UnitData data = unit.GetComponent<ObjectInformation> ().UnitData;

        if (ability.physicalDamage > 0) {
            target.Damage (ability.physicalDamage + data.Atk, false);
        }

        if (ability.magicalDamage > 0) {
            target.Damage (ability.magicalDamage + data.Pow, true);
        }

        if (ability.heal > 0) {
            target.Heal (ability.heal + data.Pow);
        }

        //Reset ability
        ResetAbility ();

        //Send out update to subscribers
        OnAbilityManagerUpdated ();
    }

    //If an effect exists, instantiate it in the world and destroy the effect after its lifetime expires
    private GameObject CreateEffect (GameObject effect, Vector3 position, Quaternion rotation) {
        if (effect != null) {
            GameObject createdEffect = Instantiate (effect, position, rotation, unit.transform);
            createdEffect.transform.rotation = unit.transform.rotation;
            Destroy (createdEffect, createdEffect.GetComponentInChildren<ParticleSystem> ().main.duration + createdEffect.GetComponentInChildren<ParticleSystem> ().main.startLifetime.constantMax);
            return createdEffect;
        }

        return null;
    }

    //Removes all the ability indicators
    public void ResetAbility () {
        InputManager.GetInstance ().BackPressed -= ResetAbility;
        //Remove the grid from the ground
        battleManager.board.interaction.DeMarkTiles ();
        //Change the state of the unit
        if (battleManager.combatStateMachine.UnitStateMachine != null) {
            battleManager.combatStateMachine.UnitStateMachine.ChangeState (new UnitStateIdle (battleManager.combatStateMachine.UnitStateMachine));
        }

        //Removes the "usingAbility" status from ability
        if (currentAbility != null) {
            currentAbility.usingAbility = false;
        }

        //If an effect is active, remove it
        if (preparedEffect) {
            ParticleSystem ps = preparedEffect.GetComponentInChildren<ParticleSystem> ();
            ps.Stop ();
            Destroy (preparedEffect, ps.main.startLifetime.constant);
        }

        //Resets everythin else
        unit = null;
        currentAbility = null;
        abilityPrepared = false;
        OnAbilityManagerUpdated ();
    }

    private void Update () {
        //If the ability is prepared and the player picks a valid tiles, execute ability
        if (Input.GetMouseButtonDown (1) && abilityPrepared && !abilityUsed && targetable.Contains (battleManager.mouse.CurrentTile)) {
            ExecuteAbility (battleManager.mouse.CurrentTile.GetOccupant ().GetComponent<Health> ());
        }
    }
}

//Class from sending ability manager updates with delegates
public class AbilityManagerUpdate : EventArgs {
    public ObjectInformation user { get; private set; }
    public List<Ability> abilities { get; private set; }

    public AbilityManagerUpdate (ObjectInformation user, List<Ability> abilities) {
        this.user = user;
        this.abilities = abilities;
    }
}