using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGameCloseHandle : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }
    }
}
