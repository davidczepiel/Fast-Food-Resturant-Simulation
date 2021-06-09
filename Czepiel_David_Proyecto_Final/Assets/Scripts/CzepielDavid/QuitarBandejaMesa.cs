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

    [TaskCategory("CzepielDavidProyectoFinal")]
    [TaskDescription("Rellenar")]
    public class QuitarBandejaMesa : Action
    {
        public SharedGameObject miMenu;
        public SharedGameObject miTarget;
        public SharedGameObject mesasPedidos;
        private MesaColocarPedido mesas;

        public override void OnStart()
        {
            mesas = mesasPedidos.Value.GetComponent<MesaColocarPedido>();
        }

        public override TaskStatus OnUpdate()
        {
            mesas.cogerPedido(miMenu.Value);
            return TaskStatus.Success;
        }
    }
}