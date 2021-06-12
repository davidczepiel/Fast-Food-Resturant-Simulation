using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaManager : MonoBehaviour
{
    //Lista de pedidos que se pueden completar por los cajeros
    private List<GameObject> pedidosParaCompletar = new List<GameObject>();

    //Lista de pedidos que pueden ser entregados
    private List<GameObject> pedidosParaRecoger = new List<GameObject>();

    //Lista e pedidos que todavía no se han empezado
    private List<GameObject> pedidosParaEmpezar = new List<GameObject>();

    //Lista de bool que representa si una caja está atendidapor un agente
    private List<bool> cajaAtendida = new List<bool>();

    //Lista de bool que representa si una caja está ocupada por un cliente
    private List<bool> clienteEnCaja = new List<bool>();

    //Lista de bool que representa si una caja está controlada por un cajero
    private List<bool> cajaControlada = new List<bool>();

    private void Start()
    {
        Transform[] allChildren = this.gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            cajaAtendida.Add(false);
            clienteEnCaja.Add(false);
            cajaControlada.Add(false);
        }
        cajaAtendida.RemoveAt(0);
        clienteEnCaja.RemoveAt(0);
        cajaControlada.RemoveAt(0);
    }

    /// <summary>
    /// Metodo que informa de si hay pedidos por empezar
    /// </summary>
    /// <returns>bool que informa de lo solicitado</returns>
    public bool hayPedidosParaEmpezar()
    {
        return pedidosParaEmpezar.Count > 0;
    }

    /// <summary>
    /// Metodo que informa de si hay pedidos por completar
    /// </summary>
    /// <returns>bool que informa de lo solicitado</returns>
    public bool hayPedidosParaCompletar()
    {
        return pedidosParaCompletar.Count > 0;
    }

    /// <summary>
    /// Metodo que informa de si hay pedidos por recoger
    /// </summary>
    /// <returns>bool que informa de lo solicitado</returns>
    public bool hayPedidosParaRecoger()
    {
        return pedidosParaRecoger.Count > 0;
    }

    /// <summary>
    /// Metodo que añade un pedido a la lista de pedidos por completar
    /// </summary>
    public void añadirPedidoPorCompletar(GameObject pedido)
    {
        if (!pedidosParaCompletar.Contains(pedido))
            pedidosParaCompletar.Add(pedido);
    }

    /// <summary>
    /// Metodo que añade un pedido a la lista de pedidos por recoger
    /// </summary>
    public void añadirPedidoPorRegoger(GameObject pedido)
    {
        if (!pedidosParaRecoger.Contains(pedido))
            pedidosParaRecoger.Add(pedido);
    }

    /// <summary>
    /// Metodo que elimina un pedido a la lista de pedidos por completar
    /// </summary>
    public void eliminarPedidoPorCompletar(GameObject pedido)
    {
        if (pedidosParaCompletar.Contains(pedido))
            pedidosParaCompletar.Remove(pedido);
    }

    /// <summary>
    /// Metodo que devuelve uno de los pedidos por empezar
    /// </summary>
    /// <returns>pedido solicitado</returns>
    public GameObject damePedidoPorEmpezar()
    {
        GameObject nuevo = pedidosParaEmpezar[0];
        pedidosParaEmpezar.RemoveAt(0);
        return nuevo;
    }

    /// <summary>
    /// Metodo que devuelve uno de los pedidos por completar
    /// </summary>
    /// <returns>pedido solicitado</returns>
    public GameObject damePedidoPorCompletar()
    {
        GameObject nuevo = pedidosParaCompletar[0];
        pedidosParaCompletar.RemoveAt(0);
        return nuevo;
    }

    /// <summary>
    /// Metodo que devuelve uno de los pedidos por entregar
    /// </summary>
    /// <returns>pedido solicitado</returns>
    public GameObject damePedidoPorEntregar()
    {
        GameObject nuevo = pedidosParaRecoger[0];
        pedidosParaRecoger.RemoveAt(0);
        return nuevo;
    }

    /// <summary>
    /// Metodo que informa de si hay algun cliente esperando en la caja y todavía no ha sido atendido
    /// </summary>
    /// <returns>bool que informa de lo solicitado</returns>
    public bool hayClientesEnColaParaPedir()
    {
        int i = 0;
        while (i < clienteEnCaja.Count && (!clienteEnCaja[i] || (clienteEnCaja[i] && cajaControlada[i])))
            i++;
        return i < clienteEnCaja.Count;
    }

    /// <summary>
    /// Metodo que devuelve el número de una caja en la que se encuentre un cliente que todavía no ha sido atendido
    /// </summary>
    /// <returns>numero de caja en cuestión</returns>
    public int dameNumeroDeCajaQueAtender()
    {
        int i = 0;
        while (i < clienteEnCaja.Count && (!clienteEnCaja[i] || (clienteEnCaja[i] && cajaControlada[i])))
            i++;
        cajaControlada[i] = true;
        return i;
    }

    /// <summary>
    /// Metodo que sirve para indicar que una caja en la que se encuentra un cliente está siendo atendida
    /// </summary>
    /// <param name="numCaja">numero de la caja que vamos a atender</param>
    public void atenderClienteEnCaja(int numCaja)
    {
        cajaAtendida[numCaja] = true;
    }

    /// <summary>
    /// Este método sirve para que un cliente reciba una caja en la que pueda ser atendido
    /// </summary>
    /// <returns>numero de caja que le toca al cliente</returns>
    public int dameCajaParaQueMeAtiendan()
    {
        int i = 0;
        while (clienteEnCaja[i]) i++;
        clienteEnCaja[i] = true;
        return i;
    }

    /// <summary>
    /// Método que sirve para comprobar si una caja ha sido atendida o no
    /// </summary>
    /// <param name="numCaja">número de caja a comprobar</param>
    /// <returns>bool que indica si ha sido atendida o no</returns>
    public bool meHanAtendido(int numCaja)
    {
        return cajaAtendida[numCaja];
    }

    /// <summary>
    /// Método que sirve para realizar un pedido y liberar la caja en la que un cliente ha sido atendido
    /// </summary>
    /// <param name="numCaja">numero de caja a liberar</param>
    /// <param name="pedidoNuevo">pedido a hacer</param>
    public void hacerPedido(int numCaja, GameObject pedidoNuevo)
    {
        pedidosParaEmpezar.Add(pedidoNuevo);
        clienteEnCaja[numCaja] = false;
        cajaAtendida[numCaja] = false;
        cajaControlada[numCaja] = false;
    }

    /// <summary>
    /// Este método sirve para que un cajero pueda pillar un pedido en el que pueda ayudar a completar alguno
    /// de los elementos que requiera.En caso de que no exista tal pedido se devuelve null
    /// </summary>
    /// <param name="posiblesElementos">posibles items en los que se puedeayudar</param>
    /// <returns>posible pedido en el que se puede ayudar</returns>
    public GameObject damePedidoEnElQueAyudar(List<int> posiblesElementos)
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
                if (menu.menuRequiereItem((MenuItem)posiblesElementos[j]) && !menu.itemHecho((MenuItem)posiblesElementos[j]))
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
}