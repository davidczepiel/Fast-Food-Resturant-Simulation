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
    public class PonermeEnLaCola : Action
    {
        public SharedInt miPosicionCola;
        public SharedGameObject miTarget;

        private GameObject cajaManager;

        public override void OnStart()
        {
            cajaManager = GlobalVariables.Instance.GetVariable("CajaManager").ConvertTo<SharedGameObject>().Value;
            miPosicionCola.Value = cajaManager.GetComponent<CajaManager>().dameLugarCola();
        }

        public override TaskStatus OnUpdate()
        {
            if (cajaManager.GetComponent<CajaManager>().meToca(miPosicionCola.Value))
                return TaskStatus.Success;
            else
            {
                miTarget.Value = cajaManager.GetComponent<CajaManager>().dameLugar(miPosicionCola.Value);
                return TaskStatus.Failure;
            }
        }
    }
}