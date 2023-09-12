using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal")]
[TaskDescription("Este task tiene como objetivo quitar uno de los pedidos almacenados en las mesas")]
public class QuitarBandejaMesa : Action
{
    //menu que voy a quitar
    public SharedGameObject miMenu;

    //Objeto manager de las mesas donde se dejan los pedidos
    public SharedGameObject mesasPedidos;

    public override TaskStatus OnUpdate()
    {
        mesasPedidos.Value.GetComponent<MesaColocarPedido>().removeOrderFromTables(miMenu.Value);
        return TaskStatus.Success;
    }
}