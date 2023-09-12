using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal")]
[TaskDescription("Este Task tiene como objetivo que los agentes dejen un pedido en las mesas donde estos se completan")]
public class DejarBandejaMesas : Action
{
    //menu que vamos a dejar en las mesas
    public SharedGameObject miMenu;

    //Mesa concreta en la que lo vamos a soltar
    public SharedGameObject miTarget;

    //Manager de las mesas al que le vamos a informar de qué vamos a dejar y dónde
    public SharedGameObject mesasPedidos;

    private MesaColocarPedido mesas;

    public override void OnStart()
    {
        mesas = mesasPedidos.Value.GetComponent<MesaColocarPedido>();
    }

    public override TaskStatus OnUpdate()
    {
        miTarget.Value = mesas.getTableToLeaveNewStartingOrder();
        mesas.leaveOrderOnTopOfTable(miTarget.Value, miMenu.Value);
        return TaskStatus.Success;
    }
}