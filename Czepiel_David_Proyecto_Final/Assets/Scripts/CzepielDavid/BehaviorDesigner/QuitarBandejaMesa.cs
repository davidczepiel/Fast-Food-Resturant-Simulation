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

    [TaskCategory("CzepielDavidProyectoFinal")]
    [TaskDescription("Este task tiene como objetivo quitar uno de los pedidos almacenados en las mesas")]
    public class QuitarBandejaMesa : Action
    {
        //menu que voy a quitar
        public SharedGameObject miMenu;

        //Objeto manager de las mesas donde se dejan los pedidos
        public SharedGameObject mesasPedidos;

        public override TaskStatus OnUpdate()
        {
            mesasPedidos.Value.GetComponent<MesaColocarPedido>().quitarPedidoDeLasMesas(miMenu.Value);
            return TaskStatus.Success;
        }
    }
}