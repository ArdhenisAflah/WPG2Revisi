using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NewsFeed
{
    public string newsText;
    public bool isTrue;
    public bool isNetral;
}

public class LikeDislikeManager : MonoBehaviour
{
    [Header("UI Elements")]
    // public TMP_Text newsTextField;  // Attach your Text or TextMeshProUGUI component here
    public Button trueButton;
    public Button falseButton;

    [Header("News Feed Data")]
    // public List<NewsFeed> newsFeeds = new List<NewsFeed>();
    public TMP_Text puzzlePieceTxt;
    private NewsFeed currentNews;

    [Header("Content Weights")]
    [Tooltip("Probability weights for Positive/Negative/Neutral (e.g., 4 = 40% chance)")]
    [SerializeField] private float positiveWeight = 4f;
    [SerializeField] private float negativeWeight = 4f;
    [SerializeField] private float neutralWeight = 2f;

    private List<Sprite> positiveContent = new List<Sprite>();
    private List<Sprite> negativeContent = new List<Sprite>();
    private List<Sprite> neutralContent = new List<Sprite>();

    // Track the current content type (useful for game logic)
    public enum ContentType { Positive, Negative, Neutral }
    public ContentType currentContentType { get; private set; }

    [Header("UI Reference")]
    [SerializeField] private Image contentDisplayImage;
    void Start()
    {
        // Add listeners to button clicks
        trueButton.onClick.AddListener(() => OnAnswerSelected(ContentType.Positive));
        falseButton.onClick.AddListener(() => OnAnswerSelected(ContentType.Negative));

        // Load all content types
        positiveContent = new List<Sprite>(Resources.LoadAll<Sprite>("Positives"));
        negativeContent = new List<Sprite>(Resources.LoadAll<Sprite>("Negatives"));
        neutralContent = new List<Sprite>(Resources.LoadAll<Sprite>("Neutral"));
        // Start the game by showing first news feed
        ShowNextNewsFeed();
    }

    void ShowNextNewsFeed()
    {
        // if (newsFeeds.Count == 0)
        // {
        //     newsTextField.text = "No more news!";
        //     trueButton.interactable = false;
        //     falseButton.interactable = false;
        //     return;
        // }

        // // Randomly pick a news feed (or you could use sequential order)
        // int index = Random.Range(0, newsFeeds.Count);
        // currentNews = newsFeeds[index];

        // // newsFeeds.RemoveAt(index);

        // newsTextField.text = currentNews.newsText;

        // Calculate total weight
        float totalWeight = positiveWeight + negativeWeight + neutralWeight;
        float randomValue = Random.Range(0, totalWeight);

        // Determine which content type to pick
        List<Sprite> selectedList;
        if (randomValue <= positiveWeight)
        {
            selectedList = positiveContent;
            currentContentType = ContentType.Positive;
        }
        else if (randomValue <= positiveWeight + negativeWeight)
        {
            selectedList = negativeContent;
            currentContentType = ContentType.Negative;
        }
        else
        {
            selectedList = neutralContent;
            currentContentType = ContentType.Neutral;
        }

        // Check if the selected list has images
        if (selectedList.Count == 0)
        {
            Debug.LogError($"No {currentContentType} content found!");
            return;
        }

        // Pick a random image from the selected list
        Sprite randomSprite = selectedList[Random.Range(0, selectedList.Count)];
        contentDisplayImage.sprite = randomSprite;
    }

    void OnAnswerSelected(ContentType answer)
    {

        // Check if the player's answer matches the news correctness
        if (currentContentType == ContentType.Neutral)
        {
            Debug.Log("Neutral");
        }
        else
        {
            if (currentContentType == ContentType.Positive && answer == ContentType.Positive)
            {
                // sanityMeter.stt.value += 10;
                // Visual feedback: e.g., highlight correct answer
                // give missing piece when answer is correct.
                if (UtilityVarLikeDislike.MissingPiece < 16)
                {
                    UtilityVarLikeDislike.MissingPiece += 1;
                    puzzlePieceTxt.text = "Piece:" + UtilityVarLikeDislike.MissingPiece + "/" + "16";
                }
                Debug.Log("Correct!");
            }
            else if (currentContentType == ContentType.Positive && answer == ContentType.Negative)
            {
                sanityMeter.stt.value -= 10;
                // Visual feedback: e.g., show error message
                Debug.Log("Wrong answer!");
            }
            else if (currentContentType == ContentType.Negative && answer == ContentType.Positive)
            {
                sanityMeter.stt.value -= 20;
                // Visual feedback: e.g., show error message
                Debug.Log("Wrong answer!");
            }
            // else if (currentContentType == ContentType.Negative && answer == ContentType.Positive)
            // {
            //     sanityMeter.stt.value -= 10;
            //     // Visual feedback: e.g., show error message
            //     Debug.Log("Wrong answer!");
            // }
            // else
            // {
            //     sanityMeter.stt.value -= 10;
            //     // Visual feedback: e.g., show error message
            //     Debug.Log("Wrong answer!");
            // }
        }

        // Proceed to next news feed
        ShowNextNewsFeed();

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (UtilityVarLikeDislike.MissingPiece == 16)
        {
            Debug.Log("Success");
            this.gameObject.SetActive(false);
            MinigameObject1.IsOpened = false;
        }
    }
}
