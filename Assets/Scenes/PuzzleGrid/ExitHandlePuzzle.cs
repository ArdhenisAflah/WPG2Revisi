using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHandlePuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject minigamePuzzle;
    public void ExitPuzzle()
    {
        MinigameObject1.IsOpened = false;
        minigamePuzzle.SetActive(false);
    }
}
