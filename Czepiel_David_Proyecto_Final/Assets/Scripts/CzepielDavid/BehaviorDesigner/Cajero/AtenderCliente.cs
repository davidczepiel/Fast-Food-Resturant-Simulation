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
    public class AtenderCliente : Action
    {
        public SharedGameObject cajaManager;
        private CajaManager caja;
        public float tiempoAtender = 2;
        private float timer;

        public override void OnStart()
        {
            timer = tiempoAtender;
            caja = cajaManager.Value.GetComponent<CajaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                caja.atenderCliente();
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}