using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

    [SerializeField] private int maxHealth = 10;
    private int currentHealth;
    [SerializeField] private GameObject deathObject;

    //Events for diffrent states of the gameobject
    public UnityEvent Dead = new UnityEvent ();
    public FloatEvent Damaged = new FloatEvent ();
    public FloatEvent Healed = new FloatEvent ();
    public UnityEvent Alive = new UnityEvent ();

    public int MaxHealth { get { return maxHealth; } }
    //The current health of the gameobject. May never go above maxHealth or below zero
    public int CurrentHealth {
        get {
            return currentHealth;
        }
        set {
            if (currentHealth + value <= 0) {
                currentHealth = 0;
                OnDead ();
            } else if (currentHealth + value > maxHealth) {
                currentHealth = maxHealth;
            } else {
                currentHealth += value;
            }
        }
    }
    //Returns the percentage of the remaining health
    public float CurrentHealthPercentage { get { return (float) CurrentHealth / (float) MaxHealth; } }

    //Resistance
    private float def = 10;
    private float res = 10;
    public int Def { get { return Mathf.FloorToInt (def); } }
    public int Res { get { return Mathf.FloorToInt (res); } }

    public void Start () {
        currentHealth = maxHealth;

        //If ObjectInformation component exists on gameobject, use UnitData to setup health
        ObjectInformation info = GetComponent<ObjectInformation> ();

        if (info) {
            UnitData data = info.UnitData;
            SetupHealth (data.Health, data.Def, data.Res);
        }
    }

    //Sets the maxHealth and stats
    public void SetupHealth (int maxHealth, float def, float res) {
        this.maxHealth = maxHealth;
        this.def = def;
        this.res = res;

        currentHealth = maxHealth;
    }

    //Reduce CurrentHealth. Calculated with stats
    public void Damage (int amount, bool magicDmg) {
        int calculatedAmount;

        if (magicDmg) {
            calculatedAmount = (amount - res > 0) ? -amount + Res : 1;
        } else {
            calculatedAmount = (amount - def > 0) ? -amount + Def : 1;
        }

        CurrentHealth = calculatedAmount;

        OnDamaged (amount);
        CreateFloatingText (calculatedAmount.ToString (), Color.red, 50); 

    }

    //Increases CurrentHealth. Check if heal is positive
    public void Heal (int amount) {
        int calculatedAmount = 0;

        if (amount >= 0) {
            calculatedAmount = amount;
        } else {
            Debug.Log ("Cannot heal a negative amount.");
        }

        CurrentHealth = calculatedAmount;

        OnHealed (amount);
        CreateFloatingText (calculatedAmount.ToString (), Color.green, 50);
    }

    //Invokes an event when damaged
    private void OnDamaged (int amount) {
        if (Damaged != null) {
            Damaged.Invoke (amount);
        }
    }

    //Invokes an event when healed
    private void OnHealed (int amount) {
        if (Healed != null) {
            Healed.Invoke (amount);
        }
    }

    //Invokes an event when dead and instantiates a deathObject if one exists
    private void OnDead () {
        Dead.Invoke ();

        if (deathObject) {
            Instantiate (deathObject, transform.position, transform.rotation);
        }

        gameObject.SetActive (false);
    }

    private void CreateFloatingText (string text, Color color, int size) {
        GameObject go = Instantiate (Resources.Load ("GameObjects/FloatingText")) as GameObject;
        FloatingHealthText floatingText = go.GetComponent<FloatingHealthText> ();
        float textHeightPos = 2f;
        floatingText.Setup (text, color, size, transform.position + new Vector3 (0, textHeightPos, 0));

    }
}