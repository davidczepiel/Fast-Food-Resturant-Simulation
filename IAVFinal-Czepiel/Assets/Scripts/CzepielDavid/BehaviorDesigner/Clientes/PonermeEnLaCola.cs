﻿using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cliente")]
[TaskDescription("Este task tiene como objetivo analizar la cola que lleva al destino que el agente busca para " +
    "determinar si debe ponerse en la cola o puede directamente ir a donde desea")]
public class PonermeEnLaCola : Action
{
    //Variable que indica la posición de cola que me corresponde
    public SharedInt miPosicionCola;

    //Variable que indica el lugar al que debo dirigirme
    public SharedGameObject miTarget;

    //Variable que indica la posición dentro de la cola que me corresponde
    public SharedVector3 miTargetVector;

    //Manager que administra la cola
    public SharedGameObject lugaresManager;

    public override void OnStart()
    {
        miPosicionCola.Value = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().getQueueTicket();
    }

    public override TaskStatus OnUpdate()
    {
        //Si puedo pasar directamente al lugar que deseo voy
        if (lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().isItMyTurn(miPosicionCola.Value))
        {
            GameObject lugar = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().getAvailablePlace();
            miTarget.Value = lugar;
            return TaskStatus.Success;
        }
        //Sino me pongo en la cola
        else
        {
            miTargetVector.Value = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().getQueuePositionToWait(miPosicionCola.Value);
            return TaskStatus.Failure;
        }
    }
}