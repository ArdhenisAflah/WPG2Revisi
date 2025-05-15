using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameObject1 : MonoBehaviour, I_Interactable
{
    public bool IsOpened { get; private set; }
    public GameObject Minigame;
    // public MonoBehaviour[] scriptsToDisable;




    public bool CanInteract()
    {
        // Object is interactable
        return true;
    }

    public void setActiveMovementScriptAgain()
    {
        // Kita reset anakan typing game (anakan panel jadi 0 lagi)
        // DestroyAllChildren(TypingMinigame.transform);
        // Reset the game or show a game-over screen
        // TypingMinigame.SetActive(false);
    }
    public void DestroyAllChildren(Transform parent)
    {
        // for (int i = parent.childCount - 1; i >= 0; i--)
        // {
        //     if (parent.GetChild(i).gameObject.tag == "1" || parent.GetChild(i).gameObject.tag == "0")
        //     {
        //         Destroy(parent.GetChild(i).gameObject);
        //     }
        // }
    }

    public void Interact()
    {
        Debug.Log("Interacting with Object 2");

        // Set minigame aktif
        Minigame.SetActive(true);

        // //Ketika minigame aktif set skrip movement disable
        // foreach (MonoBehaviour script in scriptsToDisable)
        // {
        //     script.enabled = false;
        // }
    }
}
