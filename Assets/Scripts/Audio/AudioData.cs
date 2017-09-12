using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
[CreateAssetMenuAttribute (menuName = "Audio Data")]
public class AudioData : ScriptableObject {

    public ClipData[] clips;
    public ClipData Clip { get { return clips[Random.Range (0, clips.Length)]; } }
}

[System.Serializable]
public class ClipData {
	public AudioClip clip;
	[Range(0, 1)]public float volume;
	public AudioMixerGroup mixerGroup;
}