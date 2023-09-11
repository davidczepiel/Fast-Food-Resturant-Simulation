using System.Collections.Generic;
using UnityEngine;

public enum MenuItem { Hamburguesa, Patatas, Bebida, Helado };

public class Menu : MonoBehaviour
{
    [SerializeField]
    List<GameObject> menuItems;

    private List<bool> itemsOrdered = new List<bool>() { false, false, false, false };
    private List<bool> completedItems = new List<bool>() { false, false, false, false };
    private List<bool> itemsInProccess = new List<bool>() { false, false, false, false };

    private bool mealIsReadyForTheCustomer = false;
    private bool mealGivenToCustomer = false;

    private int nextItemIndexToEat = 0;

    private void Start()
    {
        //Disable everything because the workers need to complete the order
        for (int i = 0; i < menuItems.Count; i++)
            menuItems[i].SetActive(false);
    }

    public void setCustomerOrder(List<bool> customerOrder) { itemsOrdered = customerOrder; }

    //Methods for the workers to update the order 
    public bool isItemOrdered(MenuItem item) { return itemsOrdered[(int)item]; }
    public void startPreparingItem(MenuItem item) { itemsInProccess[(int)item] = true; }
    public bool itemTakenIntoAccount(MenuItem item) { return completedItems[(int)item] || itemsInProccess[(int)item]; }
    public void completeOrderItem(MenuItem item)
    {
        completedItems[(int)item] = true;
        menuItems[(int)item].SetActive(true);
    }

    /// <summary>
    /// Tells whether the chefs are done with this order or not
    /// </summary>
    /// <returns> True if the order doesnt need any burguer/fries to be prepared </returns>
    public bool isTheKitchenDoneWithThisOrder()
    {
        bool kitchenDoneWithThisOrder = true;
        //If either a hamburguer or fries are needed for the order, the kitchen is not done with this meal yet 
        if (!completedItems[0] && itemsOrdered[0]) kitchenDoneWithThisOrder = false;
        if (!completedItems[1] && itemsOrdered[1]) kitchenDoneWithThisOrder = false;
        return kitchenDoneWithThisOrder;
    }

    //Is the order ready for the customer?
    public void setOrderReady(bool a) { mealIsReadyForTheCustomer = a; }
    public bool getOrderReady() { return mealIsReadyForTheCustomer; }
    /// <summary>
    /// Tells whether the order has all the items ordered and can be given to the customer or not
    /// </summary>
    /// <returns> True if the order is ready for the customer, false otherwise </returns>
    public bool isOrderFinished()
    {
        int i = 0;
        while (i < itemsOrdered.Count && itemsOrdered[i] == completedItems[i]) i++;
        return i >= itemsOrdered.Count;
    }

    //Has the order been given to the customer?
    public void setOrderGivenToCustomer(bool a) { mealGivenToCustomer = a; }
    public bool getOrderGivenToCustomer() { return mealGivenToCustomer; }

    /// <summary>
    /// Called each time the customer eats an item, this updates the order visually to display only the items left (that havent been eaten yet)
    /// and tells whether customer just finished his order 
    /// </summary>
    /// <returns> True if the customer has finished his order, false otherwise </returns>
    public bool comer()
    {
        while (nextItemIndexToEat < completedItems.Count && !completedItems[nextItemIndexToEat]) nextItemIndexToEat++;
        if (nextItemIndexToEat < completedItems.Count)
        {
            completedItems[nextItemIndexToEat] = false;
            menuItems[nextItemIndexToEat].SetActive(false);
        }

        nextItemIndexToEat++;
        return nextItemIndexToEat >= completedItems.Count;
    }
}