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

    [TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
    [TaskDescription("Rellenar")]
    public class HayPedidoQueTerminoCocina : Conditional
    {
        public SharedGameObject cajaManager;
        public SharedGameObject cocinaManager;
        private CajaManager caja;
        private CocinaManager cocina;
        public SharedGameObject pedido;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
            cocina = cocinaManager.Value.GetComponent<CocinaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            pedido.Value = cocina.pedidoTerminadoParteCocina();
            if (pedido.Value != null)
            {
                cocina.quitarPedido(pedido.Value);
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }
    }
}