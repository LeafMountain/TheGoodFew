//Type: Controller
using UnityEngine;

public class OpenDialouge  {

    private GameObject main;
    private GameObject textBox;


    private OpenDialouge() { }
    public OpenDialouge( ShopManager shopManager)
    {
        textBox = shopManager.textBox;
        main = shopManager.main;
    }
    private void Open()
    {
        textBox.SetActive(!textBox.activeSelf);
    }

}
