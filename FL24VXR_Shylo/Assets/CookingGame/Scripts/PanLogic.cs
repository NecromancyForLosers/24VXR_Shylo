using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PanLogic : MonoBehaviour
{

    public GameObject prefab; // Assign your prefab in the Inspector
    private GameObject instantiatedObject;
    //[SerializeField] TextMeshProUGUI earningsText;
    public List<Ingredients> ingredients = new List<Ingredients>();
    


    private void Update()
    {
        //CheckRecipe();
        //DisplayIngredientValue(0);

    }

    //public void DisplayIngredientValue(int index)
    //{
    //    // Check if the index is within the list bounds
    //    if (index >= 0 && index < ingredients.Count)
    //    {
    //        // Access the ingredient at the specified index
    //        Ingredients ingredient = ingredients[index];

    //        // Update the Text component to display the ingredient's dollar value
    //        earningsText.text = "Earnings:" + ingredient.dollarValue;
    //    }
    //    else
    //    {
    //        // If the index is out of bounds, display an error message
    //        earningsText.text = "Ingredient not found!";
    //    }
    //}


    //void CheckRecipe()
    //{
    //    GameObject ingredient1 = GameObject.Find("Pan Item 1");
    //    GameObject recipe1 = GameObject.Find("RecipeItemsRecLoc1");

    //    if (recipe1 == null) 
    //    {
    //        if (ingredient1 == recipe1)
    //        {
    //            Debug.Log("Correct");
    //        }

    //        if (ingredient1 != recipe1)
    //        {
    //            Debug.Log("Wrong!");
    //        } 
    //    }
    //}


    //public void AddEarnings(int amount)
    //{
    //    // Add the value to the total earnings
    //    totalEarnings += amount;

    //    // Update the display
    //    UpdateEarningsText();
    //}

    //void UpdateEarningsText()
    //{
    //    // Display earnings on the Canvas
    //    earningsText.text = "Earnings: $" + totalEarnings;
    //}

    //public void DisplayIngredient(int index)

    //{
    //    GameObject Ingredient1 = GameObject.Find("Pan Item 1");
    //    // Check if the index is within the list bounds
    //    if (index >= 0 && index < ingredients.Count)
    //    {
    //        // Access the item at the specified index
    //        Ingredients ingredient = ingredients[index];

    //        // Update the Text component to display the ingredient's name and value
    //        earningsText.text = "Earnings" + ingredient.dollarValue;
    //    }
    //    else
    //    {
    //        // If the index is out of bounds, display an error message
    //        earningsText.text = "Ingredient not found!";
    //    }
    //}

    //public void DisplayIngredient(string ingredientName)
    //{
    //    // Find the GameObject in the scene by its name
    //    GameObject ingredient1 = GameObject.Find("Pan Item 1");

    //    if (ingredient1 != null)
    //    {
    //        // Access the name directly (or any other property)
    //        earningsText.text = "Earnings: $" + ingredient1.name; // Assuming name contains the value
    //    }
    //    else
    //    {
    //        // If the GameObject is not found, display an error message
    //        earningsText.text = "Ingredient not found!";
    //    }
    //}
}
