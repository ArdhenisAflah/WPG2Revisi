using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CodeManagerKeyboard : MonoBehaviour
{
    public List<KeyCode> keyList; // List of keys to track
    public Dictionary<KeyCode, SpriteRenderer> keySprites = new Dictionary<KeyCode, SpriteRenderer>();
    public Dictionary<KeyCode, Sprite> normalSprites = new Dictionary<KeyCode, Sprite>();
    public List<Sprite> pressedAssets = new List<Sprite>();
    public Dictionary<KeyCode, Sprite> pressedSprites = new Dictionary<KeyCode, Sprite>();


    // event system action
    public static event Action<string> OnClickKeyBoard;
    public static event Action OnClickBackSpace;
    void Start()
    {
        int counterPressedAssets = 0;
        // Initialize sprite renderers for each key
        foreach (KeyCode key in keyList)
        {
            GameObject keyObject = GameObject.Find(key.ToString()); // Assuming objects are named after keys
            if (keyObject != null)
            {
                SpriteRenderer renderer = keyObject.GetComponent<SpriteRenderer>();
                keySprites[key] = renderer;
                normalSprites[key] = renderer.sprite; // Store original sprite
                // store pressed sprite
                pressedSprites[key] = pressedAssets[counterPressedAssets++];
            }
        }
    }

    void Update()
    {
        foreach (KeyCode key in keyList)
        {
            if (Input.GetKeyDown(key) && keySprites.ContainsKey(key))
            {
                if (pressedSprites.ContainsKey(key))
                    // track which one key..
                    if (key != KeyCode.Backspace)
                    {
                        OnClickKeyBoard?.Invoke(key.ToString().ToLower());
                    }
                keySprites[key].sprite = pressedSprites[key]; // Change to pressed sprite
            }
            if (Input.GetKeyUp(key) && keySprites.ContainsKey(key))
            {
                keySprites[key].sprite = normalSprites[key]; // Revert to normal sprite
            }


























            

            if (Input.GetKeyDown(key) && key == KeyCode.Backspace)
            {
                OnClickBackSpace?.Invoke();
            }
        }
    }
}
