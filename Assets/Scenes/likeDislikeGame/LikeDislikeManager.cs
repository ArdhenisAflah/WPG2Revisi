using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NewsFeed
{
    public string newsText;
    public bool isTrue;
}

public class LikeDislikeManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text newsTextField;  // Attach your Text or TextMeshProUGUI component here
    public Button trueButton;
    public Button falseButton;

    [Header("News Feed Data")]
    public List<NewsFeed> newsFeeds = new List<NewsFeed>();
    private NewsFeed currentNews;

    void Start()
    {
        // Add listeners to button clicks
        trueButton.onClick.AddListener(() => OnAnswerSelected(true));
        falseButton.onClick.AddListener(() => OnAnswerSelected(false));

        // Start the game by showing first news feed
        ShowNextNewsFeed();
    }

    void ShowNextNewsFeed()
    {
        if (newsFeeds.Count == 0)
        {
            newsTextField.text = "No more news!";
            trueButton.interactable = false;
            falseButton.interactable = false;
            return;
        }

        // Randomly pick a news feed (or you could use sequential order)
        int index = Random.Range(0, newsFeeds.Count);
        currentNews = newsFeeds[index];

        newsFeeds.RemoveAt(index);

        newsTextField.text = currentNews.newsText;
    }

    void OnAnswerSelected(bool answer)
    {
        // Check if the player's answer matches the news correctness
        if (answer == currentNews.isTrue)
        {
            sanityMeter.stt.value += 10;
            // Visual feedback: e.g., highlight correct answer
            Debug.Log("Correct!");
        }
        else
        {
            sanityMeter.stt.value -= 10;
            // Visual feedback: e.g., show error message
            Debug.Log("Wrong answer!");
        }
        // Proceed to next news feed
        ShowNextNewsFeed();
    }
}
