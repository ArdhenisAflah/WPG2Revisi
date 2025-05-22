using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckerWord : MonoBehaviour
{
    private string _originalText;
    private TextMeshProUGUI _tmp;
    void OnEnable()
    {
        typingInputWords.OnCheckWord += Checking;
        typingInputWords.OnHighlightWord += CheckingHighlight;
    }

    void OnDisable()
    {
        typingInputWords.OnCheckWord -= Checking;
        typingInputWords.OnHighlightWord -= CheckingHighlight;
    }

    private void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
        _originalText = _tmp.text;         // cache the un‑tagged text
    }


    void CheckingHighlight(string res)
    {
        // start from the original every time
        string txt = _originalText;

        if (!string.IsNullOrEmpty(res))
        {
            int index = txt.IndexOf(res, StringComparison.Ordinal);
            if (index >= 0)
            {
                string before = txt.Substring(0, index);
                string match = txt.Substring(index, res.Length);
                string after = txt.Substring(index + res.Length);

                _tmp.text = before
                           + $"<color=#FFFF00>{match}</color>"
                           + after;
                return;
            }
        }

        // no match or empty input → reset
        _tmp.text = txt;
    }
    void Checking(string res)
    {
        // get reference text mesh pro (must step)
        string fromText = this.GetComponent<TextMeshProUGUI>().text;

        string txt = "";
        string pattern = @"<color=#[0-9A-F]{6}>([^<]+)<\/color>([^<]*)";

        // Matching and Capturing
        Match match = Regex.Match(fromText, pattern);

        if (match.Success)
        {
            txt = match.Groups[1].Value + match.Groups[2].Value;
            // Console.WriteLine("Extracted Text: " + extractedText); // Output: Bodoh
        }
        // Debug.Log(txt + " - " + res);
        if (txt == res)
        {
            if (this.gameObject.tag == "0")
            {
                WordsSpawnManager.wordGoodused.Remove(Convert.ToInt32(this.gameObject.name));
                sanityMeter.stt.value += 5;

            }
            if (this.gameObject.tag == "1")
            {
                WordsSpawnManager.wordBaddused.Remove(Convert.ToInt32(this.gameObject.name));
                sanityMeter.stt.value -= 10;
            }
            Destroy(this.gameObject);
        }
    }
}