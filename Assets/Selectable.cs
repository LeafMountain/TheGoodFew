using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {
	
	public Color normalColor;
	public Color hoverColor;

	private Renderer renderer;
	private MaterialPropertyBlock _propBlock;

	void Start(){
		renderer = GetComponent<Renderer>();
		if(!renderer){
			renderer = GetComponentInChildren<Renderer>();

			if(!renderer){
				Debug.LogError("Missing outline shader");
				this.enabled = false;
			}
		}

		_propBlock = new MaterialPropertyBlock();
		renderer.GetPropertyBlock(_propBlock);		
	}

	private void ChangeOutlineColor(Color color){
		_propBlock.SetColor("_OutlineColor", color);
		renderer.SetPropertyBlock(_propBlock);		
	}

	private void OnMouseEnter(){
		ChangeOutlineColor(hoverColor);
	}

	private void OnMouseExit(){
		ChangeOutlineColor(normalColor);		
	}
}
