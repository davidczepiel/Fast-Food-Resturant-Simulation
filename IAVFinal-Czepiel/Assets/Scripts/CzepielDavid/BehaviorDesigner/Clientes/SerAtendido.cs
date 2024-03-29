﻿using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cliente")]
[TaskDescription("Este task tiene como objetivo cocinar un elemento determinado\n" +
    "Este task dispone de un temporizador que representa el tiempo que vamos a tardar en cocinar algo ")]
public class SerAtendido : Action
{
    //Pedido que voy a hacer
    public SharedGameObject miPedido;

    //Caja a la que le voy a solicitar mi pedido
    public SharedGameObject cajaManager;

    //Caja en la que estoy siendo atendido
    private int miNumeroCaja;

    public override void OnStart()
    {
        miNumeroCaja = cajaManager.Value.GetComponent<CajaManager>().giveAvailableCashierToBeServed();
    }

    public override TaskStatus OnUpdate()
    {
        //Mientras no me atiendad, sigo esperando
        if (cajaManager.Value.GetComponent<CajaManager>().haveIBeenAttended(miNumeroCaja))
        {
            cajaManager.Value.GetComponent<CajaManager>().placeOrder(miNumeroCaja, miPedido.Value);
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Running;
    }
}