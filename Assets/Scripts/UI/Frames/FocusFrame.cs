using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusFrame : MonoBehaviour {

    public GameObject advancedView;
    public Image portrait;
    public Slider healthBar;
    public Text title;
    public Text primaryClass;
    public Text healthText;
    public ObjectInformation unit;

    [HeaderAttribute("Advanced Info")]
    [SerializeField]
    private Text atk;
    [SerializeField]
    private Text def;
    [SerializeField]
    private Text pow;
    [SerializeField]
    private Text res;
    [SerializeField]
    private Text hit;
    [SerializeField]
    private Text mHit;
    [SerializeField]
    private Text block;



    private void Awake () {
        gameObject.SetActive(false);
        GetComponentInParent<Focus>().FocusUpdated += OnFocusUpdated;
    }

    public void OnFocusUpdated (object source, FocusUpdate update) {
        this.unit = update.unit;

        if (unit != null) {
            SetValues(unit);
            gameObject.SetActive(true);
        }
        else
            gameObject.SetActive(false);
    }


    //Set values in UI
    public void SetValues (ObjectInformation unit) {
        Health health = unit.GetComponent<Health>();

        this.portrait.sprite = unit.UnitData.portrait;
        this.healthBar.value = health.CurrentHealthPercentage;
        this.title.text = unit.unitName;
        healthText.text = health.CurrentHealth + " / " + health.MaxHealth;

        SetText(primaryClass, unit.UnitData.primaryClass.ToString());

        SetText(atk, unit.UnitData.Atk.ToString());
        SetText(pow, unit.UnitData.Pow.ToString());
        SetText(hit, unit.UnitData.Hit.ToString() + "%");
        SetText(mHit, unit.UnitData.MHit.ToString() + "%");

        SetText(def, unit.UnitData.Def.ToString());
        SetText(res, unit.UnitData.Res.ToString());
        SetText(block, unit.UnitData.Block.ToString() + "%");
    }

    //Set value in UI if text is not null or empty
    private void SetText (Text element, string text) {
        if (element != null)
            element.text = text;
    }

    //Enable extra info
    public void EnableAdvancedView () {
        advancedView.SetActive(!advancedView.activeSelf);
    }
}
