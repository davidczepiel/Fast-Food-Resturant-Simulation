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
    public class IncluirItemMenu : Action
    {
        public SharedGameObject cajaManager;
        public SharedGameObject cocinaManager;
        public SharedGameObject miMenu;
        public SharedUInt itemCocinando;
        private CajaManager caja;
        private CocinaManager cocina;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
        }

        public override TaskStatus OnUpdate()
        {
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
}