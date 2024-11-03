using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;

public class RecipeBook : MonoBehaviour
{ 
    
    public GameObject[] prefab;
    public List<Ingredients> ingredients = new List<Ingredients>();
    public List<Recipe> recipes = new List<Recipe>();
    public int numberOfPrefabsToSpawn = 1;
    //public List<GameObject> objectList = new List<GameObject>();
    bool IsRecipeActive = false;






    void Start()
    {
     ingredients.Add(new Ingredients("Sphere Red", 0, Resources.Load("Ingredients/SphereRed") as GameObject, 3));
     ingredients.Add(new Ingredients("Sphere Green", 1, Resources.Load("Ingredients/SphereGreen") as GameObject, 5));
     ingredients.Add(new Ingredients("Sphere Purple", 2, Resources.Load("Ingredients/SpherePurple") as GameObject, 6));
     ingredients.Add(new Ingredients("Cube Yellow", 3, Resources.Load("Ingredients/CubeYellow") as GameObject, 4));
     ingredients.Add(new Ingredients("Cube Blue", 4, Resources.Load("Ingredients/CubeBlue") as GameObject, 2));


        recipes.Add(new Recipe("Recipe 1", 0, RandomIngredientList()));
        recipes.Add(new Recipe("Recipe 2", 1, RandomIngredientList()));
        recipes.Add(new Recipe("Recipe 3", 2, RandomIngredientList()));

       


        SpawnRecipe();
        //SpawnIngredients();

    }


   

    public List<int> RandomIngredientList()
    {
        List<int> tempList = new List<int>();
        for (int i = 0; i < Recipe.maxNumber; i++)
        {
            tempList.Add(Random.Range(0, ingredients.Count - 1));

        }
        return tempList;
    }




    //void SpawnIngredients() 
    //{
    //   for (int i = 0; i < ingredients.Count; i++) 
    //   {
    //        GameObject tempObj = Instantiate(ingredients[i].prefab);
    //        tempObj.name = i.ToString();
    //        Vector3 tempv3 = tempObj.transform.position;
    //        tempObj.transform.position = new Vector3(tempv3.x + (i * 1), tempv3.y, tempv3.z);
    //   }
    //}

    void PanClick() 
    {
        Destroy(GameObject.Find("Pan Item 1"));
        Destroy(GameObject.Find("Pan Item 2"));
        Destroy(GameObject.Find("Pan Item 3"));
        GameObject parent1 = GameObject.Find("RecLoc1");
        GameObject parent2 = GameObject.Find("RecLoc2");
        GameObject parent3 = GameObject.Find("RecLoc3");
       

        if (parent1 != null)
        {
            // Find the child objects and destroy them
            foreach (Transform child in parent1.transform)
            {
                Destroy(child.gameObject); // This will destroy the child clone
            }
        }
        if (parent2 != null)
        {
            // Find the child objects and destroy them
            foreach (Transform child in parent2.transform)
            {
                Destroy(child.gameObject); // This will destroy the child clone
            }
        }
        if (parent3 != null)
        {
            // Find the child objects and destroy them
            foreach (Transform child in parent3.transform)
            {
                Destroy(child.gameObject); // This will destroy the child clone
               
            }
        }
    
    }



    public void SpawnRecipe()
    { 
   
        
        for (int i = 0; i < numberOfPrefabsToSpawn; i++)
        {
            GameObject prefabToSpawn = prefab[Random.Range(0, prefab.Length)];

            GameObject instance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform);
            instance.name = "RecipeItems" + name;

            Debug.Log("GameObjects: " + prefabToSpawn);

            // Disable the collider to make it unclickable
            Collider collider = instance.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false; // Disable the collider
            }
        }   
    } //Prefab to spawn is the name of the prefab ei "CubeYellow"

    
     void Update()
    {
        
            if (!IsRecipeActive && GameObject.Find("RecipeItemsRecLoc1") == null || GameObject.Find("RecipeItemsRecLoc2") == null || GameObject.Find("RecipeItemsRecLoc3") == null)
            {
                Debug.Log("Recipe Respawning");

                SpawnRecipe();
            }

        
    }


    void OnMouseDown()
    { 
        if (!Timer.isTimerActive)
        {
            return;
        }
       
        PanClick();
       
    }

 


}
