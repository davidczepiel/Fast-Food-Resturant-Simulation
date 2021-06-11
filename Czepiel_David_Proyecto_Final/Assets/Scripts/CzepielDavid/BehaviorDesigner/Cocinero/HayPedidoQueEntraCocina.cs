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
    [TaskDescription("Este condición tiene como objetivo preguntar si hay pedidos nuevos en la cocina \n" +
        "en caso afirmativo el cocinero se lo lleva para trabajar en él")]
    public class HayPedidoQueEntraCocina : Conditional
    {
        //Caja manager al que le voy a preguntar por si hay nuevos pedidos
        public SharedGameObject cajaManager;

        private CajaManager caja;

        //Variable que va a almacenar el posible nuevo pedido que haya llegado
        public SharedGameObject pedido;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            //En caso de que haya algún pedido nuevo el cocinero se lo queda
            if (caja.hayPedidosParaEmpezar())
            {
                pedido.Value = caja.damePedidoPorEmpezar();
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }
    }
}