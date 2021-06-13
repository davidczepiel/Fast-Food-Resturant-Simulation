﻿using System.Collections;
using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine.AI;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Este task tiene como objetivo incluir un elemento que esté cocinado en un menu que tengamos")]
public class IncluirItemMenu : Action
{
    //Caja a la que le voy a informar sobre el pedido que estoy completando
    public SharedGameObject cajaManager;

    //Variable que contiene el menu que estoy completando
    public SharedGameObject miMenu;

    //Elemento que estoy añadiendo al menú
    public SharedUInt itemCocinando;

    private CajaManager caja;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        //Añado el item al menu y pregunto si está completado, en cuyo caso le indico a la caja que lo incorpore a la lista de pedidos por entregar
        miMenu.Value.GetComponent<Menu>().itemMenuCompletado((MenuItem)itemCocinando.Value);
        if (miMenu.Value.GetComponent<Menu>().menuCompletado())
        {
            caja.añadirPedidoPorRegoger(miMenu.Value);
            caja.eliminarPedidoPorCompletar(miMenu.Value);
            miMenu.Value = null;
        }
        return TaskStatus.Success;
    }
}