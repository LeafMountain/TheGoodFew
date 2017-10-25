using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerer : MonoBehaviour {

    //Triggers audio clip (not yet implemented)
    public void TriggerAudio (string audioLocation) {

        if (audioLocation == null) {
            return;
        }

        AudioData data = (AudioData) Resources.Load ("Audio/SFX/" + audioLocation, typeof (AudioData));        

        if (!data) {
            return;
        }

        GameObject go = new GameObject ();
        AudioSource audioSource = go.AddComponent<AudioSource> ();
        audioSource.outputAudioMixerGroup = data.Clip.mixerGroup;
        audioSource.PlayOneShot (data.Clip.clip, data.Clip.volume);

        Destroy (go, data.Clip.clip.length);
    }
}