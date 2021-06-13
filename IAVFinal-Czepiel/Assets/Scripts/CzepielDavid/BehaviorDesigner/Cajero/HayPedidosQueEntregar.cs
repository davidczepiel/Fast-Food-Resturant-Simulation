using System.Collections;
using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine.AI;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Esta condición sirve para comprobar si hay algún pedido que necesite ser entregado por un cajero")]
public class HayPedidoQueEntregar : Conditional
{
    //Manager de la caja al que voy a preguntar por cosas relacionadas con los pedidos
    public SharedGameObject cajaManager;

    //Variable en la que voy a almacenar un posible pedido que necesite ser entregado por un cajero
    public SharedGameObject miPedido;

    private CajaManager caja;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        //Si hay algún pedido que necesite ser entregado me lo quedo
        if (caja.hayPedidosParaRecoger())
        {
            miPedido.Value = caja.damePedidoPorEntregar();
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Failure;
    }
}