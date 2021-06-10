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

    [TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
    [TaskDescription("Rellenar")]
    public class PreparacionCocinero : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject miPedido;

        public SharedGameObject miTarget;
        public SharedGameObject cocinaManager;
        public SharedGameObject cajaManager;
        public SharedGameObject despensa;
        public SharedFloat distanciaLlegada;
        public SharedGameObject mesasPedidos;

        /// <summary>
        /// Esta tarea se hace cargo de el fantasma pille a la cantante
        /// y de avisarla de esto, modificando sus variables y tambien
        /// cambiando las variables globales para que el fantasma continue con sus acciones
        /// </summary>
        /// <returns> Devuleve succes indicando que la tarea ha concluido exitosamente</returns>
        public override TaskStatus OnUpdate()
        {
            miTarget.Value = GameObject.Find("Cola");
            cocinaManager.Value = GameObject.Find("Mostrador");
            cajaManager.Value = GameObject.Find("Mostrador");
            despensa.Value = GameObject.Find("Despensa");
            mesasPedidos.Value = GameObject.Find("MesasHacerPedidos");
            distanciaLlegada.Value = 1.2f;

            miPedido.Value = null;
            return TaskStatus.Success;
        }
    }
}