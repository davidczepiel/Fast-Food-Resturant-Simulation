using System.Collections;
using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine.AI;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Esta condición tiene como objetivo preguntar a un manager de lugares desgastables por si tiene\n" +
    "algún lugar desgastado para ir a arreglarlo, en caso de que tenga algo que reparar le pido que me diga el qué, para ir a arreglarlo")]
public class HayLugarQueReparar : Conditional
{
    //Manager al que voy a preguntar por cosas que arreglar
    public SharedGameObject lugaresManager;

    //Variable en la que voy a almacenar el lugar que pueda necesitar ser reparado
    public SharedGameObject miTarget;

    public override TaskStatus OnUpdate()
    {
        //Pregunto por lugares que reparar, si los hay me quedo con uno de ellos para ir a repararlo
        if (lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().hayLugarQueArreglar())
        {
            miTarget.Value = lugaresManager.Value.GetComponent<LugaresDesgastablesManager>().dameLugarQueArreglar();
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Failure;
    }
}