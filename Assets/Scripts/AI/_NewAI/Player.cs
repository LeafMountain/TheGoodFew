using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute (menuName = "AI/Player")]
public class Player : AI {

    public override void EnterAI () {
        // InputManager.GetInstance ().MarkerExecute += OnMarkerExecute;
    }

    public override void ExitAI () {
        // InputManager.GetInstance ().MarkerExecute -= OnMarkerExecute;
    }

    private void OnMarkerExecute (Vector3 markerPos) {
        // OnMoveDestination (markerPos);
    }
}