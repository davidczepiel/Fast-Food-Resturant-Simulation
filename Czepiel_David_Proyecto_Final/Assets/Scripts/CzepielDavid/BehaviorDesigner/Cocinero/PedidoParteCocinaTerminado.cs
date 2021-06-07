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
    public class PedidoParteCocinaTerminado : Action
    {
        public SharedGameObject cajaManager;
        public SharedGameObject cocinaManager;
        public SharedGameObject miMenu;
        private CajaManager caja;
        private CocinaManager cocina;
        private Menu menu;

        public override void OnStart()
        {
            caja = cajaManager.Value.GetComponent<CajaManager>();
            cocina = cocinaManager.Value.GetComponent<CocinaManager>();
            menu = miMenu.Value.GetComponent<Menu>();
        }

        public override TaskStatus OnUpdate()
        {
            //Se quita de la lista de cosas haciendose
            cocina.quitarPedido(miMenu.Value);

            //Se mete en una lista u otra
            if (menu.menuCompletado())
                caja.añadirPedidoPorRegoger(miMenu.Value);
            else
                caja.añadirPedidoPorCompletar(miMenu.Value);

            miMenu.Value = null;
            return TaskStatus.Success;
        }
    }
}