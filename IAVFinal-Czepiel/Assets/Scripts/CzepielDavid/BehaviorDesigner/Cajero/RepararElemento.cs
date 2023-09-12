using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Este task tiene como objetivo informar a un manager de lugares desgastables de que hemos reparado uno de sus lugares\n" +
    "este task tiene un temporizador que representa el tiempo que vamos a tardar en reparar algo ")]
public class RepararElemento : Action
{
    //Variable que almacena el lugar que hemos reparado
    public SharedGameObject target;

    //Manager de lugares al que le vamos a reparar un lugar
    public SharedGameObject manager;

    //Tiempo que vamos a tardar en reparar algo
    public float tiempoReparar = 2;

    private float timer;

    public override void OnStart()
    {
        timer = tiempoReparar;
    }

    //EN caso de un abort arreglamos el lugar para que no se quede bloquedao y roto para siempre
    public override void OnConditionalAbort()
    {
        manager.Value.GetComponent<LugaresDesgastablesManager>().repairPlace(target.Value);
    }

    public override TaskStatus OnUpdate()
    {
        //Tiempo que voy a tardar en reparar un elemento
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            manager.Value.GetComponent<LugaresDesgastablesManager>().repairPlace(target.Value);
            return TaskStatus.Success;
        }
        else

            return TaskStatus.Running;
    }
}