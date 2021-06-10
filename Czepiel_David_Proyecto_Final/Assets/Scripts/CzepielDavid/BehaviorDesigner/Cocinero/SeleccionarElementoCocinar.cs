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

    [TaskCategory("CzepielDavidProyectoFinal/Cocinero")]
    [TaskDescription("Rellenar")]
    public class SeleccionarElementoCocinar : Action
    {
        public SharedGameObject cajaManager;
        public SharedGameObject cocinaManager;
        public SharedGameObject miMenu;
        public SharedGameObject miPensamiento;
        public SharedUInt itemCocinando;
        public SharedGameObject miTarget;
        private Menu menu;
        private CajaManager caja;
        private CocinaManager cocina;
        public float tiempoCocinar = 2;
        private float timer;

        public override void OnStart()
        {
            timer = tiempoCocinar;
            caja = cajaManager.Value.GetComponent<CajaManager>();
            cocina = cocinaManager.Value.GetComponent<CocinaManager>();
            menu = miMenu.Value.GetComponent<Menu>();
            if (menu.menuRequiereItem(MenuItem.Hamburguesa) && !menu.itemHecho(MenuItem.Hamburguesa))
            {
                itemCocinando.Value = (int)MenuItem.Hamburguesa;
                menu.empezarHacerItem((MenuItem)itemCocinando.Value);
            }
            else if (menu.menuRequiereItem(MenuItem.Patatas) && !menu.itemHecho(MenuItem.Patatas))
            {
                itemCocinando.Value = (int)MenuItem.Patatas;
                menu.empezarHacerItem((MenuItem)itemCocinando.Value);
            }
        }

        public override TaskStatus OnUpdate()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                miTarget.Value = cocina.dameLugarHacerItem((MenuItem)itemCocinando.Value);
                miPensamiento.Value.GetComponent<AgentePiensa>().mostrarImagen((MenuItem)itemCocinando.Value);
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}