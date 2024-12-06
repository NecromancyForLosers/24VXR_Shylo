using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoppyTextBox : MonoBehaviour
{
    public TextMeshProUGUI theTextPoppy;
    public GameObject textBox4;
    public GameObject StartConvoBox;
    public GameObject TextCanvas;
    public TextAsset PoppyText;
    public string[] textlinesPoppy;
    public int PoppycurrentLine;
    public int PoppyendALine;
    private bool hasShown = false;
    public Animator animator;       // Reference to the Animator
    public Animator WalkAnimator;
    public string animationName;
    public AudioSource PoppyTalk;
    public AudioSource PoppyTalkShort;


    // Start is called before the first frame update
    void Start()
    {
        if (PoppyText != null)
        {
            textlinesPoppy = (PoppyText.text.Split('\n'));
        }

        if (PoppyendALine == 0)
        {
            PoppyendALine = textlinesPoppy.Length - 1;
        }

    }

    private void Update()
    {
        theTextPoppy.text = textlinesPoppy[PoppycurrentLine];
        Debug.Log($"PoppycurrentLine: {PoppycurrentLine}, textlinesPoppy.Length: {textlinesPoppy?.Length}");

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
        PoppyTalk.Play();
        animator.Play("PoppyTalk", -1, 0f);

    }

    public void nextLine()
    {
        PoppycurrentLine += 1;
            PoppyTalkShort.Play();
        
        if (PoppycurrentLine > PoppyendALine)
        {
            TextCanvas.SetActive(false);
            PoppyTalkShort.Stop();
            animator.Play("Idle", -1, 0f);
        }
    }
}
