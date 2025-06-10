using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using UnityEngine.SceneManagement;

public class sanityMeter : MonoBehaviour
{
    [SerializeField]
    GameObject sliderObj;
    [SerializeField]
    GameObject questPopUp;
    Animator animQuest;
    AnimatorStateInfo stateInfo;
    public static Slider stt;


    void Start()
    {
        stt = sliderObj.GetComponent<Slider>();
        var trm = questPopUp.GetComponent<Transform>();
        var trmfirst = trm.GetChild(0);
        animQuest = trmfirst.GetComponent<Animator>();

        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        while (stt.value > 0)
        {
            stt.value -= 1;
            yield return new WaitForSeconds(1);
        }

        Debug.Log("GameOver Sanity Meter Habis!!");
        questPopUp.SetActive(true);
    }
    private void Update()
    {
        // Get the current animation state information for the base layer
        stateInfo = animQuest.GetCurrentAnimatorStateInfo(0);
        // Check if the "Attack" animation is playing and has completed
        if (stateInfo.IsName("QuestFailed") && stateInfo.normalizedTime >= 1.0f)
        {
            Debug.Log("animation has finished.");
            SceneManager.LoadScene("SampleScene");
            // Add your logic here, e.g., allow the player to move again.
        }
    }
}
