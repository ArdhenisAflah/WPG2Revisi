using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class PuzzleTile : MonoBehaviour
{
    [HideInInspector] public int currentRotation;
    private Image highlight;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        highlight = transform.Find("Highlight").GetComponent<Image>();
        highlight.enabled = false;
    }

    public void SetHighlight(bool state, bool isHorizontal)
    {
        highlight.enabled = state;
        highlight.color = isHorizontal ?
            new Color(0, 0, 1, 0.5f) : // Blue for horizontal
            new Color(0, 1, 0, 0.5f);  // Green for vertical
    }

    public void RotateTile()
    {
        currentRotation = (currentRotation + 1) % 4;
        rectTransform.rotation = Quaternion.Euler(0, 0, currentRotation * 90);
    }
}