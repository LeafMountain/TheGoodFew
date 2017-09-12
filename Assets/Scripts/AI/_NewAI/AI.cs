using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI : ScriptableObject {

    public delegate void Position (Vector3 movePos);
    public event Position MoveToDestination;

    public virtual void EnterAI () {

    }

    public virtual void ExitAI () {

    }

    // protected void OnMoveDestination (Vector3 moveDestination) {
    //     if (MoveToDestination != null) {
    //         MoveToDestination.Invoke (moveDestination);
    //     }
    // }

}