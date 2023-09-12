using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaManager : MonoBehaviour
{
    private List<GameObject> pedidosParaEmpezar = new List<GameObject>();
    private List<GameObject> pedidosParaCompletar = new List<GameObject>();
    private List<GameObject> pedidosParaRecoger = new List<GameObject>();

    private List<bool> clientWaitingInCashier = new List<bool>();
    private List<bool> cashierInControl = new List<bool>();
    private List<bool> cashierWithAnEmployee = new List<bool>();

    private void Start()
    {
        Transform[] allChildren = this.gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            cashierWithAnEmployee.Add(false);
            clientWaitingInCashier.Add(false);
            cashierInControl.Add(false);
        }
        cashierWithAnEmployee.RemoveAt(0);
        clientWaitingInCashier.RemoveAt(0);
        cashierInControl.RemoveAt(0);
    }


    public bool areThereAnyOrdersToStart() { return pedidosParaEmpezar.Count > 0; }
    public bool areThereAnyOrdersToComplete() { return pedidosParaCompletar.Count > 0; }
    public bool areThereAnyOrdersToGiveToTheCustomer() { return pedidosParaRecoger.Count > 0; }

    /// <summary>
    /// Adds an order to the list of orders to complete
    /// </summary>
    public void addOrderToTheToCompleteList(GameObject order)
    {
        if (!pedidosParaCompletar.Contains(order))
            pedidosParaCompletar.Add(order);
    }

    /// <summary>
    /// Ads an order to the list of orders that can be given to the customer
    /// </summary>
    public void addOrderToTheToGiveToTheCustomerList(GameObject order)
    {
        if (!pedidosParaRecoger.Contains(order))
            pedidosParaRecoger.Add(order);
    }

    /// <summary>
    /// Metodo que elimina un pedido a la lista de pedidos por completar
    /// </summary>
    public void removerOrderFromTheToCompleteList(GameObject order)
    {
        if (pedidosParaCompletar.Contains(order))
            pedidosParaCompletar.Remove(order);
    }

    /// <summary>
    /// Returns an order that has not been started yet
    /// </summary>
    /// <returns> Order to start making </returns>
    public GameObject getNewOrderToStart()
    {
        GameObject nuevo = pedidosParaEmpezar[0];
        pedidosParaEmpezar.RemoveAt(0);
        return nuevo;
    }

    /// <summary>
    /// Returns an order that has not been finished yet
    /// </summary>
    /// <returns> Order to continue </returns>
    public GameObject getOrderToComplete()
    {
        GameObject nuevo = pedidosParaCompletar[0];
        pedidosParaCompletar.RemoveAt(0);
        return nuevo;
    }

    /// <summary>
    /// Returns the first order ready for the customer
    /// </summary>
    /// <returns> Order ready </returns>
    public GameObject getOrderToGiveToTheCustomer()
    {
        GameObject nuevo = pedidosParaRecoger[0];
        pedidosParaRecoger.RemoveAt(0);
        return nuevo;
    }

    /// <summary>
    /// Returns whether there is a client waiting to be attended or not
    /// </summary>
    /// <returns> True if a client is waiting to order , false otherwise </returns>
    public bool isThereAnyClientWaitingToOrder()
    {
        int i = 0;
        while (i < clientWaitingInCashier.Count && (!clientWaitingInCashier[i] || (clientWaitingInCashier[i] && cashierInControl[i])))
            i++;
        return i < clientWaitingInCashier.Count;
    }

    /// <summary>
    /// Returns the cashier number to attend the very next customer in the queue
    /// </summary>
    /// <returns> Number of the cashier where the client is waiting </returns>
    public int getCashierNumberToAttendANewCustomer()
    {
        //This lets an employee mark a cashier as "controlled" to let the rest of the employees know that although there is a customer waiting
        //there is already an employee on its way to attend him
        int i = 0;
        while (i < clientWaitingInCashier.Count && (!clientWaitingInCashier[i] || (clientWaitingInCashier[i] && cashierInControl[i])))
            i++;
        cashierInControl[i] = true;
        return i;
    }

    /// <summary>
    /// Sets a specific cashier as attended
    /// </summary>
    /// <param name="numCaja"> number of the cashier that is being attended </param>
    public void takeCareOfCustomer(int numCaja)
    {
        cashierWithAnEmployee[numCaja] = true;
    }

    /// <summary>
    /// Returns the first order that hasnt been completed yet so that an employee can help on its completion given 
    /// a list of order items that the employee can help with 
    /// </summary>
    /// <param name="posiblesElementos"> List of elements that the employee can help with </param>
    /// <returns> Order gameobject that has not been completed yet or null if there are no orders to complete </returns>
    public GameObject getOrderToCOmplete(List<int> posiblesElementos)
    {
        GameObject pedido = null;
        int i = 0;
        bool bucle = true;
        while (i < pedidosParaCompletar.Count && bucle)
        {
            GameObject actual = pedidosParaCompletar[i];
            Menu menu = actual.GetComponent<Menu>();
            for (int j = 0; j < posiblesElementos.Count; j++)
            {
                if (menu.isItemOrdered((MenuItem)posiblesElementos[j]) && !menu.itemTakenIntoAccount((MenuItem)posiblesElementos[j]))
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


    //////////////////////CUSTOMERS METHODS///////////////////////////

    /// <summary>
    /// Returns the first available cashier where a customer can get attended
    /// </summary>
    /// <returns> Number of the first available cashier </returns>
    public int giveAvailableCashierToBeServed()
    {
        int i = 0;
        while (clientWaitingInCashier[i]) i++;
        clientWaitingInCashier[i] = true;
        return i;
    }

    /// <summary>
    /// Places an order leaves the cashier free for the next customer 
    /// </summary>
    /// <param name="numCaja"> Number of the cashier that is going to be freed </param>
    /// <param name="pedidoNuevo"> Order placed </param>
    public void placeOrder(int numCaja, GameObject pedidoNuevo)
    {
        pedidosParaEmpezar.Add(pedidoNuevo);
        clientWaitingInCashier[numCaja] = false;
        cashierWithAnEmployee[numCaja] = false;
        cashierInControl[numCaja] = false;
    }

    /// <summary>
    /// Returns whether a cashier has been attended or not 
    /// </summary>
    /// <param name="numCaja"> Number of the cashier </param>
    /// <returns> True if the cashier has been attended by a cashier, false otherwise </returns>
    public bool haveIBeenAttended(int numCaja)
    {
        return cashierWithAnEmployee[numCaja];
    }
}