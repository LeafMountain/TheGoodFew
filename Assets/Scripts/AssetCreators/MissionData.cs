using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mission data asset creator
[CreateAssetMenuAttribute(menuName = "Mission Data")]
public class MissionData : ScriptableObject {

    public string scene;
    public string missionName;

    public Dialogue startDialogue;
    public Dialogue endDialogue;

}
