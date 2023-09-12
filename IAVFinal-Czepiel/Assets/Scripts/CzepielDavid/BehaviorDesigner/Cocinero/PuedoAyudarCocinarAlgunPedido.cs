using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
[TaskDescription("Este condición tiene como objetivo preguntar si hay pedidos en la cocina en lo que el cocinero pueda ayudar \n" +
    "en caso afirmativo el cocinero se lo lleva para trabajar en él")]
public class PuedoAyudarCocinarAlgunPedido : Conditional
{
    //Cocina manager al que le voy a preguntar por pedidos en los que peuda ayudar
    public SharedGameObject cocinaManager;

    private CocinaManager cocina;

    //Variable que va a almacenar un posible pedido en el que el cocinero pueda ayudar en algo
    public SharedGameObject pedido;

    //Lista de elementos en los que puede ayudar el cocinero
    public List<int> posibilidadesAyuda;

    public override void OnStart()
    {
        cocina = cocinaManager.Value.GetComponent<CocinaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        if (pedidosParaAyudar())
        {
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Failure;
    }

    private bool pedidosParaAyudar()
    {
        //Si hay pedidos haciendose le pregunto por alguno en el que pueda ayudar
        if (cocina.areThereAnyOrdersBeingDone())
        {
            pedido.Value = cocina.getOrderToHelpWith(posibilidadesAyuda);
            if (pedido.Value != null)
                return true;
            else
                return false;
        }
        else
            return false;
    }
}