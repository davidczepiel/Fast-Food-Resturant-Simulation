using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaColocarPedido : MonoBehaviour
{
    [SerializeField]
    GameObject padreLugares;

    [SerializeField]
    List<GameObject> mesas = new List<GameObject>();

    [SerializeField]
    Vector3 separacion = new Vector3(0, 2.5f, 0);

    //List of lists that will contain all the customer orders being done
    private List<List<GameObject>> pedidosAcumulados = new List<List<GameObject>>();

    private void Start()
    {
        Transform[] allChildren = padreLugares.GetComponentsInChildren<Transform>();
        //For each child gameobject a new list is created to save the customer's orders
        foreach (Transform child in allChildren)
        {
            mesas.Add(child.gameObject);
            pedidosAcumulados.Add(new List<GameObject>());
        }

        //Remove the first element, because by default it represents the parent gameobject
        mesas.RemoveAt(0);
        pedidosAcumulados.RemoveAt(0);
    }

    /// <summary>
    /// Returns the table with the least amount of orders stored in it 
    /// </summary>
    /// <returns> Table gameobject with the lowest amount of orders </returns>
    public GameObject getTableToLeaveNewStartingOrder()
    {
        int menorAcumulacion = 1000;
        int indice = 0;
        for (int i = 0; i < pedidosAcumulados.Count; i++)
        {
            if (pedidosAcumulados[i].Count < menorAcumulacion)
            {
                indice = i;
                menorAcumulacion = pedidosAcumulados[i].Count;
            }
        }
        return mesas[indice];
    }

    /// <summary>
    /// Returns the table that contains the order specified by the parameter
    /// </summary>
    /// <param name="order"> Order that we are looking for </param>
    /// <returns> Table that contains the order </returns>
    public GameObject getTableThatContainsThisOrder(GameObject order)
    {
        GameObject mesa = null;
        int i = 0;
        while (i < pedidosAcumulados.Count)
        {
            if (pedidosAcumulados[i].Contains(order))
            {
                mesa = mesas[i];
                break;
            }
            i++;
        }
        return mesa;
    }

    /// <summary>
    /// Takes a menu and leaves it on top of a given table
    /// </summary>
    /// <param name="mesa"> Table where the order is going to be stored </param>
    /// <param name="pedido"> Order to store </param>
    public void leaveOrderOnTopOfTable(GameObject mesa, GameObject pedido)
    {
        pedidosAcumulados[mesas.IndexOf(mesa)].Add(pedido);
        pedido.transform.position = mesa.transform.position + (separacion * pedidosAcumulados[mesas.IndexOf(mesa)].Count);
    }

    /// <summary>
    /// Removes a specific order fromt he tables 
    /// </summary>
    /// <param name="order"> Order to remove </param>
    public void removeOrderFromTables(GameObject order)
    {
        //Search for the table that contains the givne order 
        int i = 0;
        while (i < pedidosAcumulados.Count)
        {
            if (pedidosAcumulados[i].Contains(order)) break;
            i++;
        }

        pedidosAcumulados[i].Remove(order);
        //Update the placement of the rest of orders stored in that same table
        for (int j = 0; j < pedidosAcumulados[i].Count; j++)
            pedidosAcumulados[i][j].transform.position = mesas[i].transform.position + (separacion * (1 + j));
    }
}