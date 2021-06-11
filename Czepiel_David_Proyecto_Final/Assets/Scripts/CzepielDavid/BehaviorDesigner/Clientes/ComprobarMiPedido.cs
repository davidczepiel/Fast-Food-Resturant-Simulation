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
    [TaskDescription("Este task tiene como objetivo comprobar el pedido un cliente ha solicitado para ver si está listo\n" +
        "En caso de que esté listo el cliente proseguirá a comerlo ")]
    public class ComprobarMiPedido : Conditional
    {
        //Variable que almacena el menu que el cliente va a estar esperado
        public SharedGameObject variable;

        //Lugar al que voy a ir una vez que mi pedido esté listo para llevarmelo
        public SharedGameObject miTarget;

        private Menu miMenu;

        public override void OnStart()
        {
            miMenu = variable.Value.GetComponent<Menu>();
        }

        public override TaskStatus OnUpdate()
        {
            //Si mi pedido está listo voy a por él, sino me quedo esperando
            if (miMenu.getListo())
            {
                miTarget.Value = GameObject.Find("LugarRecogerPedido");
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Running;
        }
    }
}