using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerValue = 30; //30 seconds
    [SerializeField] TextMeshProUGUI timerText; //"Timer text" ext
    public static bool isTimerActive = true; //Sets timer as active unless stated otherwise in the code


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginTimer()); //Start Timer

    }

    IEnumerator BeginTimer() //Timer counts down
    {
        while (timerValue >= 0)
        {
            timerValue -= Time.deltaTime;
            timerText.text = "Time:" + (int)timerValue;
            yield return null;
        }

        timerText.text = "Time:0";
        isTimerActive = false;
    }

}

