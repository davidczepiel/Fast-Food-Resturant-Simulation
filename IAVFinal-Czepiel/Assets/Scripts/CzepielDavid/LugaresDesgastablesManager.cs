using System.Collections.Generic;
using UnityEngine;


public class LugaresDesgastablesManager : MonoBehaviour
{
    //Lista de lugares que vamos a controlar
    public List<GameObject> lugares = new List<GameObject>();

    //Tiempo que tardan en repararse solos en caso de bloqueo
    public float tiempoRepararSolo = 20;

    //Usos hasta romper uno de los lugares
    public int usosHastaDesgaste = 1;

    //Lugar en el que empieza a formarse una cola
    public GameObject lugarEmpiezaCola;

    //Desplazamiento entre clientes que esten en la cola
    public Vector3 desplazamiento;

    public GameObject textoUsosRestantes;

    public Vector3 desplazamientoTextoAereo = new Vector3(0, 2.5f, 0);

    private List<GameObject> textosUsosRestantes = new List<GameObject>();

    //Lista de lugares ocupados
    private List<bool> ocupados = new List<bool>();

    //Lista de lugares que necesitan ser reparados
    private List<bool> reparrables = new List<bool>();

    //Lista que contiene los usos restantes de cada uno de estos lugares
    private List<int> usosRestantes = new List<int>();

    //Timers de cada uno de los lugares para que se reparen solos
    private List<float> timerRepararSolos = new List<float>();

    //Ticket que se le ofrece al próximo agente que llega a la cola
    private int ticketActual = 0;

    //Ticket que le toca avanzar
    private int turno = 0;

    private void Start()
    {
        for (int i = 0; i < lugares.Count; i++)
        {
            ocupados.Add(false);
            reparrables.Add(false);
            usosRestantes.Add(usosHastaDesgaste);
            timerRepararSolos.Add(tiempoRepararSolo);
            textosUsosRestantes.Add(Instantiate(textoUsosRestantes, lugares[i].transform.position + desplazamientoTextoAereo, Quaternion.identity));
        }

        for (int i = 0; i < textosUsosRestantes.Count; i++)
        {
            textosUsosRestantes[i].GetComponent<TextoAereo>().ponerTexto(usosRestantes[i].ToString());
        }
    }

    private void Update()
    {
        //Se recorren aquellos lugares que estén tanto reparandose como ocupados y si el timer expira se reparan solos
        //Debido a que esto singnifica que ha habido un bloqueo
        float tiempo = Time.deltaTime;
        for (int i = 0; i < timerRepararSolos.Count; i++)
        {
            if (reparrables[i] && ocupados[i])
            {
                timerRepararSolos[i] -= tiempo;
                if (timerRepararSolos[i] <= 0)
                {
                    timerRepararSolos[i] = tiempoRepararSolo;
                    reparrables[i] = false;
                    ocupados[i] = false;
                }
            }
        }
    }

    /// <summary>
    /// Devuelve el lugar al que le toca ir al siguiente agente que sale de la cola
    /// </summary>
    /// <returns>Lugar al que el agente debe ir</returns>
    public GameObject dameLugarAlQueIr()
    {
        int i = 0;
        while (i < ocupados.Count && (ocupados[i] || reparrables[i])) i++;

        ocupados[i] = true;
        usosRestantes[i] -= 1;

        return lugares[i];
    }

    /// <summary>
    /// Devuelve el lugar al que le toca ir al siguiente agente en la cola
    /// </summary>
    /// <returns>Lugar al que el agente debe ir</returns>
    public Vector3 damePosicionColaALaQueIr(int turnoCliente)
    {
        int cantidadDesplazar = turnoCliente - turno;
        Vector3 pos = lugarEmpiezaCola.transform.position;
        pos += (desplazamiento * cantidadDesplazar);
        return pos;
    }

    /// <summary>
    /// Devuelve si hay algún lugar que necesite ser reparado
    /// </summary>
    /// <returns>Bool necesidad reparar algo</returns>
    public bool hayLugarQueArreglar()
    {
        int i = 0;
        while (i < lugares.Count && (!reparrables[i] || (reparrables[i] && ocupados[i])))
            i++;

        return i < lugares.Count;
    }

    /// <summary>
    /// Devuelve el objeto que representa el lugar que necesita ser reparado
    /// </summary>
    /// <returns>objeto a reparar</returns>
    public GameObject dameLugarQueArreglar()
    {
        int i = 0;
        while (i < lugares.Count && (!reparrables[i] || (reparrables[i] && ocupados[i])))
            i++;

        reparrables[i] = true;
        ocupados[i] = true;
        return lugares[i];
    }

    /// <summary>
    /// Devuelve la posicion del objeto que representa el lugar que necesita ser reparado
    /// </summary>
    /// <returns>posicion del objeto a reparar</returns>
    public Vector3 dameLugarParaArreglarVector()
    {
        return dameLugarQueArreglar().transform.position;
    }

    /// <summary>
    /// Un agente deja libre uno de los lugares que estaba ocupando
    /// En caso de que ese lugar ya no le queden usos queda marcado como que necesita reparaciones
    /// </summary>
    /// <param name="libre">lugar liberado</param>
    public void dejarLibreLugar(GameObject libre)
    {
        int result = lugares.FindIndex(element => element == libre);
        ocupados[result] = false;
        textosUsosRestantes[result].GetComponent<TextoAereo>().ponerTexto(usosRestantes[result].ToString());
        if (usosRestantes[result] <= 0)
            reparrables[result] = true;
    }

    /// <summary>
    /// Se repara un lugar especificado
    /// </summary>
    /// <param name="libre">GameObject que se ha reparado</param>
    public void repararLugar(GameObject libre)
    {
        int result = lugares.FindIndex(element => element == libre);
        //Si no ha dado error reparamos
        if (result >= 0)
        {
            ocupados[result] = false;
            reparrables[result] = false;
            usosRestantes[result] = usosHastaDesgaste;
            textosUsosRestantes[result].GetComponent<TextoAereo>().ponerTexto(usosRestantes[result].ToString());
        }
    }

    /// <summary>
    /// Devuelve si hay algún lugar al que un agente pueda proceder a usar
    /// </summary>
    /// <returns>bool de si hay lugares libres</returns>
    public bool hayLugarLibre()
    {
        int i = 0;
        while (i < ocupados.Count && (ocupados[i] || reparrables[i]))
        {
            i++;
        }
        return i < ocupados.Count;
    }

    /// <summary>
    /// Devuelve si un ticket determinado es el siguiente al que le toca y hay huecos
    /// </summary>
    /// <param name="turnoEsperando"></param>
    /// <returns></returns>
    public bool meToca(int turnoEsperando)
    {
        if (turnoEsperando == turno && hayLugarLibre())
        {
            turno++;
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// Devuelve el siguiente ticket disponible
    /// </summary>
    /// <returns>numero de ticket</returns>
    public int dameTicket()
    {
        return ticketActual++;
    }

    /// <summary>
    /// Devuelve la posición dentro de la cola que le corresponde a un ticket determinado
    /// </summary>
    /// <param name="ticketCliente"></param>
    /// <returns>posición en la cola</returns>
    public int damePosicionDentroCola(int ticketCliente)
    {
        return ticketCliente - turno;
    }
}