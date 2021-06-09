namespace UCM.IAV.Movimiento
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
    public class TirarPedidoBasura : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject miPedido;

        public override TaskStatus OnUpdate()
        {
            GameObject.Destroy(miPedido.Value);
            return TaskStatus.Success;
        }
    }
}