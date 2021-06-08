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
    [TaskDescription("Rellenar")]
    public class Comer : Action
    {
        [Tooltip("Silla para sentarme")]
        public SharedGameObject miPedido;

        private Menu miMenu;

        public float tiempoComerAlgo = 1;

        private float timer;

        public SharedBool irBaño;

        public override void OnStart()

        {
            miMenu = miPedido.Value.GetComponent<Menu>();
            timer = tiempoComerAlgo;
        }

        /// <summary>
        /// Esta tarea se hace cargo de el fantasma pille a la cantante
        /// y de avisarla de esto, modificando sus variables y tambien
        /// cambiando las variables globales para que el fantasma continue con sus acciones
        /// </summary>
        /// <returns> Devuleve succes indicando que la tarea ha concluido exitosamente</returns>
        public override TaskStatus OnUpdate()
        {
            float a = Time.deltaTime;
            timer -= a;
            if (comidoItem())
            {
                bool terminado = miMenu.comer();
                if (terminado)
                {
                    if (miMenu.menuRequiereItem(MenuItem.Bebida))
                        irBaño.Value = true;
                    else
                        irBaño.Value = false;

                    return TaskStatus.Success;
                }
            }
            return TaskStatus.Running;
        }

        private bool comidoItem()
        {
            if (timer <= 0)
            {
                timer = tiempoComerAlgo;
                return true;
            }
            return false;
        }
    }
}