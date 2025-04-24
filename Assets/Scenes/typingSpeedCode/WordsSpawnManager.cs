using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordsSpawnManager : MonoBehaviour
{
    [SerializeField]
    TypingDatabase typingDB;
    [SerializeField]
    GameObject textPrefab;

    public static List<int> wordGoodused = new List<int>();
    public static List<int> wordBaddused = new List<int>();


    public List<RectTransform> spawnPosition = new List<RectTransform>();
    void Start()
    {
    }

    private void OnEnable()
    {
        // spawn word by random either good or bad
        StartCoroutine(generateWordy());
    }

    private void OnDisable()
    {
        // reset wordgoodused and bad used to zero again
        wordBaddused.Clear();
        wordGoodused.Clear();
    }

    private void OnDestroy()
    {
        // reset wordgoodused and bad used to zero again
        wordBaddused.Clear();
        wordGoodused.Clear();
    }

    IEnumerator generateWordy()
    {
        while (true)
        {
            // good and bad words same length we randomize to get random words when spawn
            int randomWords = Random.Range(0, 2);
            if (randomWords == 0)
            {
                int randItem = Random.Range(0, typingDB.dBWords[0].good.Length);
                if (!wordGoodused.Contains(randItem))
                {
                    int randSpawnPos = Random.Range(0, spawnPosition.Count);
                    // spawn at random position according to resolution brooo
                    Vector3 pos = new Vector3(spawnPosition[randSpawnPos].anchoredPosition.x, spawnPosition[randSpawnPos].anchoredPosition.y, 0);
                    // spawn text inside a canvas (range 1280(right most) to -1280(leftmost) for X, and for Y is 720(up) and -720(bottom))
                    GameObject text = Instantiate(textPrefab, pos, Quaternion.identity);
                    // set string label and index to gameObject.
                    text.tag = "0";
                    text.name = randItem.ToString();
                    text.transform.SetParent(this.transform, false);
                    // set text
                    TextMeshProUGUI textRef = text.gameObject.GetComponent<TextMeshProUGUI>();
                    textRef.text = typingDB.dBWords[0].good[randItem];
                    wordGoodused.Add(randItem);
                }
            }
            else if (randomWords == 1)
            {
                int randItem = Random.Range(0, typingDB.dBWords[0].bad.Length);
                if (!wordBaddused.Contains(randItem))
                {
                    int randSpawnPos = Random.Range(0, spawnPosition.Count);
                    // spawn at random position according to resolution brooo
                    Vector3 pos = new Vector3(spawnPosition[randSpawnPos].anchoredPosition.x, spawnPosition[randSpawnPos].anchoredPosition.y, 0);
                    // spawn text inside a canvas (range 1280(right most) to -1280(leftmost) for X, and for Y is 720(up) and -720(bottom))
                    GameObject text = Instantiate(textPrefab, pos, Quaternion.identity);
                    text.tag = "1";
                    text.name = randItem.ToString();
                    text.transform.SetParent(this.transform, false);
                    // set text
                    TextMeshProUGUI textRef = text.gameObject.GetComponent<TextMeshProUGUI>();

                    textRef.text = typingDB.dBWords[0].bad[randItem];
                    wordBaddused.Add(randItem);
                }
            }

            // wait so make it delay not continously crazy amount.
            yield return new WaitForSeconds(2);
        }
    }
}
