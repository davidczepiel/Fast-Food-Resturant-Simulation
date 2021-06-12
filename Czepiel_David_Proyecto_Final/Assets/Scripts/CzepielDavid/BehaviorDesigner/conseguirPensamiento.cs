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
[TaskDescription("Este task tiene como objetivo hacerse con el objeto que representa la imagen de cada agente y que informa" +
    "de su siguiente objetivo")]
public class conseguirPensamiento : Action
{
    //Variable en la que voy a almacenar el objeto en cuestion
    public SharedGameObject miPensamiento;

    public override TaskStatus OnUpdate()
    {
        miPensamiento.Value = this.gameObject.transform.Find("Pensamiento").gameObject;
        return TaskStatus.Success;
    }
}