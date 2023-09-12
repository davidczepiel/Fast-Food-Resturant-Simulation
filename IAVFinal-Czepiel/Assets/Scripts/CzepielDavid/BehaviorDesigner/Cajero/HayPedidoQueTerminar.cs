using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Esta condición tiene como objetivo preguntar si hay algún pedido que necesite ser entregado\n" +
    "o necesite ser completado por un cajero")]
public class HayPedidoQueTerminar : Conditional
{
    //Manager de la caja al que voy a preguntar cosas sobre los pedidos
    public SharedGameObject cajaManager;

    private CajaManager caja;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        if (caja.areThereAnyOrdersToGiveToTheCustomer() || caja.areThereAnyOrdersToComplete())
        {
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Failure;
    }
}