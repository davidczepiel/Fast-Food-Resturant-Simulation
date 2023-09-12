using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Este task tiene como objetivo indicar que una caja está siendo atendida, para que" +
    "el cliente que esté en ella pida su pedido\n" +
    "Este task tiene un temporizador que indica el tiempo que el cajero va a tardar en atender al cliente")]
public class AtenderCliente : Action
{
    //Manager de la caja
    public SharedGameObject cajaManager;

    private CajaManager caja;

    //Numero de caja que estoy atendiendo
    public SharedInt numCaja;

    //Tiempo que voy a tardar desde que he llegado a la caja para atender al cliente
    public float tiempoAtender = 2;

    private float timer;

    public override void OnStart()
    {
        timer = tiempoAtender;
        caja = cajaManager.Value.GetComponent<CajaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        //Mientras que no se haya agotado el timer estoy atendiendo
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            caja.takeCareOfCustomer(numCaja.Value);
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Running;
    }
}