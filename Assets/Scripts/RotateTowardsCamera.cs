using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour {

    private Quaternion cameraRotation;

    private void Update () {
        //Rotate towards the camera
        cameraRotation = Quaternion.LookRotation (Camera.main.transform.forward);

        if (transform.rotation != cameraRotation) {
            transform.rotation = cameraRotation;
        }
    }
}