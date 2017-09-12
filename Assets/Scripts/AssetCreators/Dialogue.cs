using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dialogue asset creator
[System.Serializable]
[CreateAssetMenuAttribute(menuName = "Dialogue")]
public class Dialogue : ScriptableObject {
    public List<Line> lines = new List<Line>();
}

[System.Serializable]
public class Line {
    public string name = "";
    public string line = "";
}
