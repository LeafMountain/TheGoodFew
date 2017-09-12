using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//From https://www.youtube.com/watch?v=0HwZQt94uHQ&t
public class ScreenFader : MonoBehaviour {

    [SerializeField]
    private Texture2D fadeOutTexture;
    float alpha = 1;
    int fadeDirection;
    float fadeSpeed = 0.8f;

    private void Start () {
        FadeSceen(-1);
    }

    //Fade screen in direction
    public float FadeSceen (int direction) {
        fadeDirection = direction;
        return fadeSpeed;
    }

    //Updates fade alpha
    private void OnGUI () {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = -1000;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    //Fades when a level is loaded
    private void OnLevelWasLoaded () {
        alpha = 1;
        FadeSceen(-1);
    }
}
