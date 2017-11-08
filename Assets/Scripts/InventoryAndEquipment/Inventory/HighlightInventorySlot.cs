using UnityEngine;
using UnityEngine.UI;

public class HighlightInventorySlot {

    private InventorySlot inventorySlot;
    private bool lit;

    private Color highligtColor;
    private Color normalColor;

    public HighlightInventorySlot(
        InventorySlot inventorySlot, bool lit)
    {
        this.inventorySlot = inventorySlot;
        this.lit = lit;

        highligtColor = Color.yellow;
        normalColor = Color.white;

        Highlight();
    }

    private void Highlight()
    {
        Image imageComponent =
            inventorySlot.transform.GetChild(0).
            gameObject.GetComponent<Image>();

        if(lit)
        {
            imageComponent.color = highligtColor;
        }
        else
        {
            imageComponent.color = normalColor;
        }
    }
}
