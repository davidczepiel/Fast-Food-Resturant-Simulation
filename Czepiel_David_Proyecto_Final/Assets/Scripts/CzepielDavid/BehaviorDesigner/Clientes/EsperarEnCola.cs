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
    public class EsperarEnCola : Action
    {
        public SharedInt miTicket;
        public SharedGameObject miTarget;
        public SharedVector3 miTargetVector;
        public SharedGameObject lugaresManager;

        private LugaresDesgastablesManager lugares;
        private int pos;

        public override void OnStart()
        {
            lugares = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>();
            pos = lugares.posDentroCola(miTicket.Value);
        }

        public override TaskStatus OnUpdate()
        {
            if (lugares.meToca(miTicket.Value))
            {
                GameObject lugar = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().dameLugar();
                miTarget.Value = lugar;
                return TaskStatus.Success;
            }
            else
            {
                if (pos == lugares.posDentroCola(miTicket.Value))
                {
                    return TaskStatus.Running;
                }
                else
                {
                    miTargetVector.Value = lugares.dameLugarVector(miTicket.Value);
                    return TaskStatus.Failure;
                }
            }
        }
    }
}