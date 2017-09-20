using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthText : MonoBehaviour {

	[SerializeField] private Text text;
	[SerializeField] private Animator anim;
	
	public void Setup(string text, Color color, int size, Vector3 position){
		this.text.text = text;
		this.text.color = color;
		this.text.fontSize = size;
		transform.position = position;
	}

	private void OnEnable(){
		text = GetComponentInChildren<Text>();
		anim = GetComponent<Animator>();
		float destroyTime = 2;

		if(anim){
			destroyTime = anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
		}

		Destroy(gameObject, destroyTime);
	}
}
