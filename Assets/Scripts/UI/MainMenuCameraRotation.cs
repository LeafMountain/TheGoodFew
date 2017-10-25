using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraRotation : MonoBehaviour {


    public GameObject target;       //the target object, use an empty 
    [SerializeField]
    private float speedMod = 1f;    //a speed modifier

    void Update () {                //makes the camera rotate around "point" coords, rotating around its Y axis
        transform.RotateAround(target.transform.position, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
    }
}

