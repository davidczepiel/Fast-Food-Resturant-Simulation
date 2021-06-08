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
    public class Preparacion : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject miPedido;

        public SharedGameObject miTarget;
        public SharedGameObject clientesManager;
        public SharedGameObject comedorManager;
        public SharedGameObject papelerasManager;
        public SharedGameObject cajaManager;
        public SharedGameObject bañosManager;
        public SharedFloat distanciaLlegada;
        public SharedBool irBaño;

        /// <summary>
        /// Esta tarea se hace cargo de el fantasma pille a la cantante
        /// y de avisarla de esto, modificando sus variables y tambien
        /// cambiando las variables globales para que el fantasma continue con sus acciones
        /// </summary>
        /// <returns> Devuleve succes indicando que la tarea ha concluido exitosamente</returns>
        public override TaskStatus OnUpdate()
        {
            miTarget.Value = GameObject.Find("Cola");
            comedorManager.Value = GameObject.Find("Comedor");
            papelerasManager.Value = GameObject.Find("PuntoPapeleras");
            bañosManager.Value = GameObject.Find("Baño");
            cajaManager.Value = GameObject.Find("Mostrador");
            clientesManager.Value = GameObject.Find("ClientesManager");
            distanciaLlegada.Value = 1.2f;
            irBaño.Value = false;

            GameObject pedido = clientesManager.Value.GetComponent<ClientesManager>().dameUnMenu();
            miPedido.Value = pedido;
            return TaskStatus.Success;
        }
    }
}