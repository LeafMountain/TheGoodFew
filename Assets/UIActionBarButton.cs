using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionBarButton : MonoBehaviour {

	private Sprite defaultIcon;
	private Image icon;

	private void Awake(){
		icon = GetComponent<Image>();
		defaultIcon = icon.sprite;
	}

	public void SetIcon(Sprite icon){
		this.icon.sprite = icon;
	}

	public void ResetIcon(){
		icon.sprite = defaultIcon;
	}
}
