using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


[TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
[TaskDescription("Este task tiene como objetivo cocinar un elemento determinado\n" +
    "Este task dispone de un temporizador que representa el tiempo que vamos a tardar en cocinar algo ")]
public class Cocinar : Action
{
    //Menu en el que vamos a contribuir
    public SharedGameObject miMenu;

    //Item que vamos a cocinar
    public SharedUInt itemCocinando;

    //Tiempo que vamos a tardar en cocinar cualquier cosa
    public float tiempoCocinar = 2;

    private float timer;

    public override void OnStart()
    {
        timer = tiempoCocinar;
    }

    public override TaskStatus OnUpdate()
    {
        //Mientras no se haya terminado el temporizador significa que seguimos cocinando
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            miMenu.Value.GetComponent<Menu>().completeOrderItem((MenuItem)itemCocinando.Value);
            miMenu.Value = null;
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Running;
    }
}