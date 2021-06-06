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
    public class ClienteBuscaSillaComer : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject target;

        public SharedGameObject comedorManager;

        /// <summary>
        /// Esta tarea se hace cargo de el fantasma pille a la cantante
        /// y de avisarla de esto, modificando sus variables y tambien
        /// cambiando las variables globales para que el fantasma continue con sus acciones
        /// </summary>
        /// <returns> Devuleve succes indicando que la tarea ha concluido exitosamente</returns>
        public override TaskStatus OnUpdate()
        {
            if (!comedorManager.Value.GetComponent<LugaresManager>().hayHueco())
                return TaskStatus.Running;
            else
            {
                GameObject lugar = comedorManager.Value.GetComponent<LugaresManager>().dameLugar();
                //GlobalVariables.Instance.SetVariableValue("ComedorManager", true);
                target.Value = lugar;

                return TaskStatus.Success;
            }
        }
    }
}