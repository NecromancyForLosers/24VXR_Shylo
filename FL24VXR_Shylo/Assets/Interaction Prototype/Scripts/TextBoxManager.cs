using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class TextBoxManager : MonoBehaviour
{

    public TextMeshProUGUI theText;

    public GameObject textBox;

    //public Text thetext;


    public TextAsset DemoText;
    public string[] textlines;

    public int currentLine;
    public int endALine;


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

    }

    public void nextLine()
    {
        currentLine += 1;

        if (currentLine > endALine) 
        {
            textBox.SetActive(false);
        }
    }

}
