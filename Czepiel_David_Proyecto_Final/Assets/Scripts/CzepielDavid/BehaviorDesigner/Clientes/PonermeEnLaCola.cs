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
    public class PonermeEnLaCola : Action
    {
        public SharedInt miPosicionCola;

        public SharedGameObject miTarget;
        public SharedVector3 miTargetVector;

        public SharedGameObject lugaresManager;

        public override void OnStart()
        {
            miPosicionCola.Value = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().dameLugarCola();
        }

        public override TaskStatus OnUpdate()
        {
            if (lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().meToca(miPosicionCola.Value))
            {
                GameObject lugar = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().dameLugar();
                miTarget.Value = lugar;
                return TaskStatus.Success;
            }
            else
            {
                miTargetVector.Value = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().dameLugarVector(miPosicionCola.Value);
                return TaskStatus.Failure;
            }
        }
    }
}