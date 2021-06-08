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
    public class HayLugarQueReparar : Conditional
    {
        public SharedGameObject papeleras;

        public SharedGameObject miTarget;

        public override TaskStatus OnUpdate()
        {
            if (papeleras.Value.GetComponent<LugaresDesgastablesManager>().hayLugarQueArreglar())
            {
                miTarget.Value = papeleras.Value.GetComponent<LugaresDesgastablesManager>().dameLugarParaArreglar();
                return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Failure;
            }
        }
    }
}