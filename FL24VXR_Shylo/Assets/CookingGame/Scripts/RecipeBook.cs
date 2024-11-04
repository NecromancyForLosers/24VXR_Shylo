using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;

public class RecipeBook : MonoBehaviour
{

    public GameObject[] prefab; //prefab array
    public List<Ingredients> ingredients = new List<Ingredients>(); //Ingredient List
    public List<Recipe> recipes = new List<Recipe>(); //Recipe List
    public int numberOfPrefabsToSpawn = 1; //This is how many prefabs will spawn on the location
    bool IsRecipeActive = false; //sets the recipe to not active until it is activated
    [SerializeField] TextMeshProUGUI earningsText;
    public int totalEarnings = 0;






    void Start()
    {

        //Ingredients are being added to the list
        ingredients.Add(new Ingredients("Sphere Red", 0, Resources.Load("Ingredients/SphereRed") as GameObject, 3));
        ingredients.Add(new Ingredients("Sphere Green", 1, Resources.Load("Ingredients/SphereGreen") as GameObject, 5));
        ingredients.Add(new Ingredients("Sphere Purple", 2, Resources.Load("Ingredients/SpherePurple") as GameObject, 6));
        ingredients.Add(new Ingredients("Cube Yellow", 3, Resources.Load("Ingredients/CubeYellow") as GameObject, 4));
        ingredients.Add(new Ingredients("Cube Blue", 4, Resources.Load("Ingredients/CubeBlue") as GameObject, 2));

        //Recipes are being added to the list
        recipes.Add(new Recipe("Recipe 1", 0, RandomIngredientList()));
        recipes.Add(new Recipe("Recipe 2", 1, RandomIngredientList()));
        recipes.Add(new Recipe("Recipe 3", 2, RandomIngredientList()));



        //Spawns the randomized recipe prefabs
        SpawnRecipe();
        
    }



   



    //randomizes ingredient list
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


    //Performs a handful of tasks when the pan is clicked
    void PanClick()
    {

        Destroy(GameObject.Find("Pan Item 1"));
        Destroy(GameObject.Find("Pan Item 2"));
        Destroy(GameObject.Find("Pan Item 3"));
        GameObject parent1 = GameObject.Find("RecLoc1"); //Giving the RecLoc1 a name in the code to refer to it
        GameObject parent2 = GameObject.Find("RecLoc2"); //Giving the RecLoc2 a name in the code to refer to it
        GameObject parent3 = GameObject.Find("RecLoc3"); //Giving the RecLoc3 a name in the code to refer to it

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


    //Spawns the randomized recipe
    public void SpawnRecipe()
    {

        for (int i = 0; i < numberOfPrefabsToSpawn; i++)
        {
            GameObject prefabToSpawn = prefab[Random.Range(0, prefab.Length)]; //Randomly picks from the array of prefabs

            GameObject instance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform); //Instantiates one prefab to the chosen location
            instance.name = "RecipeItems" + name; //Naming it so it is easier to refer to in the code

            Debug.Log("GameObjects: " + prefabToSpawn);  //Prefab to spawn is the name of the prefab ei "CubeYellow"

            // Disable the collider to make it unclickable
            Collider collider = instance.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false; // Disable the collider
            }
        }
    }


    // checks to see if the condition is needed and calls the code inside of it every frame
    void Update()
    {

        if (!IsRecipeActive && GameObject.Find("RecipeItemsRecLoc1") == null || GameObject.Find("RecipeItemsRecLoc2") == null || GameObject.Find("RecipeItemsRecLoc3") == null) //Checking to see if gameobject is or isnt null
        {
            Debug.Log("Recipe Respawning");

            SpawnRecipe(); //Reruns spawn recipe code if recipe is null

                DisplayIngredientValue(0);
            
        }


    }

    public void DisplayIngredientValue(int index)
    {
        // Check if the index is within the list bounds
        if (index >= 0 && index < ingredients.Count)
        {
            // Access the ingredient at the specified index
            int ingredientValue = ingredients[index].dollarValue;
            // Update the Text component to display the ingredient's dollar value

            AddEarnings(ingredientValue);
           
        }
    }

    private void UpdateEarningsText()
    {
        earningsText.text = "Earnings:" + totalEarnings; // Update the earnings display
    }

    public void AddEarnings(int dollarValue)
    {
        totalEarnings += dollarValue; // Update total earnings
        UpdateEarningsText(); // Update the UI text to reflect the new total
    }




    void OnMouseDown() //When clicked
    {
        if (!Timer.isTimerActive)
        {
            return; //Stops running the code if the timer is not active
        }

        PanClick(); //Runs Panclick code

    }




}
