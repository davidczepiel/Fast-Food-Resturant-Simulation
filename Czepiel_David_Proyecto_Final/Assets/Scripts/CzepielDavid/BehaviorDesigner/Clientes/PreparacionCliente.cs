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
    [TaskDescription("Este task tiene como objetivo preparar las variables de los clientes para su correcto funcionamiento")]
    public class PreparacionCliente : Action
    {
        public SharedGameObject miPedido;
        public SharedGameObject miTarget;
        public SharedGameObject clientesManager;
        public SharedGameObject comedorManager;
        public SharedGameObject papelerasManager;
        public SharedGameObject cajaManager;
        public SharedGameObject bañosManager;
        public SharedFloat distanciaLlegada;
        public SharedGameObject calle;
        public SharedBool irBaño;

        public override TaskStatus OnUpdate()
        {
            miTarget.Value = GameObject.Find("Cola");
            comedorManager.Value = GameObject.Find("Comedor");
            papelerasManager.Value = GameObject.Find("PuntoPapeleras");
            bañosManager.Value = GameObject.Find("Baño");
            cajaManager.Value = GameObject.Find("Mostrador");
            clientesManager.Value = GameObject.Find("ClientesManager");
            calle.Value = GameObject.Find("Calle");

            distanciaLlegada.Value = 1.2f;
            irBaño.Value = false;

            GameObject pedido = clientesManager.Value.GetComponent<AgentesManager>().dameUnMenu();
            miPedido.Value = pedido;
            return TaskStatus.Success;
        }
    }
}