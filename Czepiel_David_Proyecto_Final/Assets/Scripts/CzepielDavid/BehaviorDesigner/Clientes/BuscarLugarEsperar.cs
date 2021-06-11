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
    [TaskDescription("Este task tiene como objetivo buscar un lugar en el que ponerme a esperar\n" +
        "El agente va a tomar un target como posición y mediante unos offsets va a decidir una posición cercana en la que esperar ")]
    public class BuscarLugarEsperar : Action
    {
        //Posición alrededor de la que esperaré
        public SharedVector3 targetVector;

        //Offsets de separación de la posición original
        public Vector3 offsets;

        public override TaskStatus OnUpdate()
        {
            Vector3 desplazamiento = new Vector3();
            desplazamiento.x = (offsets.x * ((float)Random.Range(-100, 100) / (float)100));
            desplazamiento.y = (offsets.y * ((float)Random.Range(-100, 100) / (float)100));
            desplazamiento.z = (offsets.z * ((float)Random.Range(-100, 100) / (float)100));

            targetVector.Value = desplazamiento + GameObject.Find("EsperarPedido").transform.position;
            return TaskStatus.Success;
        }
    }
}