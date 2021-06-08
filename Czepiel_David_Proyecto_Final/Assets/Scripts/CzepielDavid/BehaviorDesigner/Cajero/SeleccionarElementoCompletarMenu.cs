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
        public SharedGameObject miTarget;
        private Menu menu;
        private CajaManager caja;
        private CocinaManager cocina;
        public float tiempoCocinar = 2;
        private float timer;

        public List<int> items;

        public override void OnStart()
        {
            timer = tiempoCocinar;
            caja = cajaManager.Value.GetComponent<CajaManager>();
            cocina = cocinaManager.Value.GetComponent<CocinaManager>();
            menu = miMenu.Value.GetComponent<Menu>();
            for (uint i = 0; i < items.Count; i++)
            {
                if (!menu.itemHecho((MenuItem)items[(int)i]))
                {
                    itemCocinando.Value = (uint)items[(int)i];
                    menu.empezarHacerItem((MenuItem)itemCocinando.Value);
                    break;
                }
            }
        }

        public override TaskStatus OnUpdate()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                miTarget.Value = cocina.dameLugarHacerItem((MenuItem)itemCocinando.Value);
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}