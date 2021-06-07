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
    public class PedidoNecesitaSerCocinado : Conditional
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
            if (necesitaCocina())
            {
                cocina.empezarPedido(pedido.Value);
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }

        public bool necesitaCocina()
        {
            for (int i = 0; i < posibilidadesAyuda.Count; i++)
            {
                if (pedido.Value.GetComponent<Menu>().menuRequiereItem((MenuItem)posibilidadesAyuda[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}