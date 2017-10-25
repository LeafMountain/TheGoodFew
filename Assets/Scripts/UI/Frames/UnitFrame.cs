using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFrame : TurnOrderSubscriber {
    public Image portrait;
    public Slider healthBar;
    public Text title;
    public Text primaryClass;
    public Text healthText;

    [HeaderAttribute ("Advanced Info")]
    [SerializeField] private Text atk;
    [SerializeField] private Text def;
    [SerializeField] private Text pow;
    [SerializeField] private Text res;
    [SerializeField] private Text hit;
    [SerializeField] private Text mHit;
    [SerializeField] private Text block;

    //Updates values when new information is available
    public override void UpdateSubscriber () {
        Health health = currentUnit.GetComponent<Health> ();

        title.text = currentUnit.unitName;
        portrait.sprite = currentUnit.UnitData.portrait;

        if (health != null) {
            healthBar.value = health.CurrentHealthPercentage;
            healthText.text = health.CurrentHealth + " / " + health.MaxHealth;
        }

        SetText (primaryClass, currentUnit.UnitData.primaryClass.ToString ());

        SetText (atk, currentUnit.UnitData.Atk.ToString ());
        SetText (pow, currentUnit.UnitData.Pow.ToString ());
        SetText (hit, currentUnit.UnitData.Hit.ToString () + "%");
        SetText (mHit, currentUnit.UnitData.MHit.ToString () + "%");

        SetText (def, currentUnit.UnitData.Def.ToString ());
        SetText (res, currentUnit.UnitData.Res.ToString ());
        SetText (block, currentUnit.UnitData.Block.ToString () + "%");
    }

    //Sets text if element is defined in the inspector
    private void SetText (Text element, string text) {
        if (element != null)
            element.text = text;
    }
}