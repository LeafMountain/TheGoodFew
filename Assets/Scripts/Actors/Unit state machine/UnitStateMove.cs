using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMove : StateMachineState {

    public UnitStateMachine stateMachine { get; private set; }
    public InputManager inputManager;

    public UnitStateMove (UnitStateMachine stateMachine) {
        this.stateMachine = stateMachine;
        inputManager = InputManager.GetInstance();
    }

    public override void EnterState () {
        stateMachine.csm.battleCont.board.interaction.MarkTiles (stateMachine.unit.GetComponent<GridOccupant> ().CurrentTile, (int) stateMachine.unit.GetComponent<ObjectInformation> ().UnitData.Movement, Color.red);

        GridMover mover = stateMachine.unit.GetComponent<GridMover> ();
        mover.ReachedDestination.AddListener (OnReachedDestination);
    }

    public override void ExitState () {
        stateMachine.csm.battleCont.board.interaction.DeMarkTiles();
        stateMachine.unit.GetComponent<GridMover> ().ReachedDestination.RemoveListener (OnReachedDestination);
    }

    private void OnMoveToDestination (Vector3 mousePos) {
        Board board = BattleManager.GetInstance ().board;
        MoveToTile (board.GetTile (board.ConvertToBoardPosition (mousePos)));
    }

    private void MoveToTile (Tile destinationTile) {
        if (stateMachine.csm.battleCont.board.interaction.WithinBounds (destinationTile)) {
            //Makes the unit unable to move again
            stateMachine.moved = true;

            //Updating the new tile
            stateMachine.unit.GetComponent<GridMover> ().Move (destinationTile.WorldPosition);

            //Move the camera to the units new location
            stateMachine.FocusCamera ();
            stateMachine.csm.battleCont.board.interaction.DeMarkTiles ();
            // stateMachine.unitAI.MoveToDestination -= OnMoveToDestination;

        }
    }

    private void OnReachedDestination () {
        stateMachine.ChangeState (new UnitStateIdle (stateMachine));
    }

    private void OnBackPressed () {
        stateMachine.ChangeState (new UnitStateIdle (stateMachine));
    }

    private void OnMarkerExecute (Vector2 position) {
        MoveToTile (stateMachine.csm.battleCont.mouse.CurrentTile);
    }

    public override void Update () {
        // Vector2 movePos = stateMachine.unit.ai.MoveDestination();

        // if(movePos != Vector2.one * Mathf.Infinity){
        //     MoveToTile(stateMachine.csm.battleCont.board.GetTile(stateMachine.csm.battleCont.board.ConvertToBoardPosition(Camera.current.ViewportToWorldPoint(movePos))));
        // }

        if(Input.GetMouseButtonDown(1)){
            OnMoveToDestination(stateMachine.csm.battleCont.mouse.Position());
        }
    }
}