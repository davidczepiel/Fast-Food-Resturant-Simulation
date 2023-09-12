using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
[TaskDescription("Este task tiene como objetivo preparar las variables del cocinero antes de pasar a ejecutar el árbol de comportamiento"
   )]
public class PreparacionCocinero : Action
{
    public SharedGameObject miPedido;
    public SharedGameObject miTarget;
    public SharedGameObject cocinaManager;
    public SharedGameObject cajaManager;
    public SharedGameObject despensa;
    public SharedFloat distanciaLlegada;
    public SharedGameObject mesasPedidos;

    public override TaskStatus OnUpdate()
    {
        miTarget.Value = GameObject.Find("Cola");
        cocinaManager.Value = GameObject.Find("Mostrador");
        cajaManager.Value = GameObject.Find("Mostrador");
        despensa.Value = GameObject.Find("Despensa");
        mesasPedidos.Value = GameObject.Find("MesasHacerPedidos");
        distanciaLlegada.Value = 1.2f;

        miPedido.Value = null;
        return TaskStatus.Success;
    }
}