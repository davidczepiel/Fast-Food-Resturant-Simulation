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
    [TaskDescription("Este task tiene como objetivo darle al cliente su pedido \n" +
        "Lo que hace es dejar indicar que el pedido está listo y esperar a que el pedido este" +
        "recogido, lo que indica que el cliente ha venido a por él y se lo ha llevado")]
    public class EntregarPedido : Action
    {
        //Pedido que estoy entregando
        public SharedGameObject miPedido;

        private Menu menu;

        public override void OnStart()
        {
            menu = miPedido.Value.GetComponent<Menu>();
            menu.setListo(true);
        }

        public override TaskStatus OnUpdate()
        {
            //Mientras el pedido no haya sido recogido por el cliente sigo esperando
            if (menu.getRecogido())
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}