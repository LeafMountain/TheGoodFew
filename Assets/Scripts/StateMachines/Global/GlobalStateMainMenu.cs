using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStateMainMenu : StateMachineState {
    private GlobalStateMachine globalStateMachine;

    public GlobalStateMainMenu (GlobalStateMachine globalStateMachine) {
        this.globalStateMachine = globalStateMachine;
    }

    public override void EnterState () {
        //If the correct scene is not loaded, load it
        if (SceneManager.GetActiveScene ().name != globalStateMachine.mainMenu) {
            globalStateMachine.ChangeScene (globalStateMachine.mainMenu);
        }
    }

    private void UnloadAllScenes () {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneAt (i))
                SceneManager.UnloadSceneAsync (i);
        }
    }
}