using System.Collections;
using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine.AI;

[TaskCategory("CzepielDavidProyectoFinal/Cajero")]
[TaskDescription("Rellenar")]
public class PreparacionCajero : Action
{
    public SharedGameObject miPedido;
    public SharedGameObject miTarget;
    public SharedGameObject cajaManager;
    public SharedGameObject bañosManager;
    public SharedGameObject papelerasManager;
    public SharedGameObject cocinaManager;
    public SharedGameObject mesasPedidos;
    public SharedGameObject despensa;
    public SharedGameObject atenderPedido;
    public SharedGameObject darPedido;

    public SharedFloat distanciaLlegada;

    /// <summary>
    /// Esta tarea se hace cargo de el fantasma pille a la cantante
    /// y de avisarla de esto, modificando sus variables y tambien
    /// cambiando las variables globales para que el fantasma continue con sus acciones
    /// </summary>
    /// <returns> Devuleve succes indicando que la tarea ha concluido exitosamente</returns>
    public override TaskStatus OnUpdate()
    {
        miTarget.Value = GameObject.Find("Cola");
        papelerasManager.Value = GameObject.Find("PuntoPapeleras");
        bañosManager.Value = GameObject.Find("Baño");
        cajaManager.Value = GameObject.Find("Mostrador");
        cocinaManager.Value = GameObject.Find("Mostrador");
        mesasPedidos.Value = GameObject.Find("MesasHacerPedidos");
        despensa.Value = GameObject.Find("Despensa");
        darPedido.Value = GameObject.Find("LugarDarPedido");
        atenderPedido.Value = GameObject.Find("LugarAtender1");

        distanciaLlegada.Value = 1.2f;

        miPedido.Value = null;
        return TaskStatus.Success;
    }
}