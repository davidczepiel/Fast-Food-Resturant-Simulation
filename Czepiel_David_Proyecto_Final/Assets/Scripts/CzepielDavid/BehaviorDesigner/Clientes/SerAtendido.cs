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

    [TaskCategory("CzepielDavidProyectoFinal/Cliente")]
    [TaskDescription("Rellenar")]
    public class SerAtendido : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject miPedido;

        public SharedGameObject cajaManager;
        private CajaManager caja;
        private int miNumeroCaja;

        public override void OnStart()
        {
            //    caja = cajaManager.Value.GetComponent<CajaManager>();
            miNumeroCaja = cajaManager.Value.GetComponent<CajaManager>().darCajaCliente();
        }

        public override TaskStatus OnUpdate()
        {
            if (cajaManager.Value.GetComponent<CajaManager>().meHanAtendido(miNumeroCaja))
            {
                cajaManager.Value.GetComponent<CajaManager>().hacerPedido(miNumeroCaja, miPedido.Value);
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}