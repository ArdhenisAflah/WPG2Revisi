using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    public TMP_Text DayText;
    
	private float SecondCount;
	private int MinuteCount;
	private int HourCount;
    private int DayCount;

    void Start()
    {
        DayCount = 1;
        HourCount = 6;
    }

    void Update()
    {
        UpdateTimerUI();
    }

    // Call this on update
    public void UpdateTimerUI()
    {
		//set timer UI
		SecondCount += Time.deltaTime * 2;
		TimerText.text = HourCount + ":" + MinuteCount + ":" + SecondCount;
        DayText.text = "Day " + DayCount;
		
        if(SecondCount >= 60)
        {
			MinuteCount++;
			SecondCount = 0;
		}
        else if(MinuteCount >= 60)
        {
			HourCount++;
			MinuteCount = 0;
		}
        else if(HourCount >= 20)
        {
            DayCount++;
        }
	}
}
