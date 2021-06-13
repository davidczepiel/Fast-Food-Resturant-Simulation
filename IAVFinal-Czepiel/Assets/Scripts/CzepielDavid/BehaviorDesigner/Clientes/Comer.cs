﻿using System.Collections;
using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine.AI;

[TaskCategory("CzepielDavidProyectoFinal/Cliente")]
[TaskDescription("Este task tiene como objetivo cocinar un elemento determinado\n" +
    "Este task dispone de un temporizador que representa el tiempo que vamos a tardar en cocinar algo")]
public class Comer : Action
{
    [Tooltip("Silla para sentarme")]
    public SharedGameObject miPedido;

    private Menu miMenu;

    public float tiempoComerAlgo = 3;

    private float timer;

    public SharedBool irBaño;

    public override void OnStart()

    {
        miMenu = miPedido.Value.GetComponent<Menu>();
        timer = tiempoComerAlgo;
    }

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