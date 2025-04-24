using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public GameObject? playMenu;
    public void GamePopUp()
    {
        playMenu.SetActive(true);
    }

    public void PlayingNew()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit(1);
    }
}
