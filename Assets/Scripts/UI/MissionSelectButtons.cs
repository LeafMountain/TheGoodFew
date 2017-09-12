using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSelectButtons : MonoBehaviour {
    private GlobalStateMachine globalStateMachine;
    [SerializeField]
    private MissionData mission;
    [SerializeField]
    private GameObject missionInfo;

    private void Start () {
        globalStateMachine = FindObjectOfType(typeof(GlobalStateMachine)) as GlobalStateMachine;

        if (mission != null) {
            AddButtonListener();
        }

        if (missionInfo) {
            missionInfo.SetActive(false);
        }
    }

    //Adds the listener to the button
    private void AddButtonListener () {
        GetComponent<Button>().onClick.AddListener(() => globalStateMachine.ChangeState(new GlobalStateNewMission(globalStateMachine, mission.scene)));

        if (missionInfo && mission.missionName != null && mission.missionName != "") {
            missionInfo.GetComponentInChildren<Text>().text = mission.missionName;
        }
    }
}
