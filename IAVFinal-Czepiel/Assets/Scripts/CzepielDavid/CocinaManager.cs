using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocinaManager : MonoBehaviour
{
    //Padre de las zonas en las que se cocinan hamburguesas
    public GameObject padreLugaresHacerHamburguesa;

    //zonas en las que se cocinan hamburguesas
    public List<GameObject> lugaresHacerHamburguesas = new List<GameObject>();

    //Padre de las zonas en las que se cocinan Patatas
    public GameObject padreLugaresHacerPatatas;

    //zonas en las que se cocinan patatas
    public List<GameObject> lugaresHacerPatatas = new List<GameObject>();

    //Padre de las zonas en las que se cocinan bebidas
    public GameObject padreLugaresHacerBebida;

    //zonas en las que se cocinan bebidas
    public List<GameObject> lugaresHacerBebidas = new List<GameObject>();

    //Padre de las zonas en las que se cocinan helado
    public GameObject padreLugaresHacerHelado;

    //zonas en las que se cocinan helado
    public List<GameObject> lugaresHacerHelados = new List<GameObject>();

    //pedidos que se estan cocinando en cada momento
    public List<GameObject> pedidosHaciendose = new List<GameObject>();

    private void Start()
    {
        Transform[] allChildren = padreLugaresHacerHamburguesa.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            lugaresHacerHamburguesas.Add(child.gameObject);
        }
        //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
        lugaresHacerHamburguesas.RemoveAt(0);

        allChildren = padreLugaresHacerPatatas.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            lugaresHacerPatatas.Add(child.gameObject);
        }
        //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
        lugaresHacerPatatas.RemoveAt(0);

        allChildren = padreLugaresHacerBebida.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            lugaresHacerBebidas.Add(child.gameObject);
        }
        //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
        lugaresHacerBebidas.RemoveAt(0);

        allChildren = padreLugaresHacerHelado.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            lugaresHacerHelados.Add(child.gameObject);
        }
        //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
        lugaresHacerHelados.RemoveAt(0);
    }

    /// <summary>
    /// Devuelve un lugar concreto en el que se pueda cocinar un item determinado
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public GameObject dameLugarHacerItem(MenuItem item)
    {
        switch (item)
        {
            case MenuItem.Hamburguesa:
                return dameLugarAleatorio(lugaresHacerHamburguesas);
                break;

            case MenuItem.Patatas:
                return dameLugarAleatorio(lugaresHacerPatatas);
                break;

            case MenuItem.Bebida:
                return dameLugarAleatorio(lugaresHacerBebidas);
                break;

            case MenuItem.Helado:
                return dameLugarAleatorio(lugaresHacerHelados);
                break;

            default:
                return null;
                break;
        }
    }

    /// <summary>
    /// Metodo que devuelve una entrada aleatoria de una lista dada
    /// </summary>
    /// <param name="lugares">lista de lugares disponibles</param>
    /// <returns>lugar aleatorio sacado de la lista</returns>
    private GameObject dameLugarAleatorio(List<GameObject> lugares)
    {
        int i = Random.Range(0, lugares.Count - 1);
        return lugares[i];
    }

    /// <summary>
    /// Metodo que sirve para indicar que un nuevo menu se va a empezar a cocinar
    /// </summary>
    /// <param name="nuevo">nuevo menu a cocinar</param>
    public void empezarPedido(GameObject nuevo)
    {
        if (!pedidosHaciendose.Contains(nuevo))
            pedidosHaciendose.Add(nuevo);
    }

    /// <summary>
    /// Metodo que sirve para sacar un menu determinado de a lista de menus que se estan haciendo
    /// </summary>
    /// <param name="pedido">menu que vamos a quitar</param>
    public void quitarPedido(GameObject pedido)
    {
        if (pedidosHaciendose.Contains(pedido))
            pedidosHaciendose.Remove(pedido);
    }

    /// <summary>
    /// Metodo para informar de si hay pedidos haciendose en este momento
    /// </summary>
    /// <returns>bool que indica si hay pedidos asi</returns>
    public bool hayPedidosHaciendose()
    {
        return pedidosHaciendose.Count > 0;
    }

    /// <summary>
    /// Metodo que devuelve un pedido en el que haya alguno de los elementos que se ofrece que todavía no se haya hecho
    /// ni se esté haciendo.
    /// EN caso de que no exista se devuelve null
    /// </summary>
    /// <param name="posiblesElementos">posibles items a tener en cuenta</param>
    /// <returns>Pedido en el que ayudar o null</returns>
    public GameObject damePedidoEnElQueAyudar(List<int> posiblesElementos)
    {
        GameObject pedido = null;
        int i = 0;
        bool bucle = true;
        while (i < pedidosHaciendose.Count && bucle)
        {
            GameObject actual = pedidosHaciendose[i];
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

    /// <summary>
    /// Metodo que devuelve un menu que haya terminado su parte en la cocina o null en caso de que no exista
    /// </summary>
    /// <returns>Menu que ha terminado o null</returns>
    public GameObject pedidoTerminadoParteCocina()
    {
        GameObject pedido = null;

        int i = 0;
        bool bucle = true;
        while (i < pedidosHaciendose.Count && bucle)
        {
            GameObject actual = pedidosHaciendose[i];
            Menu menu = actual.GetComponent<Menu>();
            if (menu.cocinaTerminado())
            {
                pedido = actual;
                bucle = false;
            }
            i++;
        }
        return pedido;
    }
}