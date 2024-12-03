using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SparkyTextBox : MonoBehaviour
{
    public TextMeshProUGUI theTextSparky;
    public GameObject textBox3;
    public GameObject StartConvoBox;
    public GameObject TextCanvas;
    public TextAsset SparkyText;
    public string[] textlinesSparky;
    public int SparkycurrentLine;
    public int SparkyendALine;
    private bool hasShown = false;
    public Animator animator;       // Reference to the Animator
    public Animator WalkAnimator;
    public string animationName;
    public AudioSource SparkyTalk;
    //public AudioSource SparkyTalkShort;


    // Start is called before the first frame update
    void Start()
    {
        if (SparkyText != null)
        {
            textlinesSparky = (SparkyText.text.Split('\n'));
        }

        if (SparkyendALine == 0)
        {
            SparkyendALine = textlinesSparky.Length - 1;
        }

    }

    private void Update()
    {
        theTextSparky.text = textlinesSparky[SparkycurrentLine];
        Debug.Log($"DuckycurrentLine: {SparkycurrentLine}, textlinesDucky.Length: {textlinesSparky?.Length}");

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
        SparkyTalk.Play();
        animator.Play("SparkyYap", -1, 0f);

    }

    public void nextLine()
    {
        SparkycurrentLine += 1;
        SparkyTalk.Play();

        if (SparkycurrentLine > SparkyendALine)
        {
            TextCanvas.SetActive(false);
            SparkyTalk.Stop();
            animator.Play("SparkyBlink", -1, 0f);
        }
    }
}
