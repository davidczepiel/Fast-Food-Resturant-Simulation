using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentesManager : MonoBehaviour
{
    //Lista de menus personalizados que el player solicita
    public List<List<bool>> menusPersonalizados = new List<List<bool>>();

    //Prefab del menu que vamos a ofrecer
    public GameObject menuPrefab;

    //Prefab de los clientes que vamos a hacer spawn
    public GameObject clientePrefab;

    //Prefab de los cajeros que vamos a hacer spawn
    public GameObject cajeroPrefab;

    //Prefab de los cocineros que vamos a hacer spawn
    public GameObject cocineroPrefab;

    public UIManager uiManager;

    //Lista de elementos que va a tener el siguiente menu que vayamos a solicitar
    public List<bool> elementosSiguientePedido = new List<bool>();

    //Spawn de los clientes
    public Vector3 posSpwanCliente;

    //Spawn de los cajeros
    public Vector3 posSpwanCajero;

    //Spawn de los cocineros
    public Vector3 posSpwanCocinero;

    // Start is called before the first frame update
    private void Start()
    {
        elementosSiguientePedido.Add(false);
        elementosSiguientePedido.Add(false);
        elementosSiguientePedido.Add(false);
        elementosSiguientePedido.Add(false);
        uiManager.mostrarElementos(elementosSiguientePedido);
    }

    /// <summary>
    /// Se devuelve un gameObject que contiene un menu
    /// EN caso de que dispongamos de menus personalizados ofrecemos uno de estos
    /// en caso contrario creamos uno completo y lo devolvemos
    /// </summary>
    /// <returns>GameObject que contiene el menú solicitado</returns>
    public GameObject dameUnMenu()
    {
        //Generamos un menu
        GameObject nuevo = Instantiate(menuPrefab, new Vector3(0, 100, 0), Quaternion.identity);

        //Personalizamos el menu o hacemos uno completo
        List<bool> actual;
        if (menusPersonalizados.Count > 0)
        {
            actual = menusPersonalizados[0];
            menusPersonalizados.RemoveAt(0);
        }
        else
        {
            actual = new List<bool>();
            actual.Add(true);
            actual.Add(true);
            actual.Add(true);
            actual.Add(true);
        }
        Menu menu = nuevo.GetComponent<Menu>();
        for (int i = 0; i < actual.Count; i++)
        {
            if (actual[i]) menu.añadirItemAlPedido((MenuItem)i);
        }
        return nuevo;
    }

    /// <summary>
    /// Ajustamos un item determinado para que en el siguiente pedido que se solicite este item se ajuste a
    /// lo que el ususario ha indicado
    /// </summary>
    /// <param name="item"> Item que queremos añadir/quitar del siguiente menu</param>
    public void toggleMenuItem(int item)
    {
        elementosSiguientePedido[item] = !elementosSiguientePedido[item];
        uiManager.cambiarVisibilidadElemento((MenuItem)item);
    }

    /// <summary>
    /// Se genera un nuevo pedido con los datos que el jugador ha especificado a través de la UI
    /// Y se crea un cliente que vaya a solicitar dicho pedido
    /// </summary>
    public void generarCliente()
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

    /// <summary>
    /// Este método tiene como objetivo crear un nuevo cajero
    /// </summary>
    public void generarCajero()
    {
        Instantiate(cajeroPrefab, posSpwanCajero, Quaternion.identity);
    }

    /// <summary>
    /// Este método tiene como objetivo crear un nuevo cocinero
    /// </summary>
    public void generarCocinero()
    {
        Instantiate(cocineroPrefab, posSpwanCocinero, Quaternion.identity);
    }

    /// <summary>
    /// Se destruye el cliente que ha terminado su árbol de comportamiento
    /// </summary>
    /// <param name="cliente"> cliente que vamos a eliminar</param>
    public void clienteHaTerminado(GameObject cliente)
    {
        GameObject.Destroy(cliente);
    }
}