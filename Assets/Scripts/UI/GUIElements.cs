using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//For easy GUI creation

public class Announcement {

    public float lifetime { get; private set; }

    public Announcement (string text) {
        lifetime = 2f;
        GameObject frame = GameObject.Instantiate(Resources.Load("GameObjects/AnnouncementFrame") as GameObject, Vector3.zero, Quaternion.identity);
        frame.GetComponentInChildren<Text>().text = text;
        GameObject.Destroy(frame, 2f);
    }
}

public class SpeechBubble {

    public GameObject gameObject { get; private set; }

    public SpeechBubble (ObjectInformation unit, string text) {
        GameObject bubble = Resources.Load("GameObjects/SpeechFrame") as GameObject;
        gameObject = GameObject.Instantiate(bubble, unit.transform.position, Quaternion.identity);        
        gameObject.GetComponent<SpeechFrame>().SetLine(unit.unitName, text);
    }
}
