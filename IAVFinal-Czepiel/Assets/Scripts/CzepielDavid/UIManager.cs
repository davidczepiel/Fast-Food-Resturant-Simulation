using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    AgentesManager agentsManager;

    [SerializeField]
    List<CanvasGroup> currentMealItems;

    [SerializeField]
    float disabledItemAlpha = 0.5f;

    /// <summary>
    /// Updates the UI to display only the menu items that will be included in the next customer order
    /// </summary>
    /// <param name="itemsIncludedInTheNextMeal"> List of bools where each one indicates wether a specific meal item is included or not </param>
    public void ShowMealItems(List<bool> itemsIncludedInTheNextMeal)
    {
        for (int i = 0; i < itemsIncludedInTheNextMeal.Count; i++)
            currentMealItems[i].alpha = itemsIncludedInTheNextMeal[i] ? 1.0f : disabledItemAlpha;
    }

    /// <summary>
    /// Includes/excludes a specific item from the next customer meal
    /// </summary>
    /// <param name="item"> Item that is going to be toggled </param>
    public void toggleMenuItem(int item)
    {
        currentMealItems[item].alpha = currentMealItems[item].alpha < 1.0f ? 1.0f : disabledItemAlpha;
        agentsManager.toggleMenuItem(item);
    }
}