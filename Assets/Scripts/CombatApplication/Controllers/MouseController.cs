using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : CombatElement {

	private void Update(){
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			Physics.Raycast(ray, out hit, Mathf.Infinity);
		}
	}

	public delegate void MouseEvent(Vector2 clickPosition);

	public MouseEvent MouseClicked;

	private void OnMouseClicked(Vector2 clickPosition){
		if(MouseClicked != null){
			MouseClicked.Invoke(clickPosition);
		}

	}
	
}
