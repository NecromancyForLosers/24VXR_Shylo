using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ItemClick : MonoBehaviour
{
  
    public static int clickCount = 0;
    public Transform spawnLocation; // Optional: set where to spawn the object
    public static int RecipeSpawn = 0;
    public static int maxNumber = 3;
    public List<Ingredients> ingredients;





    //private void Start()
    //{

    //        RecipeSpawn++;
    //        GameObject tmp = Instantiate(gameObject);
    //        Transform moveLoc;
    //        Destroy(tmp.GetComponent<ItemClick>());
            

    //        switch (RecipeSpawn)

    //        {
    //        case 1:
    //            tmp.name = "Recipe Item 1";
    //            moveLoc = GameObject.Find("RecLoc1").transform;

    //            tmp.transform.position = moveLoc.position;
    //            tmp.transform.rotation = moveLoc.transform.rotation;
    //            tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    //            break;

    //        case 2:
    //            tmp.name = "Recipe Item 2";
    //            moveLoc = GameObject.Find("RecLoc2").transform;

    //            tmp.transform.position = moveLoc.position;
    //            tmp.transform.rotation = moveLoc.transform.rotation;
    //            tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    //            break;

    //        case 3:
    //            tmp.name = "Recipe Item 3";
    //            moveLoc = GameObject.Find("RecLoc3").transform;

    //            tmp.transform.position = moveLoc.position;
    //            tmp.transform.rotation = moveLoc.transform.rotation;
    //            tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    //            break;
    //        }
    //        Debug.Log("GameObject spawned: " + gameObject.name);

    //    }
    

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

