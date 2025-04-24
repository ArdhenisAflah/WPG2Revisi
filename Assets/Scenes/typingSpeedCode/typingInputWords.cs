using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class typingInputWords : MonoBehaviour
{
    public static event Action<string> OnCheckWord;
    public static event Action<string> OnHighlightWord;

    void Start()
    {
        this.GetComponent<TMP_InputField>().ActivateInputField();
    }
    public void OnTypingCheck(string res)
    {
        // checking if the word type player is correct!.
        OnCheckWord?.Invoke(res);
        this.GetComponent<TMP_InputField>().ActivateInputField();
    }

    public void OnTypingEach(string res)
    {
        OnHighlightWord?.Invoke(res);
    }
}
