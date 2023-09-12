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

    public TextoAereo textoUsosRestantes;

    public Vector3 desplazamientoTextoAereo = new Vector3(0, 2.5f, 0);

    private List<TextoAereo> textosUsosRestantes = new List<TextoAereo>();

    private List<bool> ocuppiedPlaces = new List<bool>();
    private List<bool> reparablePlaces = new List<bool>();
    private List<int> usesLeft = new List<int>();

    //Timers de cada uno de los lugares para que se reparen solos
    private List<float> timerRepararSolos = new List<float>();

    private int nextTicket = 0;
    private int currenTurnTicketNumber = 0;

    private void Start()
    {
        //Each place is set to available and fully functional 
        for (int i = 0; i < lugares.Count; i++)
        {
            ocuppiedPlaces.Add(false);
            reparablePlaces.Add(false);
            usesLeft.Add(usosHastaDesgaste);
            timerRepararSolos.Add(tiempoRepararSolo);
            textosUsosRestantes.Add(Instantiate(textoUsosRestantes, lugares[i].transform.position + desplazamientoTextoAereo, Quaternion.identity));
        }

        for (int i = 0; i < textosUsosRestantes.Count; i++)
            textosUsosRestantes[i].ponerTexto(usesLeft[i].ToString());
    }

    private void Update()
    {
        //Se recorren aquellos lugares que estén tanto reparandose como ocupados y si el timer expira se reparan solos
        //Debido a que esto singnifica que ha habido un bloqueo
        float tiempo = Time.deltaTime;
        for (int i = 0; i < timerRepararSolos.Count; i++)
        {
            if (reparablePlaces[i] && ocuppiedPlaces[i])
            {
                timerRepararSolos[i] -= tiempo;
                if (timerRepararSolos[i] <= 0)
                {
                    timerRepararSolos[i] = tiempoRepararSolo;
                    reparablePlaces[i] = false;
                    ocuppiedPlaces[i] = false;
                }
            }
        }
    }

    /// <summary>
    /// Returns whether any place is currently available or not
    /// </summary>
    /// <returns> True if there is at least one available place, false otherwise </returns>
    public bool isThereAnyAvailablePlace()
    {
        int i = 0;
        while (i < ocuppiedPlaces.Count && (ocuppiedPlaces[i] || reparablePlaces[i]))
            i++;
        return i < ocuppiedPlaces.Count;
    }

    /// <summary>
    /// Returns the first available place
    /// </summary>
    /// <returns> Place for the agent to go to </returns>
    public GameObject getAvailablePlace()
    {
        int i = 0;
        while (i < ocuppiedPlaces.Count && (ocuppiedPlaces[i] || reparablePlaces[i])) i++;

        ocuppiedPlaces[i] = true;
        usesLeft[i] -= 1;

        return lugares[i];
    }

    /// <summary>
    /// Leave a place free for another agent to use/interact with
    /// </summary>
    /// <param name="libre"> Place that an agent is leaving </param>
    public void leavePlace(GameObject libre)
    {
        int result = lugares.FindIndex(element => element == libre);
        ocuppiedPlaces[result] = false;
        textosUsosRestantes[result].GetComponent<TextoAereo>().ponerTexto(usesLeft[result].ToString());
        //Is the place is no longer available set it as reparable
        if (usesLeft[result] <= 0)
            reparablePlaces[result] = true;
    }

    /// <summary>
    /// Gives an agent its position in the queue for using any of the available places
    /// </summary>
    /// <returns> Ticket number for the agent </returns>
    public int getQueueTicket()
    {
        return nextTicket++;
    }

    /// <summary>
    /// Returns the position inside the queue given the next turn's ticket number
    /// </summary>
    /// <param name="clientTicketnumber"> </param>
    /// <returns> Position inside the queue </returns>
    public int getPositionInsideQueue(int clientTicketnumber)
    {
        return clientTicketnumber - currenTurnTicketNumber;
    }

    /// <summary>
    /// Returns whether its an agents turn to use any of the available places or not
    /// </summary>
    /// <param name="clientTicketNumber"> Ticket number of the client that is asking </param>
    /// <returns> True if it's this client's turn, false otherwise </returns>
    public bool isItMyTurn(int clientTicketNumber)
    {
        if (clientTicketNumber == currenTurnTicketNumber && isThereAnyAvailablePlace())
        {
            currenTurnTicketNumber++;
            return true;
        }
        else return false;
    }

    /// <summary>
    /// Returns a world position inside the queue for the agent to wait at
    /// </summary>
    /// <returns> Position where the agent should wait for his turn </returns>
    public Vector3 getQueuePositionToWait(int turnoCliente)
    {
        int displacementAmount = turnoCliente - currenTurnTicketNumber;
        Vector3 finalPos = lugarEmpiezaCola.transform.position;
        finalPos += (desplazamiento * displacementAmount);
        return finalPos;
    }

    /// <summary>
    /// Returns whether any of the available places needs a repair or not
    /// </summary>
    /// <returns> True if any of the places needs a repair, false otherwise </returns>
    public bool isThereAnyPlaceToRepair()
    {
        int i = 0;
        while (i < lugares.Count && (!reparablePlaces[i] || (reparablePlaces[i] && ocuppiedPlaces[i])))
            i++;
        return i < lugares.Count;
    }

    /// <summary>
    /// Returns the first place that needs a repair 
    /// </summary>
    /// <returns> Place to repair </returns>
    public GameObject getPlaceToRepair()
    {
        int i = 0;
        while (i < lugares.Count && (!reparablePlaces[i] || (reparablePlaces[i] && ocuppiedPlaces[i])))
            i++;

        reparablePlaces[i] = true;
        ocuppiedPlaces[i] = true;
        return lugares[i];
    }

    /// <summary>
    /// Repairs a given place and leaves it available for the customers to use 
    /// </summary>
    /// <param name="repairedPlace"> Place that was just repaired </param>
    public void repairPlace(GameObject repairedPlace)
    {
        int result = lugares.FindIndex(element => element == repairedPlace);
        //Si no ha dado error reparamos
        if (result >= 0)
        {
            ocuppiedPlaces[result] = false;
            reparablePlaces[result] = false;
            usesLeft[result] = usosHastaDesgaste;
            textosUsosRestantes[result].GetComponent<TextoAereo>().ponerTexto(usesLeft[result].ToString());
        }
    }
}