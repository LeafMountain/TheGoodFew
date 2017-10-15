using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {
    private static CameraControls cameraControls;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float rotationSpeed = 5;
    [SerializeField] float zoomSpeed = 2f;
    [SerializeField] float zoomMin = 2f;
    [SerializeField] float zoomMax = 100f;

    private bool moving;

    private Vector3 newPos;
    private float newRot;
    private float zoom;

    private InputController inputManager;
    private CombatEventTracker combatEventTracker;

    public static CameraControls GetInstance () {
        return cameraControls;
    }

    private void Awake () {
        cameraControls = this;
    }

    private void Start () {
        newRot = transform.rotation.eulerAngles.y;
        inputManager = InputController.GetInstance ();

        if (inputManager != null) {
            inputManager.MoveKeys += MoveInDirection;
            inputManager.ZoomKeys += Zoom;
            inputManager.CamRotateLeft += RotateLeft;
            inputManager.CamRotateRight += RotateRight;
        }

        //Subscribe to combat events
        combatEventTracker = CombatEventTracker.GetInstance();

        if(combatEventTracker != null) {
            combatEventTracker.CombatEventUpdated += OnCombatEventUpdated;
        }
    }

    //Starts forcemoving the camera to newPos
    public void Move (Vector3 newPos) {
        moving = true;
        this.newPos = newPos;
    }

    //Moves the camera if it has not reached its destination
    private void ForceMove () {
        if (Vector3.Distance (transform.position, newPos) > 0.5f) {
            transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * 6);
        } else {
            moving = false;
        }
    }

    //Rotates camera around its parent until has reach its new rotation
    private void RotateAroundAnchor () {
        if (Vector3.Distance (new Vector3 (0, transform.rotation.eulerAngles.y, 0), new Vector3 (0, newRot, 0)) > 0.5f) {
            transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, newRot, 0), Time.deltaTime * rotationSpeed);
        }
    }

    //Check player input and saves new values depending on input
    private void MoveInDirection (Vector2 input) {
        //Position 
        Vector3 newPos = (new Vector3 (transform.forward.x * input.y, 0, transform.forward.z * input.y) + (transform.right * input.x)) * moveSpeed;

        transform.Translate (newPos, Space.World);
    }

    private void RotateLeft () {
        newRot += 90;
    }

    private void RotateRight () {
        newRot -= 90;
    }

    //Zooms the camera in and out with the mouse scroll wheel
    private void Zoom (Vector2 input) {
        zoom = input.y * zoomSpeed;

        if (Camera.main.orthographicSize + -zoom > zoomMin && Camera.main.orthographicSize + -zoom < zoomMax) {
            Camera.main.orthographicSize -= zoom;
        }
    }

    void Update () {
        RotateAroundAnchor ();

        if (moving) {
            ForceMove ();
        }
    }

    private void OnDisable () {
        inputManager.MoveKeys -= MoveInDirection;
        inputManager.ZoomKeys -= Zoom;
        inputManager.CamRotateLeft -= RotateLeft;
        inputManager.CamRotateRight -= RotateRight;
    }

    public void OnCombatEventUpdated(object source, CombatEventTrackerUpdate combatEventUpdate){
        Move(combatEventUpdate.eventPosition);
    }
}