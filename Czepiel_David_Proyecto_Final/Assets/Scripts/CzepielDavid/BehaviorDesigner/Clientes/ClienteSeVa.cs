using System.Collections;
using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine.AI;

[TaskCategory("CzepielDavidProyectoFinal/Cliente")]
[TaskDescription("Este task tiene como objetivo sacar a un cliente determinado de la simulaión")]
public class ClienteSeVa : Action
{
    //Manager que me va a ayudar a salir de la simulación
    public SharedGameObject clientesManager;

    public override TaskStatus OnUpdate()
    {
        clientesManager.Value.GetComponent<AgentesManager>().clienteHaTerminado(this.gameObject);
        return TaskStatus.Success;
    }
}