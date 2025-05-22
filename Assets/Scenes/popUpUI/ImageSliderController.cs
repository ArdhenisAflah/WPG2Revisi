using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageSliderController : MonoBehaviour
{
    [System.Serializable]
    public class Slide
    {
        public Sprite image;
        [TextArea] public string description;
    }

    public Slide[] slides;
    public Image displayImage;
    public TMP_Text descriptionText;

    private int currentIndex = 0;

    void Start()
    {
        if (slides.Length > 0)
        {
            UpdateDisplay();
        }
    }

    public void NextSlide()
    {
        if (slides.Length == 0) return;

        currentIndex = (currentIndex + 1) % slides.Length;
        UpdateDisplay();
    }

    public void PreviousSlide()
    {
        if (slides.Length == 0) return;

        currentIndex--;
        if (currentIndex < 0) currentIndex = slides.Length - 1;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayImage.sprite = slides[currentIndex].image;
        // descriptionText.text = slides[currentIndex].description;
    }
}