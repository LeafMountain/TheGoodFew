using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

[RequireComponent (typeof (Animator))]
public class AnimateObject : MonoBehaviour {

    private Animator animator;
    private Health health;
	private GridMover controller;

    private void Awake () {
        animator = GetComponent<Animator> ();
        health = GetComponent<Health> ();
		controller = GetComponent<GridMover>();

        //Subscribe if health component exits on gameobject
        if (health != null) {
            health.Damaged.AddListener (OnDamaged);
            health.Healed.AddListener (OnHealed);
        }

        //Subscribe if GridMover component exists on gameobject
		if(controller != null){
			controller.Moving.AddListener(SetVelocity);
		}
    }

    //Triggers animation when unit takes damage
    private void OnDamaged (float amount) {
        TriggerAnimation (AnimationType.damaged);
    }

    //Triggers animation when unit gets healing
    private void OnHealed (float amount) {
        TriggerAnimation (AnimationType.healed);
    }

    //Sets the velocity property in the animation controller
    private void SetVelocity (float velocity) {
        animator.SetFloat ("velocity", velocity);
    }

    //Animation triggers. Used in abilities
    public enum AnimationType { noAnimation, attackMelee, attackRange, attackCast, attackSupport, attackThrow, damaged, healed, blocked }
    public void TriggerAnimation (AnimationType type) {
        switch (type) {
            case AnimationType.noAnimation:
                break;
            case AnimationType.attackMelee:
                animator.SetTrigger ("attackMelee");
                break;
            case AnimationType.attackRange:
                animator.SetTrigger ("attackRange");
                break;
            case AnimationType.attackCast:
                animator.SetTrigger ("attackCast");
                break;
            case AnimationType.attackSupport:
                animator.SetTrigger ("attackSupport");
                break;
            case AnimationType.attackThrow:
                animator.SetTrigger ("attackThrow");
                break;
            case AnimationType.damaged:
                animator.SetTrigger ("damaged");
                break;
            case AnimationType.healed:
                animator.SetTrigger ("healed");
                break;
            case AnimationType.blocked:
                animator.SetTrigger ("blocked");
                break;
            default:
                break;
        }

    }
}