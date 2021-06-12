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
[TaskDescription("Esta condición tiene como objetivo comprobar si hay clientes en alguna de las cajas esperando\n" +
    "En caso de que haya algún cliente, pregunto por la caja en la que se encuentra y me la quedo para ir a atenderle")]
public class HayClientesCola : Conditional
{
    public SharedGameObject cajaManager;
    private CajaManager caja;
    public SharedInt numCaja;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        //Si hay alguna caja con clientes que atender me quedo su número para ir a atender
        if (caja.hayClientesEnColaParaPedir())
        {
            numCaja.Value = caja.dameNumeroDeCajaQueAtender();
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Failure;
    }
}