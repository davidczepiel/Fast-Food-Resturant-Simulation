using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cliente")]
[TaskDescription("Este task tiene como objetivo hacer que los clientes esperen de manera ordenada en una cola" +
    "Tiene un sistema de tickets que indica si el cliente le toca proseguir o avanza en la cola"
    )]
public class EsperarEnCola : Action
{
    //Ticket que me corresponde al empezar a esperar en la cola
    public SharedInt miTicket;

    //Lugar al que voy a ir una vez que me toque turno
    public SharedGameObject miTarget;

    //Posición de la cola que me corresponde mientras esté esperando
    public SharedVector3 miTargetVector;

    //manager que me va a indicar si me toca esperar, es mi turno etc
    public SharedGameObject lugaresManager;

    private LugaresDesgastablesManager lugares;
    private int pos;

    public override void OnStart()
    {
        //Me quedo con el manager y la posición en la cola que me corresponde con mi ticket
        lugares = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>();
        pos = lugares.getPositionInsideQueue(miTicket.Value);
    }

    public override TaskStatus OnUpdate()
    {
        //Si me toca proseguimos
        if (lugares.isItMyTurn(miTicket.Value))
        {
            GameObject lugar = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().getAvailablePlace();
            miTarget.Value = lugar;
            return TaskStatus.Success;
        }
        else
        {
            //Si no me toca compruebo la posición de la cola que le corresponde a mi ticket para ir avanzando en ella
            if (pos == lugares.getPositionInsideQueue(miTicket.Value))
            {
                return TaskStatus.Running;
            }
            else
            {
                miTargetVector.Value = lugares.getQueuePositionToWait(miTicket.Value);
                return TaskStatus.Failure;
            }
        }
    }
}