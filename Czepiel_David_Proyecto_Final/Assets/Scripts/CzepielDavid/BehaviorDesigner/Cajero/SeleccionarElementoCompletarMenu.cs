namespace UCM.IAV.Movimiento
{
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
    [TaskDescription("Este task tiene como objetivo seleccionar un elemento en el que completar algo en el menu que he hemos tomado para ayudar")]
    public class SeleccionarElementoCompletarMenu : Action
    {
        //Cocina a la que le voy a preguntar por el lugar en el que se cocinan los elementos del menu
        public SharedGameObject cocinaManager;

        //Menu que voy a completar
        public SharedGameObject miMenu;

        //Item que coy a completar del menu
        public SharedUInt itemCocinando;

        //Pensamiento que sirve para mostrar visualmente el item que vamos a cocinar
        public SharedGameObject miPensamiento;

        //Lugar al que me voy a ir a cocinar
        public SharedGameObject miTarget;

        //Lista de elementos en los que puedo ayudar
        public List<int> items;

        private Menu menu;
        private CocinaManager cocina;

        public override void OnStart()
        {
            cocina = cocinaManager.Value.GetComponent<CocinaManager>();
            menu = miMenu.Value.GetComponent<Menu>();

            //Recorro los items que puedo cocinar y si el menu los requiere y todacia no los tiene me lo adjuido y me voy a cocinarlo
            for (uint i = 0; i < items.Count; i++)
            {
                if (menu.menuRequiereItem((MenuItem)items[(int)i]) && !menu.itemHecho((MenuItem)items[(int)i]))
                {
                    itemCocinando.Value = (uint)items[(int)i];
                    menu.empezarHacerItem((MenuItem)itemCocinando.Value);
                    break;
                }
            }
        }

        public override TaskStatus OnUpdate()
        {
            //Le pido a la cocina un lugar en el que pueda cocinar el item que coy a cocinar
            miTarget.Value = cocina.dameLugarHacerItem((MenuItem)itemCocinando.Value);
            miPensamiento.Value.GetComponent<AgentePiensa>().mostrarImagen((MenuItem)itemCocinando.Value);
            return TaskStatus.Success;
        }
    }
}