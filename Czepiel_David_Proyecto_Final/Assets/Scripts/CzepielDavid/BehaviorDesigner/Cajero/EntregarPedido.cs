﻿namespace UCM.IAV.Movimiento
{
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
    [TaskDescription("Rellenar")]
    public class EntregarPedido : Action
    {
        public SharedGameObject cajaManager;
        public SharedGameObject miPedido;
        private CajaManager caja;
        private Menu menu;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
            menu = miPedido.Value.GetComponent<Menu>();
            menu.setListo(true);
        }

        public override TaskStatus OnUpdate()
        {
            if (menu.getRecogido())
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}