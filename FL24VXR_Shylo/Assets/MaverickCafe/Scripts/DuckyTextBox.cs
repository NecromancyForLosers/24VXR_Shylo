using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DuckyTextBox : MonoBehaviour
{
    public TextMeshProUGUI theTextDucky;
    public GameObject textBox2;
    public GameObject StartConvoBox;
    public GameObject TextCanvas;
    public TextAsset DuckyText;
    public string[] textlinesDucky;
    public int DuckycurrentLine;
    public int DuckyendALine;
    private bool hasShown = false;
    public Animator animator;       // Reference to the Animator
    public Animator WalkAnimator;
    public string animationName;
    //public AudioSource DuckyTalk;
    //public AudioSource DuckyTalkShort;


    // Start is called before the first frame update
    void Start()
    {
        if (DuckyText != null)
        {
            textlinesDucky = (DuckyText.text.Split('\n'));
        }

        if (DuckyendALine == 0)
        {
            DuckyendALine = textlinesDucky.Length - 1;
        }

    }

    private void Update()
    {
        theTextDucky.text = textlinesDucky[DuckycurrentLine];
        Debug.Log($"DuckycurrentLine: {DuckycurrentLine}, textlinesDucky.Length: {textlinesDucky?.Length}");

        if (!hasShown)
        {
            AnimatorStateInfo stateInfo = WalkAnimator.GetCurrentAnimatorStateInfo(0);

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
        //DuckyTalkShort.Play();
        animator.Play("DuckyTalk", -1, 0f);

    }

    public void nextLine()
    {
        DuckycurrentLine += 1;
        //DuckyTalk.Play();

        if (DuckycurrentLine > DuckyendALine)
        {
            TextCanvas.SetActive(false);
            //DuckyTalk.Stop();
            animator.Play("DuckyBlink", -1, 0f);
        }
    }
}
