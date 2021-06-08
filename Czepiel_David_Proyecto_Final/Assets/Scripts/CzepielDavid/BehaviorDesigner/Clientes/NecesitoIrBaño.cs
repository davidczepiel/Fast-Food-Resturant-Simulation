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
    public class NecesitoIrAlBaño : Conditional
    {
        public SharedGameObject variable;

        public SharedBool irBaño;

        public override TaskStatus OnUpdate()
        {
            if (irBaño.Value)
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }
}