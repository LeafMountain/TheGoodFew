using UnityEngine;

public class BarDisplay {

    private GameObject bar;
    private int points;
    private int requiredPoints;
    private float fullWidth;


    public BarDisplay(GameObject bar, int points, int requiredPoints)
    {
        this.bar = bar;
        this.points = points;
        this.requiredPoints = requiredPoints;
        fullWidth = 
            bar.transform.parent.gameObject.
            GetComponent<RectTransform>().rect.width;
        

        ChangeBar();
    }
    private void ChangeBar()
    {
        RectTransform rectTransform =
            bar.GetComponent<RectTransform>();

        float newWidth = (fullWidth* (points / (float)requiredPoints));
        rectTransform.sizeDelta = new Vector2(newWidth, 20f);
    }
    

}
