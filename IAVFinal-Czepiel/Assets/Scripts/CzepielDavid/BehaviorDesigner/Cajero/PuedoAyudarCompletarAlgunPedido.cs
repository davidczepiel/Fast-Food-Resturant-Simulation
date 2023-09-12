using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Esta condición sirve para comprobar si hay algún pedido que necesite se esté haciendo y le quede algún item\n" +
    "que todacía no se ha empezado a hacer y puedo ayudar con ello")]
public class PuedoAyudarCompletarAlgunPedido : Conditional
{
    //Caja a la que le voy a preguntar si puedo ayudar en algo con las opciones que puedo cocinar
    public SharedGameObject cajaManager;

    private CajaManager caja;

    //Variable que va a almacenar un posible pedido en el que pueda ayudar en algo
    public SharedGameObject pedido;

    //Lista de elementos en los que puedo ayudar a cocinar un menu
    public List<int> posibilidadesAyuda;

    public override void OnStart()
    {
        caja = cajaManager.Value.GetComponent<CajaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        if (pedidosParaAyudar())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }

    private bool pedidosParaAyudar()
    {
        //Si hay algo que se esté completando pregunto si puedo ayudar en algo
        if (caja.areThereAnyOrdersToComplete())
        {
            pedido.Value = caja.getOrderToCOmplete(posibilidadesAyuda);
            if (pedido.Value != null)
                return true;
            else
                return false;
        }
        else
            return false;
    }
}