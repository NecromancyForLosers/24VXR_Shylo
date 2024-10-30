using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public List<Ingredients> ingredients = new List<Ingredients>();
    public List<Recipe> recipes = new List<Recipe>();
    public int numberOfPrefabsToSpawn = 1;
    public GameObject[] Prefabs;

    





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
      recipes.Add(new Recipe("Recipe 4", 3, RandomIngredientList()));


        ChooseRecipe();
        SpawnRandomPrefabs();
    }

    

    void SpawnIngredients() 
    {
       for (int i = 0; i < ingredients.Count; i++) 
       {
            GameObject tempObj = Instantiate(ingredients[i].prefab);
            tempObj.name = i.ToString();
            Vector3 tempv3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempv3.x + (i * 1), tempv3.y, tempv3.z);
       }
    }

    public void PanClick() 
    {
        Destroy(GameObject.Find("Pan Item 1"));
        Destroy(GameObject.Find("Pan Item 2"));
        Destroy(GameObject.Find("Pan Item 3"));
       // Destroy(GameObject.Find(""));
        //Destroy(GameObject.Find("RecLoc2"));
       // Destroy(GameObject.Find("RecLoc3"));
        
        //SpawnRandomPrefabs();
    }
    void OnMouseDown()
    {
        PanClick(); 
    }




   




    public void SpawnRandomPrefabs()
    {

        for (int i = 0; i < recipes.Count; i++)
        {
            // Choose a random prefab from the array
            GameObject prefabToSpawn = Prefabs[Random.Range(0, Prefabs.Length)];

            // Instantiate the prefab as a child of this GameObject
            GameObject instance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform);

            Collider collider = instance.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
    }



    void ChooseRecipe()
    {
    
    }


}
