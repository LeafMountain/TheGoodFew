using UnityEngine;
using UnityEngine.UI;

public class DisplayAPStats {

    private GameObject parent;

    private Text txt_AcuiringAbility;

    private int abilityPoints;
    private int ability;
   

    private DisplayAPStats() { }
    public DisplayAPStats(
        GameObject go, int abilityPoints, 
        int ability)
    {
        txt_AcuiringAbility =
         go.transform.GetChild(2).GetChild(1).gameObject.GetComponent<Text>();
       
        this.abilityPoints = abilityPoints;
        this.ability = ability;
        parent = go;
        UpdateDisplayText();
    }
    private void UpdateDisplayText()
    {
        string newAquiringText = (200 - abilityPoints).ToString() + 
            " AP to Unlock: " + ((AbilityIndex)ability);

        txt_AcuiringAbility.text = newAquiringText;

        new BarDisplay(
            parent.transform.GetChild(2).GetChild(0).gameObject, abilityPoints,
            200);
    }
    

}
