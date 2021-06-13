using System.Collections;
using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine.AI;

[TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
[TaskDescription("Este condición tiene como objetivo preguntar si un pedido concreto necesita de items que se cocinen en la cocina \n" +
    "en caso afirmativo el cocinero comienza a cocinar alguno de los elementos que este menú requiera y lo pone en la lista de menus cocinandose en la cocina")]
public class PedidoNecesitaSerCocinado : Conditional
{
    //Cocina manager al que le voy a informar de que hay un nuevo pedido que se está haciendo
    public SharedGameObject cocinaManager;

    private CocinaManager cocina;

    //Menu que el cocinero tiene en manos y va a analizar si necesita de cosas que se cocinen en la cocina o no
    public SharedGameObject pedido;

    //Lista de items que el cocinero es capaz de hacer
    public List<int> posibilidadesAyuda;

    public override void OnStart()
    {
        cocina = cocinaManager.Value.GetComponent<CocinaManager>();
    }

    public override TaskStatus OnUpdate()
    {
        //Si el menu necesita de cosas de la cocina la informamos de que hay un nuevo elemento haciendose
        if (necesitaCocina())
        {
            cocina.empezarPedido(pedido.Value);
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Failure;
    }

    public bool necesitaCocina()
    {
        //Recorro los posibles items que el cocinero es capaz de hacer, y si el menú necesita alguno de estos podemos empezar a trabajar
        //en este menú
        for (int i = 0; i < posibilidadesAyuda.Count; i++)
        {
            if (pedido.Value.GetComponent<Menu>().menuRequiereItem((MenuItem)posibilidadesAyuda[i]))
            {
                return true;
            }
        }
        return false;
    }
}