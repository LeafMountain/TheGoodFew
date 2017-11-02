using UnityEngine;

public class BarDisplay {

    private GameObject bar;
    private int points;
    private float percentage;
    private float fullWidth;

    public BarDisplay(GameObject bar, int points)
    {
        this.bar = bar;
        this.points = points;
        fullWidth = 
            bar.transform.parent.gameObject.
            GetComponent<RectTransform>().rect.width;
        

        ChangeBar();
    }
    private void ChangeBar()
    {
        RectTransform rectTransform =
            bar.GetComponent<RectTransform>();

        float newWidth = (fullWidth* (points / 100.0f));
        rectTransform.sizeDelta = new Vector2(newWidth, 20f);
    }
    

}
