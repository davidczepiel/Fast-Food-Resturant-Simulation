using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cliente")]
[TaskDescription("Este task tiene como objetivo sacar a un cliente determinado de la simulaión")]
public class ClienteSeVa : Action
{
    //Manager que me va a ayudar a salir de la simulación
    public SharedGameObject clientesManager;

    public override TaskStatus OnUpdate()
    {
        clientesManager.Value.GetComponent<AgentesManager>().despawnCustomer(this.gameObject);
        return TaskStatus.Success;
    }
}