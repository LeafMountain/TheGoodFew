using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioButton : MonoBehaviour {
	// public AudioClip onClickAudio;
	// [SerializeField][RangeAttribute(0, 1)] private float volume = 1;

	[SerializeField] private AudioData audioData;

	private void Start(){		
		Button button = GetComponent<Button>();

		if(button && audioData != null){
			button.onClick.AddListener(() => PlaySound(audioData));
		}
	}

	private void PlaySound(AudioData data){
		GameObject go = new GameObject("Playing: " + data.Clip.clip.name);
		AudioSource audio = go.AddComponent<AudioSource>();
		
		audio.outputAudioMixerGroup = data.Clip.mixerGroup;

		audio.PlayOneShot(data.Clip.clip, data.Clip.volume);
		Destroy(go, data.Clip.clip.length);
		
	}
}
