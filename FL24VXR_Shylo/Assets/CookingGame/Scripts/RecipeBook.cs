using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public List<Ingredients> ingredients = new List<Ingredients>();
    public List<Recipe> recipe = new List<Recipe>();



    void Start()
    {
        ingredients.Add(new Ingredients("Sphere Red", 0, Resources.Load("CookingGame/Ingredients/SphereRed") as GameObject, 3));
        ingredients.Add(new Ingredients("Sphere Green", 1, Resources.Load("CookingGame/Ingredients/SphereGreen") as GameObject, 5));
        ingredients.Add(new Ingredients("Sphere Purple", 2, Resources.Load("CookingGame/Ingredients/SpherePurple") as GameObject, 6));
        ingredients.Add(new Ingredients("Cube Yellow", 3, Resources.Load("CookingGame/Ingredients/CubeYellow") as GameObject, 4));
        ingredients.Add(new Ingredients("Cube Blue", 4, Resources.Load("CookingGame/Ingredients/CubeBlue") as GameObject, 2));

       // recipes.Add(new Recipe("Recipe 1", 0, 3, 5, RandomIngredientList(), 20));
      //  recipes.Add(new Recipe("Recipe 2", 1, 5, 10, RandomIngredientList(), 20));
       // recipes.Add(new Recipe("Recipe 3", 2, 3, 7, RandomIngredientList(), 50));
      //  recipes.Add(new Recipe("Recipe 4", 3, 2, 8, RandomIngredientList(), 30));









        SpawnIngredients();
        ChooseRecipe();
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



    void ChooseRecipe()
    {
    
    }
}
