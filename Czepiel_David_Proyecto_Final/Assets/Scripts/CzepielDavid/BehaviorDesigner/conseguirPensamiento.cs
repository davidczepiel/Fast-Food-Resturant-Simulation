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

    [TaskCategory("CzepielDavidProyectoFinal")]
    [TaskDescription("Rellenar")]
    public class conseguirPensamiento : Action
    {
        public SharedGameObject miPensamiento;

        public override void OnStart()
        {
        }

        public override TaskStatus OnUpdate()
        {
            miPensamiento.Value = this.gameObject.transform.Find("Pensamiento").gameObject;
            return TaskStatus.Success;
        }
    }
}