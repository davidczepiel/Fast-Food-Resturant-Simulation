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
    [TaskDescription("Rellenar")]
    public class SeleccionarElementoCompletarMenu : Action
    {
        public SharedGameObject cajaManager;
        public SharedGameObject cocinaManager;
        public SharedGameObject miMenu;
        public SharedUInt itemCocinando;
        public SharedGameObject miPensamiento;
        public SharedGameObject miTarget;
        private Menu menu;
        private CajaManager caja;
        private CocinaManager cocina;

        public List<int> items;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
            cocina = cocinaManager.Value.GetComponent<CocinaManager>();
            menu = miMenu.Value.GetComponent<Menu>();
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
            miTarget.Value = cocina.dameLugarHacerItem((MenuItem)itemCocinando.Value);
            miPensamiento.Value.GetComponent<AgentePiensa>().mostrarImagen((MenuItem)itemCocinando.Value);
            return TaskStatus.Success;
        }
    }
}