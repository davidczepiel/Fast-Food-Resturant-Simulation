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
    public class BuscarLugarEsperar : Action
    {
        public SharedVector3 targetVector;
        public GameObject objetivo;
        public Vector3 offsets;

        public override TaskStatus OnUpdate()
        {
            Vector3 desplazamiento = new Vector3();
            desplazamiento.x = (offsets.x * ((float)Random.Range(-100, 100) / (float)100));
            desplazamiento.y = (offsets.y * ((float)Random.Range(-100, 100) / (float)100));
            desplazamiento.z = (offsets.z * ((float)Random.Range(-100, 100) / (float)100));

            targetVector.Value = desplazamiento + objetivo.transform.position;

            return TaskStatus.Success;
        }
    }
}