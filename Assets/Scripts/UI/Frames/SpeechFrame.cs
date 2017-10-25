using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechFrame : MonoBehaviour {
    public Text title;
    public Text text;
    
    public void SetLine (string title, string line) {

        SetText(title, line);
    }

    //Set text in ui
    private void SetText (string title, string line) {
        this.title.text = title;
        this.text.text = line;
    }
}
