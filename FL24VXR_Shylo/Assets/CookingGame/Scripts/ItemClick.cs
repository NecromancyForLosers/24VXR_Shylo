using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    public GameObject Prefab; // Assign your prefab in the inspector
    public static int clickCount = 0;
    public Transform spawnLocation; // Optional: set where to spawn the object


    private void OnMouseDown()
    {

        if (!Timer.isTimerActive)
        {
            return;
        }
        clickCount++;
        Transform moveLoc;
        GameObject tmp = Instantiate(this.gameObject);
        Destroy(tmp.GetComponent<ItemClick>());


        switch (clickCount)
        {
            case 1:
                tmp.name = "Pan Item 1";
                moveLoc = GameObject.Find("IngLoc1").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;

            case 2:
                tmp.name = "Pan Item 2";
                moveLoc = GameObject.Find("IngLoc2").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;

            case 3:
                tmp.name = "Pan Item 3";
                moveLoc = GameObject.Find("IngLoc3").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;


        }

        

        Debug.Log("GameObject clicked: " + gameObject.name);
    }
    
    void Update()
        {
        if (GameObject.Find("Pan Item 1") == null)
        {
            clickCount = 0;
        }

    }

 }

