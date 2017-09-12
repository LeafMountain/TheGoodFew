using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalStateMachine_MainMenuButtons : MonoBehaviour {

    private GlobalStateMachine globalStateMachine;

    [SerializeField]
    private Button startGame;
    [SerializeField]
    private Button loadGame;
    [SerializeField]
    private Button controls;
    [SerializeField]
    private Button credits;
    [SerializeField]
    private Button exitGame;

    private void Awake () {
        globalStateMachine = FindObjectOfType(typeof(GlobalStateMachine)) as GlobalStateMachine;
        AddButtonListeners();
    }

    //Adds listeners to buttons
    private void AddButtonListeners () {
        exitGame.onClick.AddListener(() => Application.Quit());
    }

    //For adding a listener in the inspector
    public void StartGameButton () {
        globalStateMachine.ChangeState(new GlobalStateHub(globalStateMachine));
    }
}
