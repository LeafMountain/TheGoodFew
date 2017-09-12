using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base for all abilities
public abstract class AbilityDataBase : ScriptableObject {
    public string title;
    public Sprite icon;
    // public Class.Type arcetype;
    public string description;

    public ObjectInformation user { get; private set; }

    public void SetUser (ObjectInformation user) {
        this.user = user;
    }
}
