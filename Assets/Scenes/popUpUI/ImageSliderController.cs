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

    public GameObject previousButton;
    public GameObject nextButton;
    public Sprite previousUnavaiable;
    public Sprite previousAvaiable;
    public Sprite nextButtonSelesai;
    public Sprite nextButtonSelesaiHovered;

    public Sprite selanjutnya;
    public Sprite selanjutnyaHovered;

    public MonoBehaviour scriptHandlePanel;

    private int currentIndex = 0;

    void Start()
    {
        // change event button to next slide again
        nextButton.GetComponent<Button>().onClick.RemoveAllListeners();
        nextButton.GetComponent<Button>().onClick.AddListener(NextSlide);
        if (slides.Length > 0)
        {
            UpdateDisplay();
        }
    }



    public void NextSlide()
    {
        if (slides.Length == 0) return;

        if (currentIndex < slides.Length - 1)
        {
            currentIndex++;
        }
        if (currentIndex > -1)
        {
            previousButton.GetComponent<Image>().sprite = previousAvaiable;
            previousButton.GetComponent<Button>().interactable = true;
        }
        if (currentIndex == slides.Length - 1)
        {
            nextButton.GetComponent<Image>().sprite = nextButtonSelesai;
            // nextButton.GetComponent<Button>().spriteState

            // Get the current spriteState
            SpriteState newSpriteState = nextButton.GetComponent<Button>().spriteState;

            // Set the new highlighted sprite
            newSpriteState.highlightedSprite = nextButtonSelesaiHovered;

            // Assign the modified spriteState back to the button
            nextButton.GetComponent<Button>().spriteState = newSpriteState;


            nextButton.GetComponent<Button>().onClick.RemoveAllListeners();

            // casting
            TutorialMinigames tm = scriptHandlePanel as TutorialMinigames;

            if (tm != null)
            {
                nextButton.GetComponent<Button>().onClick.AddListener(tm.setClose);
            }

        }
        Debug.Log(currentIndex);


        UpdateDisplay();
    }

    public void PreviousSlide()
    {
        if (slides.Length == 0) return;

        if (currentIndex == 0)
        {
            previousButton.GetComponent<Image>().sprite = previousUnavaiable;
            previousButton.GetComponent<Button>().interactable = false;
        }
        else if (currentIndex == slides.Length - 1)
        {
            nextButton.GetComponent<Image>().sprite = selanjutnya;
            // Get the current spriteState
            SpriteState newSpriteState = nextButton.GetComponent<Button>().spriteState;

            // Set the new highlighted sprite
            newSpriteState.highlightedSprite = selanjutnyaHovered;

            // Assign the modified spriteState back to the button
            nextButton.GetComponent<Button>().spriteState = newSpriteState;

            // change event button to next slide again
            nextButton.GetComponent<Button>().onClick.RemoveAllListeners();

            // casting
            // TutorialMinigames tm = scriptHandlePanel as TutorialMinigames;


            nextButton.GetComponent<Button>().onClick.AddListener(NextSlide);

            currentIndex--;
        }
        else
        {
            currentIndex--;
        }
        Debug.Log(currentIndex);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayImage.sprite = slides[currentIndex].image;
        if (currentIndex == 0)
        {
            previousButton.GetComponent<Image>().sprite = previousUnavaiable;
            previousButton.GetComponent<Button>().interactable = false;
        }
        // descriptionText.text = slides[currentIndex].description;
    }
}