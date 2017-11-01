//Description: Goes through the dialouge.
//Type: View
using UnityEngine;
using UnityEngine.UI;

public class DialougeData : MonoBehaviour {

    public string[] dialougeLines;
    private int dialougeIndex = 0;

    private ShopManager shopManager;

    void Start()
    {
        shopManager = GetComponent<ShopManager>();
    }

    public void ContinueDiaOrBack()
    {
        if (dialougeIndex == dialougeLines.Length - 1)
        {
            shopManager.CloseChildren();
            dialougeIndex = 0;
        }
        else
        {
            dialougeIndex++;
            NextDialougeLine();

        }
    }
    private void NextDialougeLine()
    {
        shopManager.textBox.GetComponentInChildren<Text>().text = 
            dialougeLines[dialougeIndex];
    }

}
