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
        public SharedVector3 miTargetVector;
        public SharedGameObject cajaManager;

        public override void OnStart()
        {
            miPosicionCola.Value = cajaManager.Value.GetComponent<CajaManager>().dameLugarCola();
        }

        public override TaskStatus OnUpdate()
        {
            if (cajaManager.Value.GetComponent<CajaManager>().meToca(miPosicionCola.Value))
            {
                return TaskStatus.Success;
            }
            else
            {
                //miTarget.Value = cajaManager.Value.GetComponent<CajaManager>().dameLugar(miPosicionCola.Value);
                miTargetVector.Value = cajaManager.Value.GetComponent<CajaManager>().dameLugarVector(miPosicionCola.Value);
                return TaskStatus.Failure;
            }
        }
    }
}