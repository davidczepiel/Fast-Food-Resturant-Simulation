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
    public class Cocinar : Action
    {
        public SharedGameObject cajaManager;
        public SharedGameObject cocinaManager;
        public SharedGameObject miMenu;
        public SharedUInt itemCocinando;
        private CajaManager caja;
        private CocinaManager cocina;
        public float tiempoCocinar = 2;
        private float timer;

        public override void OnStart()
        {
            timer = tiempoCocinar;
            caja = cajaManager.Value.GetComponent<CajaManager>();
        }

        public override TaskStatus OnUpdate()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                miMenu.Value.GetComponent<Menu>().itemMenuCompletado((MenuItem)itemCocinando.Value);
                if (miMenu.Value.GetComponent<Menu>().itemHecho(MenuItem.Hamburguesa) && miMenu.Value.GetComponent<Menu>().itemHecho(MenuItem.Patatas))
                    return TaskStatus.Success;
                else
                    return TaskStatus.Failure;
            }
            else
                return TaskStatus.Running;
        }
    }
}