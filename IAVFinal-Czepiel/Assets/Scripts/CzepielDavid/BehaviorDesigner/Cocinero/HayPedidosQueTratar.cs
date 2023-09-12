using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
[TaskDescription("Este condición tiene como objetivo preguntar si hay pedidos en los que un cocinero pueda trabajar, tanto si hay pedidos por empezar " +
    "como si hay pedidos en los que pueda ayudar \n" +
    "en caso afirmativo el cocinero se lo lleva para trabajar en él")]
public class HayPedidoQueTratar : Conditional
{
    //Caja manager al que le voy a preguntar por pedidos nuevos
    public SharedGameObject cajaManager;

    //Cocina manager al que le voy a preguntar por pedidos que se estén cocinando
    public SharedGameObject cocinaManager;

    private CajaManager caja;
    private CocinaManager cocina;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
        cocina = cocinaManager.Value.GetComponent<CocinaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        if (caja.areThereAnyOrdersToStart() || cocina.areThereAnyOrdersBeingDone())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}