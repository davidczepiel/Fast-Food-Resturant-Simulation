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
    public class RepararElemento : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject target;

        public SharedGameObject manager;

        public float tiempoReparar = 2;

        private float timer;

        public override void OnStart()
        {
            timer = tiempoReparar;
        }

        public override TaskStatus OnUpdate()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                manager.Value.GetComponent<LugaresDesgastablesManager>().repararLugar(target.Value);
                return TaskStatus.Success;
            }
            else

                return TaskStatus.Running;
        }
    }
}