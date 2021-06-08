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

    [TaskCategory("CzepielDavidProyectoFinal/Cajero")]
    [TaskDescription("Rellenar")]
    public class PuedoAyudarCompletarAlgunPedido : Conditional
    {
        public SharedGameObject cajaManager;
        public SharedGameObject cocinaManager;
        private CajaManager caja;
        private CocinaManager cocina;
        public SharedGameObject pedido;

        public List<int> posibilidadesAyuda;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
            cocina = cocinaManager.Value.GetComponent<CocinaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            if (pedidosParaAyudar())
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }

        private bool pedidosParaAyudar()
        {
            if (caja.hayPedidosParaCompletar())
            {
                pedido.Value = caja.pedidoEnElQueAyudar(posibilidadesAyuda);
                if (pedido.Value != null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}