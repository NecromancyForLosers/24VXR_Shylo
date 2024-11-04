using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Recipe
{
    public string recipe;
    public int recipeID;
    public GameObject prefab;
    Transform moveLoc;
    public List<int> ingredientsID;
    public static int maxNumber = 3;


    public Recipe(string _recipe, int _recipeID, List<int> _ingredientsID )
    {
        recipe = _recipe;
        recipeID = _recipeID;
        ingredientsID = _ingredientsID;
    }
}
