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
    public class ComprobarMiPedido : Conditional
    {
        [Tooltip("The first variable to compare")]
        public SharedGameObject variable;

        private Menu miMenu;

        public override void OnStart()
        {
            miMenu = variable.Value.GetComponent<Menu>();
        }

        public override TaskStatus OnUpdate()
        {
            if (miMenu.getListo())
                return TaskStatus.Success;
            else
                return TaskStatus.Running;
        }
    }
}