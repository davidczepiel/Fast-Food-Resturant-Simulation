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
    public class DejarBandejaMesas : Action
    {
        public SharedGameObject cajaManager;
        public SharedGameObject cocinaManager;
        public SharedGameObject miMenu;
        public SharedUInt itemCocinando;
        public SharedGameObject miTarget;
        public SharedGameObject mesasPedidos;
        private MesaColocarPedido mesas;
        private CajaManager caja;
        private CocinaManager cocina;
        public float tiempoCocinar = 2;
        private float timer;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
            mesas = mesasPedidos.Value.GetComponent<MesaColocarPedido>();
        }

        public override TaskStatus OnUpdate()
        {
            miTarget.Value = mesas.dameLugarPonerMenu();
            mesas.dejarPedidoEnMesa(miTarget.Value, miMenu.Value);
            return TaskStatus.Success;
        }
    }
}