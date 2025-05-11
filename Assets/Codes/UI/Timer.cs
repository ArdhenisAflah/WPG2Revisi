using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    public TMP_Text DayText;
    
	private float MinuteCount;
	private float HourCount;
    private string DayPart;
    private bool DayEnd;

    void Start()
    {
        HourCount = 6;
        DayPart = "AM";
    }

    void Update()
    {
        UpdateTimerUI();
    }

    // Call this on update
    public void UpdateTimerUI()
    {
		// Set timer UI
		MinuteCount += Time.deltaTime * 2;
		TimerText.text = HourCount + " : 00 " + DayPart;
        
        if(MinuteCount >= 60 && DayEnd == false)
        {
			HourCount++;
			MinuteCount = 0;
		}
        if(HourCount == 12)
        {
            DayPart = "PM";
            HourCount = 0;
        }
        if(HourCount == 21 && DayEnd == false)
        {
            DayEnd = true;
            HourCount = 6;
        }
	}
}