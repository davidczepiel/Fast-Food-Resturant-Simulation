﻿using System.Collections;
using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine.AI;

[TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
[TaskDescription("Este task tiene como objetivo quitar un menu de la cocina porque ya no tenga nada que hacer allí  \n" +
    "y dárselo a los cajeros, este menú será almacenado en la lista de pedidos por completar o por entregar dependiendo de" +
    "se después de que los cocineros hayan acabado necesita más cosas o ya está listo el menú")]
public class PedidoParteCocinaTerminado : Action
{
    //Caja manager al que le voy a dar un menú que sale de la cocina
    public SharedGameObject cajaManager;

    //Cocina manager del que va a salir un menú
    public SharedGameObject cocinaManager;

    //menú que un cociner ha terminado de trabajar en la cocina
    public SharedGameObject miMenu;

    private CajaManager caja;
    private CocinaManager cocina;
    private Menu menu;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
        cocina = cocinaManager.Value.GetComponent<CocinaManager>();
        menu = miMenu.Value.GetComponent<Menu>();
    }

    public override TaskStatus OnUpdate()
    {
        //Se quita de la lista de cosas haciendose
        cocina.quitarPedido(miMenu.Value);

        //Se mete en una lista u otra
        if (menu.menuCompletado())
            caja.añadirPedidoPorRegoger(miMenu.Value);
        else
            caja.añadirPedidoPorCompletar(miMenu.Value);

        miMenu.Value = null;
        return TaskStatus.Success;
    }
}