using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckyScript : MonoBehaviour
{

    public GameObject DemoModel; //Demos model
    public Animator Animator; //Animator for Ducky
    public float minDelay = 5f;    // Minimum delay before playing the animation
    public float maxDelay = 30f;   //Maximum time before playing animation
    bool AnimationPlayed = false;  //animation played bool
    public AudioSource DoorChimes;  //Walk in sound
    public GameObject DrinkSpot2;  //Where the second drink 
    public float countdownTime = 30f;
    public Image TimerBar;
    private Coroutine countdownCoroutine;
    public GameObject TimerUI;
    public GameObject StartTalkBox;
    private Coroutine RandomCoroutine;



    // Start is called before the first frame update
    void Start()
    {

     Checkstatus1();

    }

    // Update is called once per frame
    void Update()
    {

        CheckStatus2();

    }


    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void EnableDrinkSpot2()
    {
        DrinkSpot2.SetActive(true);
    }

    public void DisableDrinkSpot2()
    {
        DrinkSpot2.SetActive(false);
    }


    private System.Collections.IEnumerator PlayAnimationAtRandomTime()
    {   
        float delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);
        Animator.Play("DuckyWalkin", -1, 0f);
        DoorChimes.Play();
        AnimationPlayed = true;
        Debug.Log("Random Animation activated");
    }


    void Checkstatus1()
    {
        if (DemoModel != null && !AnimationPlayed)
        {
            RandomCoroutine = StartCoroutine(PlayAnimationAtRandomTime());
            Debug.Log("Random Animation Starting up");
        }

    }


    void CheckStatus2() 
    {

        if (DemoModel==null && !AnimationPlayed)
        {
            Animator.Play("DuckyWalkin", -1, 0f);
            DoorChimes.Play();
            Debug.Log("Timed Animation activated");
            AnimationPlayed = true;
            StopCoroutine(RandomCoroutine);
        }
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
            Animator.Play("DuckyWalkOut", -1, 0f);
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
