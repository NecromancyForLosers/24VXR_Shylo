using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ItemClick : MonoBehaviour
{

    public static int clickCount = 0; //Integer that is equal to 0
    public Transform spawnLocation; // Optional: set where to spawn the object
    public static int RecipeSpawn = 0; //Integer that is equal to 0
    public static int maxNumber = 3; //Integer that is equal to 3
    public List<Ingredients> ingredients = new List<Ingredients>(); //Ingredient List
    
    

    private void OnMouseDown() //When clicked
    {
        if (clickCount < 3) 
        {
            if (!Timer.isTimerActive)
            {
                return;//Stops the code
            }
            clickCount++;
            Transform moveLoc;
            GameObject tmp = Instantiate(this.gameObject); //instantiates a temporary object
            Destroy(tmp.GetComponent<ItemClick>()); //Destroys Objects

         
            switch (clickCount)  //Goes through a list of conditions based on the expression 
            {
                case 1:
                    tmp.name = "Pan Item 1"; //Temporary name
                    moveLoc = GameObject.Find("IngLoc1").transform; //finds the IngLoc1 game object

                    tmp.transform.position = moveLoc.position; //Move temporary object to IngLoc1
                    tmp.transform.rotation = moveLoc.transform.rotation;
                    tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //Changes the size of the object
                break; //Ends case 1

                case 2:
                    tmp.name = "Pan Item 2"; //Temporary name
                    moveLoc = GameObject.Find("IngLoc2").transform; //finds the IngLoc2 game object

                    tmp.transform.position = moveLoc.position; //Move temporary object to IngLoc2
                    tmp.transform.rotation = moveLoc.transform.rotation;
                    tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //Changes the size of the object
                break; //Ends case 2

                case 3:
                    tmp.name = "Pan Item 3"; //Temporary name
                    moveLoc = GameObject.Find("IngLoc3").transform; //finds the IngLoc3 game object

                    tmp.transform.position = moveLoc.position; //Move temporary object to IngLoc3
                    tmp.transform.rotation = moveLoc.transform.rotation;
                    tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //Changes the size of the object
                break; //Ends case 3
            }

        }

        Debug.Log("GameObject clicked: " + gameObject.name);
    }

   

    void Update()
    {
        if (GameObject.Find("Pan Item 1") == null) //If pan item 1 is empty then click count begins at 0 again
        {
            clickCount = 0; //Resets clickcount back to zero
        }

    }

}

