using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitTurnOrder : MonoBehaviour {

    public Image image;
    public Slider health;

    //Set sprite in image component
    public void SetImage (Sprite sprite) {
        if (sprite != null)
            image.sprite = sprite;
    }

}