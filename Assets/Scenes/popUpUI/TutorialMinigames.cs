using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMinigames : MonoBehaviour
{
    public bool IsFirstTime;
    public Animator anim;
    [SerializeField]
    GameObject tutorialPanel;
    [SerializeField]
    GameObject bgtutorial;

    [SerializeField]
    MonoBehaviour[] scriptForDisable;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        IsFirstTime = true;
    }

    private void OnEnable()
    {
        anim.SetBool("Popping?", true);
        foreach (var item in scriptForDisable)
        {
            item.enabled = false;
        }
    }

    // event onclick Close
    public void setClose()
    {
        IsFirstTime = false;
        tutorialPanel.SetActive(false);
        bgtutorial.SetActive(false);
        foreach (var item in scriptForDisable)
        {
            item.enabled = true;
        }
    }

    private void Update()
    {
    }
}
