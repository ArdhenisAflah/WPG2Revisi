using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGameCloseHandle : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            MinigameObject1.IsOpened = false;
            this.gameObject.SetActive(false);
        }
    }
}
