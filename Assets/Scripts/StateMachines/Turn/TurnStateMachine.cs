using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class TurnStateMachine:MonoBehaviour {
    private ITurnState currentState;

    public TurnController TurnManager { get; set; }
    public TurnOrderObject CurrentUnit { get; private set; }

    public void ChangeState(ITurnState newState) {
        if(currentState != null){
            currentState.ExitState();
        }
        currentState = newState; 
        currentState.EnterState();
    }

    private void Start() {
        ChangeState(new TurnStatePrepare(this));
        TurnController turnManager = TurnController.GetInstance();
        if(turnManager){
            turnManager.NewUnit += OnNewUnit;
        }
    }

    private void Update() {
        currentState.Update();
    }

    private void OnNewUnit(TurnOrderObject currentUnit){
        this.CurrentUnit = currentUnit;
    }
}
