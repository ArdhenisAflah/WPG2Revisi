using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoverWorder : MonoBehaviour
{
    public TMP_Text wordText;
    public GameObject panelTypingGame;
    public static event Action OnActiveMovementScriptAgain;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Slide the text down
        wordText.rectTransform.Translate(Vector3.down * 50 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "collidertyping1")
        {
            Debug.Log("Game Over!");
            // enable lagi skrip
            OnActiveMovementScriptAgain.Invoke();
        }
    }
}
