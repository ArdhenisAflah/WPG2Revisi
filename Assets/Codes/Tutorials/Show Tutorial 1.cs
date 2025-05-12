using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorial1 : MonoBehaviour, I_Tutorial
{
    public bool HasShown = false;
    
    public bool CanShow()
    {
        // If Tutorial Hasn't Shown, It Can Show
        return !HasShown;
    }
    
    public void Show()
    {
        // If Tutorial Can't Show, do nothing
        if (!CanShow()) return;
        
        // If Tutorial Can Show, Show It
        ShowTutorial();
        // Set Tutorial as Has Shown
        HasShown = true;
    }

    private void ShowTutorial()
    {
        // Waiting for Asset
        // TutorialScreen1.SetActive(true);
    }
}