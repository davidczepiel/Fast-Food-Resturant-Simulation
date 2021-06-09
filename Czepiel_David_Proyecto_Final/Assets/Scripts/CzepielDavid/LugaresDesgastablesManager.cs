namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using BehaviorDesigner.Runtime;
    using BehaviorDesigner.Runtime.Tasks;

    using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
    using UnityEngine.AI;

    public class LugaresDesgastablesManager : MonoBehaviour
    {
        public List<GameObject> lugares = new List<GameObject>();
        public float tiempoRepararSolo = 20;
        public int usosHastaDesgaste = 1;
        private List<bool> ocupados = new List<bool>();
        private List<bool> reparrables = new List<bool>();
        private List<int> usosRestantes = new List<int>();

        private List<float> timerRepararSolos = new List<float>();

        public GameObject lugarEmpiezaCola;
        public Vector3 desplazamiento;

        private int ticketActual = 0;
        private int turno = 0;

        // Start is called before the first frame update
        private void Start()
        {
            for (int i = 0; i < lugares.Count; i++)
            {
                float a = tiempoRepararSolo;
                ocupados.Add(false);
                reparrables.Add(false);
                usosRestantes.Add(usosHastaDesgaste);
                timerRepararSolos.Add(a);
            }
        }

        // Update is called once per frame
        private void Update()
        {
            float tiempo = Time.deltaTime;
            for (int i = 0; i < timerRepararSolos.Count; i++)
            {
                if (reparrables[i] && ocupados[i])
                {
                    timerRepararSolos[i] -= tiempo;
                    if (timerRepararSolos[i] <= 0)
                    {
                        timerRepararSolos[i] = tiempoRepararSolo;
                        reparrables[i] = false;
                        ocupados[i] = false;
                    }
                }
            }
        }

        public GameObject dameLugar()
        {
            int i = 0;
            while (i < ocupados.Count && (ocupados[i] || reparrables[i]))
            {
                i++;
            }

            ocupados[i] = true;
            usosRestantes[i] -= 1;
            return lugares[i];
        }

        public Vector3 dameLugarVector(int turnoCliente)
        {
            int cantidadDesplazar = turnoCliente - turno;
            Vector3 pos = lugarEmpiezaCola.transform.position;
            pos += (desplazamiento * cantidadDesplazar);
            return pos;
        }

        public bool hayLugarQueArreglar()
        {
            int i = 0;
            while (i < lugares.Count && (!reparrables[i] || (reparrables[i] && ocupados[i])))
                i++;

            return i < lugares.Count;
        }

        public GameObject dameLugarParaArreglar()
        {
            int i = 0;
            while (i < lugares.Count && (!reparrables[i] || (reparrables[i] && ocupados[i])))
                i++;

            reparrables[i] = true;
            ocupados[i] = true;
            return lugares[i];
        }

        public Vector3 dameLugarParaArreglarVector()
        {
            return dameLugarParaArreglar().transform.position;
        }

        public void liberarLugar(GameObject libre)
        {
            int result = lugares.FindIndex(element => element == libre);
            ocupados[result] = false;
            if (usosRestantes[result] <= 0)
                reparrables[result] = true;
        }

        public void repararLugar(GameObject libre)
        {
            int result = lugares.FindIndex(element => element == libre);
            if (result >= 0)
            {
                ocupados[result] = false;
                reparrables[result] = false;
                usosRestantes[result] = 1;
            }
        }

        public bool hayHueco()
        {
            int i = 0;
            while (i < ocupados.Count && (ocupados[i] || reparrables[i]))
            {
                i++;
            }
            return i < ocupados.Count;
        }

        public bool meToca(int turnoEsperando)
        {
            if (turnoEsperando == turno && hayHueco())
            {
                turno++;
                return true;
            }
            else
                return false;
        }

        public int dameLugarCola()
        {
            return ticketActual++;
        }

        public int posDentroCola(int ticketCliente)
        {
            return ticketCliente - turno;
        }
    }
}