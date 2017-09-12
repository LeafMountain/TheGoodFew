using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalStateMachine_PauseButtons : MonoBehaviour {

    private GlobalStateMachine globalStateMachine;

    [SerializeField]
    private Button resume;
    [SerializeField]
    private Button loadGame;
    [SerializeField]
    private Button controls;
    [SerializeField]
    private Button mainMenu;
    [SerializeField]
    private Button exitGame;

    private void Start () {
        globalStateMachine = GetComponentInParent<GlobalStateMachine>();
        AddButtonListeners();
    }

    //Add listeners to buttons
    private void AddButtonListeners () {
        resume.onClick.AddListener(() => globalStateMachine.ChangeState(new GlobalStatePlaying(globalStateMachine)));

        mainMenu.onClick.AddListener(() => globalStateMachine.ChangeState(new GlobalStateMainMenu(globalStateMachine)));
        exitGame.onClick.AddListener(() => Application.Quit());
    }
}
