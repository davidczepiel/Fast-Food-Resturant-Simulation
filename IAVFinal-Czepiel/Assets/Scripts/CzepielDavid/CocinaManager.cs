using System.Collections.Generic;
using UnityEngine;

public class CocinaManager : MonoBehaviour
{
    public GameObject fatherOfPlacesToPrepareHamburguers;
    public GameObject fatherOfPlacesToPrepareFries;
    public GameObject fatherOfPlacesToPrepareDrinks;
    public GameObject fatherOfPlacesToPrepareIceCreams;

    List<GameObject> placesToPrepareHamburguers = new List<GameObject>();
    List<GameObject> placesToPrepareFries = new List<GameObject>();
    List<GameObject> placesToPrepareDrinks = new List<GameObject>();
    List<GameObject> placesToPrepareIceCreams = new List<GameObject>();

    List<GameObject> ordersInProgress = new List<GameObject>();

    private void Start()
    {
        Transform[] allChildren = fatherOfPlacesToPrepareHamburguers.GetComponentsInChildren<Transform>();
        allChildren = fatherOfPlacesToPrepareFries.GetComponentsInChildren<Transform>();
        allChildren = fatherOfPlacesToPrepareDrinks.GetComponentsInChildren<Transform>();
        allChildren = fatherOfPlacesToPrepareIceCreams.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
            placesToPrepareHamburguers.Add(child.gameObject);
        foreach (Transform child in allChildren)
            placesToPrepareFries.Add(child.gameObject);
        foreach (Transform child in allChildren)
            placesToPrepareDrinks.Add(child.gameObject);
        foreach (Transform child in allChildren)
            placesToPrepareIceCreams.Add(child.gameObject);

        placesToPrepareHamburguers.RemoveAt(0);
        placesToPrepareFries.RemoveAt(0);
        placesToPrepareDrinks.RemoveAt(0);
        placesToPrepareIceCreams.RemoveAt(0);
    }

    /// <summary>
    /// Returns a random place from the available ones where an employee can start preparing specific order item 
    /// </summary>
    /// <param name="item"> item that the employee is going to start </param>
    /// <returns> Place where the employee can prepare the item </returns>
    public GameObject getPlaceToPrepareItem(MenuItem item)
    {
        switch (item)
        {
            case MenuItem.Hamburguesa: return getRandomElementFromList(placesToPrepareHamburguers);
            case MenuItem.Patatas: return getRandomElementFromList(placesToPrepareFries);
            case MenuItem.Bebida: return getRandomElementFromList(placesToPrepareDrinks);
            case MenuItem.Helado: return getRandomElementFromList(placesToPrepareIceCreams);
            default: return null;
        }
    }

    /// <summary>
    /// Returns a random element from a given list
    /// </summary>
    /// <param name="lugares"> List of elements to choose form </param>
    /// <returns> Random element from the list </returns>
    private GameObject getRandomElementFromList(List<GameObject> lugares)
    {
        int i = Random.Range(0, lugares.Count - 1);
        return lugares[i];
    }

    /// <summary>
    /// Marks an order as if it is being done rigth now
    /// </summary>
    /// <param name="newOrder"> New order that was just started </param>
    public void markOrderAsInCompletion(GameObject newOrder)
    {
        if (!ordersInProgress.Contains(newOrder))
            ordersInProgress.Add(newOrder);
    }

    /// <summary>
    /// Metodo que sirve para sacar un menu determinado de a lista de menus que se estan haciendo
    /// </summary>
    /// <param name="pedido">menu que vamos a quitar</param>
    public void removeOrderFromInCompletionList(GameObject pedido)
    {
        if (ordersInProgress.Contains(pedido))
            ordersInProgress.Remove(pedido);
    }

    /// <summary>
    /// Returns whether there are any orders being done or not 
    /// </summary>
    /// <returns> True if any order is being done right now, false otherwise </returns>
    public bool areThereAnyOrdersBeingDone()
    {
        return ordersInProgress.Count > 0;
    }

    /// <summary>
    /// Returns the first order that hasnt been completed yet so that an employee can help on its completion given 
    /// a list of order items that the employee can help with 
    /// </summary>
    /// <param name="itemsThatTheEmployeeCanHelpWith"> List of elements that the employee can help with </param>
    /// <returns> Order gameobject that has not been completed yet or null if there are no orders to complete </returns>
    public GameObject getOrderToHelpWith(List<int> itemsThatTheEmployeeCanHelpWith)
    {
        GameObject pedido = null;
        int i = 0;
        bool bucle = true;
        while (i < ordersInProgress.Count && bucle)
        {
            GameObject actual = ordersInProgress[i];
            Menu menu = actual.GetComponent<Menu>();
            for (int j = 0; j < itemsThatTheEmployeeCanHelpWith.Count; j++)
            {
                if (menu.isItemOrdered((MenuItem)itemsThatTheEmployeeCanHelpWith[j]) && !menu.itemTakenIntoAccount((MenuItem)itemsThatTheEmployeeCanHelpWith[j]))
                {
                    bucle = false;
                    pedido = actual;
                    break;
                }
            }
            i++;
        }

        return pedido;
    }

    /// <summary>
    /// Return the first order that is done with kitchen items or null if there are no orders like that
    /// </summary>
    /// <returns> Order done with the kitchen or null </returns>
    public GameObject getOrderWithNoKitchenItemsLeftToComplete()
    {
        GameObject pedido = null;

        int i = 0;
        bool bucle = true;
        while (i < ordersInProgress.Count && bucle)
        {
            GameObject actual = ordersInProgress[i];
            Menu menu = actual.GetComponent<Menu>();
            if (menu.isTheKitchenDoneWithThisOrder())
            {
                pedido = actual;
                bucle = false;
            }
            i++;
        }
        return pedido;
    }
}