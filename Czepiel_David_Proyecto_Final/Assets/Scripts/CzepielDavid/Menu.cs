using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuItem { Hamburguesa, Patatas, Bebida, Helado };

public class Menu : MonoBehaviour
{
    //Lista de objetos que representan los elementos del menu
    public List<GameObject> misCosas;

    //Lista de elementos que el menu tiene completados
    private List<bool> elementosMenu = new List<bool>() { false, false, false, false };

    //Lista de elementos que el menu tiene haciendose
    private List<bool> elementosHaciendose = new List<bool>() { false, false, false, false };

    //Lista de elementos que el menu requiere
    private List<bool> pedido = new List<bool>() { false, false, false, false };

    private int ordenComer = 0;

    //Bool que indica si un pedido esta listo
    private bool listo = false;

    //Bool que indica si un pedido ha sido recogido
    private bool recogido = false;

    private void Start()
    {
        for (int i = 0; i < misCosas.Count; i++)
        {
            misCosas[i].SetActive(false);
        }
    }

    /// <summary>
    /// Este metodo sirve para incluir algún item concreto a los que el menu va a necesitar
    /// </summary>
    /// <param name="item">item que añadimos al menu</param>
    public void añadirItemAlPedido(MenuItem item)
    {
        pedido[(int)item] = true;
    }

    /// <summary>
    /// Metodo que sirve para comprobar si un item está hecho o en proceso
    /// </summary>
    /// <param name="item">item a comprobar</param>
    /// <returns>bool que indica lo que se ha solicitado</returns>
    public bool itemHecho(MenuItem item)
    {
        return elementosMenu[(int)item] || elementosHaciendose[(int)item];
    }

    /// <summary>
    /// Metodo que sirve para preguntar si un menu ya tiene todos los elementos de la cocina que necesita completados
    /// </summary>
    /// <returns>bool que indica si ha completado su parte de la cocina</returns>
    public bool cocinaTerminado()
    {
        bool cierto = true;
        if (!elementosMenu[0] && pedido[0])
            cierto = false;
        if (!elementosMenu[1] && pedido[1])
            cierto = false;

        return cierto;
    }

    /// <summary>
    /// Metodo que sirve para comprobar si un menú necesita de un item concreto para ser completado
    /// </summary>
    /// <param name="item">item que preguntar</param>
    /// <returns>bool que indica si lo necesita o no</returns>
    public bool menuRequiereItem(MenuItem item)
    {
        return pedido[(int)item];
    }

    /// <summary>
    /// Metodo que srve para indicar que vamos a comenzar a hacer un item concreto
    /// </summary>
    /// <param name="item">item que hemos compenzar a preparar</param>
    public void empezarHacerItem(MenuItem item)
    {
        elementosHaciendose[(int)item] = true;
    }

    /// <summary>
    /// Metodo que sirve para indicar que un item determinado ha sido completado
    /// </summary>
    /// <param name="item">item que hemos completado</param>
    public void itemMenuCompletado(MenuItem item)
    {
        elementosMenu[(int)item] = true;
        misCosas[(int)item].SetActive(true);
    }

    /// <summary>
    /// Metodo que sirve para comprobar si un menu tiene todos los items que necesita y ha sido completado
    /// </summary>
    /// <returns>bool de si ha sido completado o no</returns>
    public bool menuCompletado()
    {
        int i = 0;
        while (i < pedido.Count && pedido[i] == elementosMenu[i]) i++;

        return i >= pedido.Count;
    }

    /// <summary>
    /// Metodo que eestablece un valor a la variable listo
    /// </summary>
    /// <param name="a">valor a establecer</param>
    public void setListo(bool a)
    {
        listo = a;
    }

    /// <summary>
    /// Metodo para recibir el valor de la variable listo
    /// </summary>
    /// <returns>valor de la variable</returns>
    public bool getListo()
    {
        return listo;
    }

    /// <summary>
    /// Metodo que eestablece un valor a la variable recogido
    /// </summary>
    /// <param name="a">valor a establecer</param>
    public void setRecogido(bool a)
    {
        recogido = a;
    }

    /// <summary>
    /// Metodo para recibir el valor de la variable listo
    /// </summary>
    /// <returns>valor de la variable</returns>
    public bool getRecogido()
    {
        return recogido;
    }

    /// <summary>
    /// Metodo que sirve para determinar si un pedido ha sido comido por completo
    /// </summary>
    /// <returns>Bool que indica si ha sido comido por completo</returns>
    public bool comer()
    {
        while (ordenComer < elementosMenu.Count && !elementosMenu[ordenComer]) ordenComer++;
        if (ordenComer < elementosMenu.Count) elementosMenu[ordenComer] = false;

        ordenComer++;
        return ordenComer >= elementosMenu.Count;
    }
}