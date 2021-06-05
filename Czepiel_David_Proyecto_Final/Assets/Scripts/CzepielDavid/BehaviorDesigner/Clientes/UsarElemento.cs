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
    public class UsarElemento : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject miPedido;

        public SharedGameObject miTarget;
        public SharedInt miTicket;
        public SharedVector3 miTargetVector;
        public SharedGameObject lugaresManager;

        private float tiempoPensar;

        private float timer;
        private int pos = 0;

        public override void OnStart()
        {
            pos = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().dameLugarCola();
            tiempoPensar = 1;
            timer = tiempoPensar;
        }

        /// <summary>
        /// Esta tarea se hace cargo de el fantasma pille a la cantante
        /// y de avisarla de esto, modificando sus variables y tambien
        /// cambiando las variables globales para que el fantasma continue con sus acciones
        /// </summary>
        /// <returns> Devuleve succes indicando que la tarea ha concluido exitosamente</returns>
        public override TaskStatus OnUpdate()
        {
            float a = Time.deltaTime;
            timer -= a;
            if (think())
            {
                if (lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().meToca(pos))
                {
                    GameObject lugar = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().dameLugar();
                    miTarget.Value = lugar;
                    return TaskStatus.Success;
                }
                else
                {
                    miTargetVector.Value = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().dameLugarVector(pos);
                    return TaskStatus.Failure;
                }
            }
            return TaskStatus.Running;
        }

        public bool think()
        {
            if (timer <= 0)
            {
                timer = tiempoPensar;
                return true;
            }
            return false;
        }
    }
}