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

    [TaskCategory("CzepielDavidProyectoFinal/Cliente")]
    [TaskDescription("Este task tiene como objetivo que un cliente se lleve el pedido que ha solicitado y se lo ponga en brazos")]
    public class TomarPedido : Action
    {
        //pedido que me voy a llevar
        public SharedGameObject miPedido;

        //Caja a la que le voy a quitar el pedido
        public SharedGameObject cajaManager;

        public override TaskStatus OnUpdate()
        {
            //Tomo el pedido y me lo llevo en brazos
            miPedido.Value.GetComponent<Menu>().setRecogido(true);
            miPedido.Value.transform.position = this.transform.position + (this.transform.forward * 2);
            miPedido.Value.transform.parent = this.transform;
            return TaskStatus.Success;
        }
    }
}