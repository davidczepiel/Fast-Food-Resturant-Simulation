using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cliente")]
[TaskDescription("Este task tiene como objetivo comprobar si el bool de irBaño de un cliente es cierto " +
    "para determinar si necesita ir al baño o no")]
public class NecesitoIrAlBaño : Conditional
{
    //Bool que vamos a comprobar para realizar un comportamiento u otro
    public SharedBool irBaño;

    public override TaskStatus OnUpdate()
    {
        if (irBaño.Value) return TaskStatus.Success;
        else return TaskStatus.Failure;
    }
}