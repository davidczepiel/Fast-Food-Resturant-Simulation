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
    public class HayPedidoQueTerminar : Conditional
    {
        public SharedGameObject cajaManager;
        private CajaManager caja;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            if (caja.hayPedidosParaRecoger() || caja.hayPedidosParaCompletar())
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }

        public override void OnConditionalAbort()
        {
            int a;
            a = 0;
            a += a;
            //manager.Value.GetComponent<LugaresDesgastablesManager>().repararLugar(target.Value);
        }
    }
}