using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToEnding : MonoBehaviour
{
    public Image FadeIMG; // Assign your UI Image here
    public GameObject SparkyModel;
    public GameObject PoppyModel;
    public GameObject DemoModel;
    public GameObject DuckyModel;


    private void Update()
    {
        if (SparkyModel == null && PoppyModel == null && DemoModel == null && DuckyModel == null) 
        {
            LoadSceneWithFade("DemoEnd");
        }
    }

    public void LoadSceneWithFade(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {

        // Fade to black
        
            for (float t = 0; t <= 1; t += Time.deltaTime)
            {
                FadeIMG.color = new Color(0, 0, 0, t);
                yield return null;
            }

        // Load the scene
       
            SceneManager.LoadScene(sceneName);

        // Fade back in
       
            for (float t = 1; t >= 0; t -= Time.deltaTime)
            {
                FadeIMG.color = new Color(0, 0, 0, t);
                yield return null; 
            } 
    }
}
