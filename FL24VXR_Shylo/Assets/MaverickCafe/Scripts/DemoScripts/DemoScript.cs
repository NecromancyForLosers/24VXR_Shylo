using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoScript : MonoBehaviour
{

   public GameObject DrinkSpot;
   public float countdownTime = 30f;
   public Animator Animator;
   public Image TimerBar;
   private Coroutine countdownCoroutine;
   public GameObject TimerUI;
   public DrinkPlace1 wrong;
   public GameObject StartTalkBox;
   public AudioSource Walking;
   public AudioSource SitDown;



    public void DestroyObject()
    {
        Destroy(gameObject);
    }


    public void EnableDrinkSpot1() 
    {
        DrinkSpot.SetActive(true);
     
    }

    public void DisableDrinkSpot1() 
    {
        DrinkSpot.SetActive(false);
   
    }

    public void PlayWalkSounds() 
    {
        Walking.Play();
    }

    public void StopWalkSounds()
    {
        Walking.Stop();
    }

    public void PlaySitSound()
    {
        SitDown.Play();
    }



    void StartTimer() 
    {
        countdownCoroutine = StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        TimerUI.SetActive(true);
        float time = countdownTime;
        while (time > 0)
        {
            Debug.Log($"Time Remaining: {time:F2} seconds");
            yield return new WaitForSeconds(1f); // Wait for 1 second
            time--;
            TimerBar.fillAmount = time / countdownTime;
        }
        Debug.Log("Time's up!");
        if (time == 0)
        {
            Animator.Play("WalkOut", -1, 0f);
        }
    }
    public void StopCountdown()
    {
        if (countdownCoroutine != null)
        {
            TimerUI.SetActive(false);
            StopCoroutine(countdownCoroutine); // Stop the Coroutine
            Debug.Log("Countdown stopped!");
            if (StartTalkBox)
            { 
            StartTalkBox.SetActive(false);
            }

        }
    }

}


