﻿namespace UCM.IAV.Movimiento
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
    [TaskDescription("Rellenar")]
    public class EsperarEnCola : Action
    {
        public SharedGameObject miTarget;
        public SharedInt miTicket;

        private GameObject cajaManager;
        private CajaManager caja;
        private int pos;

        public override void OnStart()
        {
            cajaManager = GlobalVariables.Instance.GetVariable("CajaManager").ConvertTo<SharedGameObject>().Value;
            caja = cajaManager.GetComponent<CajaManager>();
            pos = caja.miPosicionEnLaCola(miTicket.Value);
            miTarget.Value = caja.dameLugar(miTicket.Value);
        }

        public override TaskStatus OnUpdate()
        {
            if (caja.meToca(miTicket.Value))
                return TaskStatus.Success;
            else
            {
                if (pos == caja.miPosicionEnLaCola(miTicket.Value))
                {
                    //this.gameObject.SetActive(false);
                    return TaskStatus.Running;
                }
                else
                {
                    miTarget.Value = caja.dameLugar(miTicket.Value);
                    return TaskStatus.Failure;
                }
            }
        }
    }
}