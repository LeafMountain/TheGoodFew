using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardView : CombatElement {

    private int width;
    private int height;

    private void Start(){
        SetSize();
        App.Controller.BoardController.SetupBoard(width, height);
    }

    private void SetSize(){
        Renderer renderer = GetComponent<Renderer>();
        width = (int)renderer.bounds.size.x;
        height = (int)renderer.bounds.size.z;
    }
	
}
