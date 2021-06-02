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
    public class EsperarPedido : Action
    {
        public SharedGameObject miTarget;
        public SharedGameObject cajaManager;
        public SharedInt miTicket;

        public SharedGameObject miPedido;

        private CajaManager caja;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            if (caja.meToca(miTicket.Value)) ;
            else
            {
                //if (pos == caja.miPosicionEnLaCola(miTicket.Value))
                //{
                //    this.gameObject.SetActive(false);
                //    return TaskStatus.Running;
                //}
                //else
                //{
                //    miTarget.Value = caja.dameLugar(miTicket.Value);
                //    return TaskStatus.Failure;
                //}
            }
            return TaskStatus.Success;
        }
    }
}