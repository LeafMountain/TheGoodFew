using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSelect : MonoBehaviour {
    public GameObject missionSelectMenu;

    private void Start () {
        missionSelectMenu.SetActive(false);
    }

    //If gameobject is clicked and Mission Select Menu is not visible, open Mission Select Menu
    private void OnMouseDown () {
        if (!missionSelectMenu.activeSelf) {
            missionSelectMenu.SetActive(!missionSelectMenu.activeSelf);
        }
    }
}
