using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


[TaskCategory("CzepielDavidProyectoFinal")]
[TaskDescription("Este task tiene como objetivo hacerse con el objeto que representa la imagen de cada agente y que informa" +
    "de su siguiente objetivo")]
public class conseguirPensamiento : Action
{
    public SharedGameObject miPensamiento;
    public override TaskStatus OnUpdate()
    {
        miPensamiento.Value = this.gameObject.transform.Find("Pensamiento").gameObject;
        return TaskStatus.Success;
    }
}