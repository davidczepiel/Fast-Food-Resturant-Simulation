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
    public class HayClientesCola : Conditional
    {
        public SharedGameObject miTarget;
        public SharedGameObject cajaManager;
        private CajaManager caja;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            if (caja.hayClientesParaPedir())
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }
}