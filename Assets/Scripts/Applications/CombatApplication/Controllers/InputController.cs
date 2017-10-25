using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    private static InputController inputManager;
    public delegate void KeyPressed ();
    public delegate void KeyContinous (Vector2 moveCords);
    public delegate void WorldPosition (Vector3 markerPosition);

    public event KeyPressed BackPressed;
    public event KeyPressed NextPressed;
    public event KeyPressed Action1Pressed;
    public event KeyPressed Action2Pressed;
    public event KeyPressed Action3Pressed;
    public event KeyPressed Action4Pressed;
    public event KeyPressed Action5Pressed;
    public event KeyPressed Action6Pressed;

    public event KeyPressed CamRotateLeft;
    public event KeyPressed CamRotateRight;
    public event KeyContinous MoveKeys;
    public event KeyContinous ZoomKeys;

    //Marker controls
    public event WorldPosition MarkerPosition;
    public event WorldPosition MarkerSelect;
    public event WorldPosition MarkerExecute;

    [Header ("Controls")]
    [SerializeField] private KeyCode backKey = KeyCode.Escape;
    [SerializeField] private KeyCode nextKey = KeyCode.Space;

    [SerializeField] private KeyCode actionKey1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode actionKey2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode actionKey3 = KeyCode.Alpha3;
    [SerializeField] private KeyCode actionKey4 = KeyCode.Alpha4;
    [SerializeField] private KeyCode actionKey5 = KeyCode.Alpha5;
    [SerializeField] private KeyCode actionKey6 = KeyCode.Alpha6;

    [Header ("Camera Controls")]
    [SerializeField] private KeyCode rotateLeft = KeyCode.Q;
    [SerializeField] private KeyCode rotateRight = KeyCode.E;
    [SerializeField] private string moveHorizontal = "Horizontal";
    [SerializeField] private string moveVertical = "Vertical";
    [SerializeField] private string zoom = "Mouse ScrollWheel";

    [Header ("Marker Controls")]
    [SerializeField] private KeyCode markerSelect = KeyCode.Mouse0;
    [SerializeField] private KeyCode markerExecute = KeyCode.Mouse1;

    private void Awake () {
        if (!inputManager) {
            inputManager = this;
        }
    }

    public static InputController GetInstance () {
        return inputManager;
    }

    private void OnBackKeyPressed () {
        if (BackPressed != null) {
            KeyPressed lastSubscriber = BackPressed.GetInvocationList ()[BackPressed.GetInvocationList ().Length - 1] as KeyPressed;

            lastSubscriber.Invoke ();
            BackPressed -= lastSubscriber;
        }
    }

    private void OnNextKeyPressed () {
        if (NextPressed != null) {
            NextPressed.Invoke ();
        }
    }

    private Vector3 MousePosition () {
        RaycastHit hit;
        Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity, 1 << 8);
        return hit.point;
    }

    private void Update () {
        if (Input.anyKeyDown) {
            //Function keys
            if (Input.GetKeyDown (backKey)) { OnBackKeyPressed (); }
            if (Input.GetKeyDown (nextKey)) { OnNextKeyPressed (); }

            //Action keys
            if (Input.GetKeyDown (actionKey1)) { if (Action1Pressed != null) { Action1Pressed.Invoke (); } }
            if (Input.GetKeyDown (actionKey2)) { if (Action2Pressed != null) { Action2Pressed.Invoke (); } }
            if (Input.GetKeyDown (actionKey3)) { if (Action3Pressed != null) { Action3Pressed.Invoke (); } }
            if (Input.GetKeyDown (actionKey4)) { if (Action4Pressed != null) { Action4Pressed.Invoke (); } }
            if (Input.GetKeyDown (actionKey5)) { if (Action5Pressed != null) { Action5Pressed.Invoke (); } }
            if (Input.GetKeyDown (actionKey6)) { if (Action6Pressed != null) { Action6Pressed.Invoke (); } }

            //Camera keys
            if (Input.GetKeyDown (rotateLeft)) { if (CamRotateLeft != null) { CamRotateLeft.Invoke (); } }
            if (Input.GetKeyDown (rotateRight)) { if (CamRotateRight != null) { CamRotateRight.Invoke (); } }

        }

        if (Input.anyKey) {
            if (Input.GetAxis (moveHorizontal) != 0 || Input.GetAxis (moveVertical) != 0) {
                if (MoveKeys != null) {
                    MoveKeys (new Vector2 (Input.GetAxis (moveHorizontal), Input.GetAxis (moveVertical)));
                }
            }
            if (Input.GetKey (markerSelect)) {
                if (MarkerSelect != null) {
                    MarkerSelect.Invoke (MousePosition ());
                }
            }
            if (Input.GetKey (markerExecute)) {
                if (MarkerExecute != null) {
                    MarkerExecute.Invoke (MousePosition ());
                }
            }

        }

        if (Input.GetAxis (zoom) != 0) {
            if (ZoomKeys != null) {
                ZoomKeys (new Vector2 (0, Input.GetAxis (zoom)));
            }
        }

        if (MarkerPosition != null) {
            MarkerPosition.Invoke (MousePosition ());
        }
    }

}