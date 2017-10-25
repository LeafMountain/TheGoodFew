using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoButton : MonoBehaviour {

    public GameObject charFrame;

    //Enables/Disables charFrame. Add to button listener
    public void DisplayFrame () {
        charFrame.SetActive(!charFrame.activeSelf);
    }
}
