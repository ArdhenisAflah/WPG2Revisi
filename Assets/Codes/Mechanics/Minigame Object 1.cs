using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameObject1 : MonoBehaviour, I_Interactable
{
    public static bool IsOpened = false;

    public GameObject Minigame;

    public GameObject ShowBlockedPanel3;
    // public MonoBehaviour[] scriptsToDisable;


    public bool CanInteract()
    {
        Debug.Log("From Interact: " + this.gameObject.name);
        // if (this.gameObject.CompareTag("minigame3"))
        // {
        //     if (UtilityVarLikeDislike.MissingPiece == 16)
        //     {
        //         return true;
        //     }
        //     return false;
        // }
        // else
        // {
        return true;
        // }

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

    IEnumerator startCloseSeconds()
    {
        yield return new WaitForSeconds(3);
        ShowBlockedPanel3.SetActive(false);
    }


    public void Interact()
    {

        if (this.gameObject.CompareTag("minigame3"))
        {
            if (UtilityVarLikeDislike.MissingPiece == 16)
            {
                Minigame.SetActive(true);
            }
            else
            {
                // show blocked panel
                ShowBlockedPanel3.SetActive(true);
                StartCoroutine(startCloseSeconds());
            }
        }
        else
        {
            // Set minigame aktif
            Minigame.SetActive(true);
        }

        // Debug.Log("Interacting with Object 2");


        // //Ketika minigame aktif set skrip movement disable
        // foreach (MonoBehaviour script in scriptsToDisable)
        // {
        //     script.enabled = false;
        // }
    }


}
