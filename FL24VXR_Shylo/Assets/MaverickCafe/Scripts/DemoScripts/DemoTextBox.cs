using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DemoTextBox : MonoBehaviour
{

    public TextMeshProUGUI DemotheText;
    public GameObject textBox1;
    public GameObject StartConvoBox;
    public GameObject TextCanvas;
    public TextAsset DemoText;
    public string[] Demotextlines;
    public int DemocurrentLine;
    public int DemoendALine;
    private bool hasShown = false;
    public Animator animator;       // Reference to the Animator
    public string animationName;
    public AudioSource DemoTalk;
    public AudioSource DemoTalkShort;


    // Start is called before the first frame update
    void Start()
    {

        if (DemoText != null)
        {
            Demotextlines = (DemoText.text.Split('\n'));
        }

        if (DemoendALine == 0)
        {
            DemoendALine = Demotextlines.Length - 1;
        }

    }

    private void Update()
    {
        DemotheText.text = Demotextlines[DemocurrentLine];
        Debug.Log($"DemocurrentLine: {DemocurrentLine}, Demotextlines.Length: {Demotextlines?.Length}");

        if (!hasShown)
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

                // Check if the animation is finished
                if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f)
                {
                StartConvoBox.SetActive(true);

                hasShown = true;             // Prevent further calls
            }
            }

    }



    public void ShowTextBox() 
    {
        StartConvoBox.SetActive(false);
        TextCanvas.SetActive(true);
        hasShown = true;
        DemoTalkShort.Play();
        animator.Play("DemoTalk", -1, 0f);

    }

    public void nextLine()
    {
        DemocurrentLine += 1;
        DemoTalk.Play();

        if (DemocurrentLine > DemoendALine) 
        {
            TextCanvas.SetActive(false);
            DemoTalk.Stop();
            animator.Play("Idle", -1, 0f);
        }
    }




}
