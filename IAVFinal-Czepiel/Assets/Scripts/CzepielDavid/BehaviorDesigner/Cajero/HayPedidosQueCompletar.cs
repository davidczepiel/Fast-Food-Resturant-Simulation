using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Esta condición sirve para comprobar si hay algún pedido que necesite ser completado por un cajero")]
public class HayPedidoQueCompletar : Conditional
{
    //Manager de la caja al que voy a preguntar por cosas de los pedidos
    public SharedGameObject cajaManager;

    //Variable en la que voy a almacenar un posible pedido que necesite ser completado por un cajero
    public SharedGameObject miPedido;

    private CajaManager caja;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        //Si hay algún pedido que completar me lo quedo
        if (caja.areThereAnyOrdersToComplete())
        {
            miPedido.Value = caja.getOrderToComplete();
            caja.addOrderToTheToCompleteList(miPedido.Value);
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Failure;
    }
}