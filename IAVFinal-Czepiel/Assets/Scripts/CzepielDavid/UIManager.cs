using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    AgentesManager agentsManager;

    [SerializeField]
    List<GameObject> currentMealItems;

    /// <summary>
    /// Updates the UI to display only the menu items that will be included in the next customer order
    /// </summary>
    /// <param name="itemsIncludedInTheNextMeal"> List of bools where each one indicates wether a specific meal item is included or not </param>
    public void ShowMealItems(List<bool> itemsIncludedInTheNextMeal)
    {
        for (int i = 0; i < itemsIncludedInTheNextMeal.Count; i++)
            currentMealItems[i].SetActive(itemsIncludedInTheNextMeal[i]);
    }

    /// <summary>
    /// Includes/excludes a specific item from the next customer meal
    /// </summary>
    /// <param name="item"> Item that is going to be toggled </param>
    public void toggleMenuItem(int item)
    {
        currentMealItems[item].SetActive(!currentMealItems[item].activeSelf);
        agentsManager.toggleMenuItem(item);
    }
}