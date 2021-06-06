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

    [TaskCategory("CzepielDavidProyectoFinal/Cliente")]
    [TaskDescription("Rellenar")]
    public class LiberarLugar : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject miPedido;

        public SharedGameObject miTarget;
        public SharedGameObject lugaresManager;

        public override void OnStart()
        {
            //lugaresManager = GlobalVariables.Instance.GetVariable("PapelerasManager").ConvertTo<SharedGameObject>().Value;
        }

        public override TaskStatus OnUpdate()
        {
            lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().liberarLugar(miTarget.Value);
            return TaskStatus.Success;
        }
    }
}