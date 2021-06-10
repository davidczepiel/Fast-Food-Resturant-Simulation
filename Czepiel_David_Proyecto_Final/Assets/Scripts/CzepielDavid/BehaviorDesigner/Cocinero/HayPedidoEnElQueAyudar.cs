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
    public class HayPedidoEnElQueAyudar : Conditional
    {
        public SharedGameObject cajaManager;
        public SharedGameObject pedido;
        public SharedGameObject cocinaManager;
        private CajaManager caja;
        private CocinaManager cocina;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
            cocina = cocinaManager.Value.GetComponent<CocinaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            if (pedido.Value != null)
                return TaskStatus.Success;

            if (cocina.hayPedidosHaciendose())
            {
                List<int> posibilidadesAyuda = new List<int>();
                posibilidadesAyuda.Add((int)MenuItem.Hamburguesa);
                posibilidadesAyuda.Add((int)MenuItem.Patatas);

                pedido.Value = cocina.damePedidoEnElQueAyudar(posibilidadesAyuda);
                if (pedido.Value != null)
                {
                    return TaskStatus.Success;
                }
                else
                    return TaskStatus.Failure;
            }
            else
                return TaskStatus.Failure;
        }
    }
}