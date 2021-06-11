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
    [TaskDescription("Este task tiene como objetivo tomar la imagen de la cabeza de los agentes y mostrar una concreta para" +
        "informar de su objetivo actual")]
    public class MostrarPensamiento : Action
    {
        //Objeto que representa la imagen que va cambiando
        public SharedGameObject miPensamiento;

        //Imagen que deseamos mostrar
        public Pensamiento pensamiento;

        public override TaskStatus OnUpdate()
        {
            miPensamiento.Value.GetComponent<AgentePiensa>().mostrarImagenPensamiento(pensamiento);
            return TaskStatus.Success;
        }
    }
}