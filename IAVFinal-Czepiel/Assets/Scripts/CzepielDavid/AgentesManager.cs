using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentesManager : MonoBehaviour
{
    [SerializeField]
    UIManager uiManager;

    [SerializeField]
    GameObject menuPrefab;
    [SerializeField]
    GameObject clientePrefab;
    [SerializeField]
    GameObject cajeroPrefab;
    [SerializeField]
    GameObject cocineroPrefab;

    [SerializeField]
    Vector3 posSpwanCliente;
    [SerializeField]
    Vector3 posSpwanCajero;
    [SerializeField]
    Vector3 posSpwanCocinero;

    List<bool> elementosSiguientePedido = new List<bool>();
    List<List<bool>> menusPersonalizados = new List<List<bool>>();

    private void Start()
    {
        elementosSiguientePedido = new List<bool>() { false, false, false, false };
        uiManager.ShowMealItems(elementosSiguientePedido);
    }

    /// <summary>
    /// Toggles a specific item for the next customer order
    /// </summary>
    /// <param name="item"> Item added/removed from the next customer order</param>
    public void toggleMenuItem(int item) { elementosSiguientePedido[item] = !elementosSiguientePedido[item]; }

    /// <summary>
    /// Returns a gameobject with the next customer's order
    /// In case there are custom orders available, one of those is returned
    /// Otherwise an order with all of the menu items is returned
    /// </summary>
    /// <returns> Gameobject with the next customer's order </returns>
    public GameObject giveNewCustomerOrder()
    {
        GameObject newOrder = Instantiate(menuPrefab, new Vector3(0, 100, 0), Quaternion.identity);
        Menu menu = newOrder.GetComponent<Menu>();
        //Take the lastest custom order or create a new one with all of the available items
        List<bool> actual;
        if (menusPersonalizados.Count > 0)
        {
            actual = menusPersonalizados[0];
            menusPersonalizados.RemoveAt(0);
        }
        else
            actual = new List<bool>() { true, true, true, true};

        menu.setCustomerOrder(actual);
        return newOrder;
    }


    ////////////SPAWN AGENTS///////////////
    public void spawnCashier() { Instantiate(cajeroPrefab, posSpwanCajero, Quaternion.identity); }
    public void spawnChef() { Instantiate(cocineroPrefab, posSpwanCocinero, Quaternion.identity); }
    public void spawnCustomer()
    {
        List<bool> nueva = new List<bool>();
        for (int i = 0; i < elementosSiguientePedido.Count; i++)
        {
            if (elementosSiguientePedido[i]) nueva.Add(true);
            else nueva.Add(false);
        }
        menusPersonalizados.Add(nueva);
        Instantiate(clientePrefab, posSpwanCliente, Quaternion.identity);
    }
    public void despawnCustomer(GameObject cliente) { Destroy(cliente); }
}