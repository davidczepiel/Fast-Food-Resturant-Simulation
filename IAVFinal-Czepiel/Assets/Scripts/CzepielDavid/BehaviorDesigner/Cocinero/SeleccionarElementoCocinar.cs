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
[TaskDescription("Este task tiene como objetivo tomar un menú y comenzar a hacer algún item que no tenga todavía \n" +
    "el cocinero decidirá el item que va a acocinar y le preguntará a la cocina por el lugar en el que debe hacerlo")]
public class SeleccionarElementoCocinar : Action
{
    //Cocina manager al que le voy a preguntar por el lugar en el que puedo cocinar determinado elemento
    public SharedGameObject cocinaManager;

    //Variable que contendrá el menu en el que el cocinero va a ayudar
    public SharedGameObject miMenu;

    //Representación visual del objetivo del cocinero
    public SharedGameObject miPensamiento;

    //Variable que va a alamacenar el elemento que voy a cocinar
    public SharedUInt itemCocinando;

    //Variable que va a almacenar el lugar al que tengo que ir para empezar a cocinar un elemento determinado
    public SharedGameObject miTarget;

    //Tiempo que voy a tardar en cocinar algo
    public float decidirSiguienteItem = 2;

    private float timer;
    private Menu menu;
    private CocinaManager cocina;

    public override void OnStart()
    {
        timer = decidirSiguienteItem;
        cocina = cocinaManager.Value.GetComponent<CocinaManager>();
        menu = miMenu.Value.GetComponent<Menu>();

        //Si el meú no tiene hamburguesa me pongo a hacer hamburguesa
        if (menu.menuRequiereItem(MenuItem.Hamburguesa) && !menu.itemHecho(MenuItem.Hamburguesa))
        {
            itemCocinando.Value = (int)MenuItem.Hamburguesa;
            menu.empezarHacerItem((MenuItem)itemCocinando.Value);
        }
        //Si el meú no tiene patatas me pongo a hacer patatas
        else if (menu.menuRequiereItem(MenuItem.Patatas) && !menu.itemHecho(MenuItem.Patatas))
        {
            itemCocinando.Value = (int)MenuItem.Patatas;
            menu.empezarHacerItem((MenuItem)itemCocinando.Value);
        }
    }

    public override TaskStatus OnUpdate()
    {
        timer -= Time.deltaTime;
        //SI he decidido el elemento qué voy a cocinar me quedo con el lugar en el que debo hacerlo y muestro mi objetivo visualmente
        if (timer <= 0)
        {
            miTarget.Value = cocina.dameLugarHacerItem((MenuItem)itemCocinando.Value);
            miPensamiento.Value.GetComponent<AgentePiensa>().mostrarImagenMenuItem((MenuItem)itemCocinando.Value);
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Running;
    }
}