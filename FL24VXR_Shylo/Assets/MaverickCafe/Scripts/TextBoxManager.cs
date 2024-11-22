using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class TextBoxManager : MonoBehaviour
{

    public TextMeshProUGUI theText;

    public GameObject textBox;

    public GameObject TextCanvas;


    public TextAsset DemoText;
    public string[] textlines;

    public int currentLine;
    public int endALine;

    private bool hasShown = false;

    public Animator animator;       // Reference to the Animator
    public string animationName;


    // Start is called before the first frame update
    void Start()
    {
        if (DemoText != null)
        {
            textlines = (DemoText.text.Split('\n'));
        }

        if (endALine == 0)
        {
            endALine = textlines.Length - 1;
        }

    }

    private void Update()
    {
        theText.text = textlines[currentLine];

       
            if (!hasShown)
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

                // Check if the animation is finished
                if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f)
                {
                    TextCanvas.SetActive(true); // Show the object
                    hasShown = true;             // Prevent further calls
                }
            }

    }

    public void nextLine()
    {
        currentLine += 1;

        if (currentLine > endALine) 
        {
            TextCanvas.SetActive(false);
        }
    }




}
