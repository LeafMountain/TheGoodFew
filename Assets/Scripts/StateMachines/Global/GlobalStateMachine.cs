using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStateMachine : StateMachine {
    public ScreenFader screenFader { get; private set; }
    [HeaderAttribute("Scene Names")]
    public string mainMenu;
    public string villageHub;


    [SpaceAttribute]
    public GameObject pauseMenu;

    public static GlobalStateMachine globalStateMachine;

    private string scene;
    private bool changeScene;
    private float changeDelay;

    private void Awake () {
        if (globalStateMachine != null)
            DestroyImmediate(this);
        else {
            globalStateMachine = this;
            DontDestroyOnLoad(this);
        }
    }

    public static GlobalStateMachine GetInstance(){
        return globalStateMachine;
    }

    private void Start () {
        screenFader = GetComponent<ScreenFader>();
        currentState = new GlobalStateMainMenu(this);
    }

    //Load scene with a delay and fade screen
    public void ChangeScene (string scene) {
        globalStateMachine.screenFader.FadeSceen(1);
        this.scene = scene;
        changeScene = true;

        changeDelay = 0.8f;
    }

    public override void OnUpdate () {
        if (changeScene) {
            if (changeDelay > 0) {
                changeDelay -= Time.deltaTime;
            }
            else {
                SceneManager.LoadScene(scene);
                changeScene = false;
            }

        }
    }
}