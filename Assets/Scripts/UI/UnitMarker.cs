using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMarker : TurnOrderSubscriber {

    // private Quaternion cameraRotation;

    public override void UpdateSubscriber () {
        //Go to the current unit
        gameObject.transform.SetParent(currentUnit.gameObject.transform);
        gameObject.transform.position = currentUnit.gameObject.transform.position + Vector3.up * 2.5f;
    }

    // private void Update () {
    //     //Rotate towards the camera
    //     cameraRotation = Quaternion.LookRotation(Camera.main.transform.forward);

    //     if (transform.rotation != cameraRotation) {
    //         transform.rotation = cameraRotation;
    //     }
    // }
}
