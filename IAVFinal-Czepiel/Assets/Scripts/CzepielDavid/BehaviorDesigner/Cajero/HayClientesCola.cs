using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Esta condición tiene como objetivo comprobar si hay clientes en alguna de las cajas esperando\n" +
    "En caso de que haya algún cliente, pregunto por la caja en la que se encuentra y me la quedo para ir a atenderle")]
public class HayClientesCola : Conditional
{
    public SharedGameObject cajaManager;
    private CajaManager caja;
    public SharedInt numCaja;
    public SharedGameObject atenderPedido;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        //Si hay alguna caja con clientes que atender me quedo su número para ir a atender
        if (caja.isThereAnyClientWaitingToOrder())
        {
            numCaja.Value = caja.getCashierNumberToAttendANewCustomer();
            atenderPedido.Value = GameObject.Find("LugarAtender"+(numCaja.Value+1));
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Failure;
    }
}