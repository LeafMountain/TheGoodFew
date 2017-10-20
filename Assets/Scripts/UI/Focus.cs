using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour {

    private MouseController2 mouse;
    private ObjectInformation focusedUnit;

    private void Start () {
        mouse = GetComponent<MouseController2>();
    }

    public event EventHandler<FocusUpdate> FocusUpdated;

    protected virtual void OnFocusUpdated () {
        if (FocusUpdated != null)
            FocusUpdated(this, new FocusUpdate(focusedUnit));
    }

    //Add unit as focusedUnit and send out an update
    private void FocusObject () {
        GameObject hit = mouse.Hit();

        if (hit != null)
            focusedUnit = mouse.Hit().GetComponent<ObjectInformation>();
        else
            focusedUnit = null;

        OnFocusUpdated();
    }

    private void Update () {
        if (Input.GetMouseButtonDown(0)) {
            FocusObject();
        }
    }
}

public class FocusUpdate : EventArgs {

    public ObjectInformation unit { get; private set; }

    public FocusUpdate (ObjectInformation unit) {
        this.unit = unit;
    }
}
