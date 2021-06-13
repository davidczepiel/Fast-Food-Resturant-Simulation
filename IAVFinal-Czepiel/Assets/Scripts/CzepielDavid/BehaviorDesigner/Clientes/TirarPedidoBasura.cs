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
[TaskDescription("Este task tiene como objetivo eliminar el pedido que un cliente tiene en brazos")]
public class TirarPedidoBasura : Action
{
    //Pedido que voy a tirar
    public SharedGameObject miPedido;

    public override TaskStatus OnUpdate()
    {
        GameObject.Destroy(miPedido.Value);
        return TaskStatus.Success;
    }
}