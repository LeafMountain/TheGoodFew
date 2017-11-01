//Type: View
using UnityEngine;
using UnityEngine.UI;

public class DisplayExperienceStats  {

    private Text levelText;
    private Text experienceText;

    private int level;
    private int experience;

    public DisplayExperienceStats(GameObject go, int experience, int level)
    {
        Debug.Log("DisplayExperienceStats Running |" + 
            " DisplayExperienceStats Running |" + 
            " DisplayExperienceStats Running |" +
            " DisplayExperienceStats Running |");
        levelText = 
         go.transform.GetChild(1).GetChild(2).gameObject.GetComponent<Text>();
        experienceText = 
         go.transform.GetChild(1).GetChild(1).gameObject.GetComponent<Text>();
        this.level = level;
        this.experience = experience;

        UpdateDisplayText();
    }
    private void UpdateDisplayText()
    {
        string newLevelText = "Level " + level;
        string newExperienceText = experience.ToString();

        levelText.text = newLevelText;
        experienceText.text = newExperienceText;
    }
}
