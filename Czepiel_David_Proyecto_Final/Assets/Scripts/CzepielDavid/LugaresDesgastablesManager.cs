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
        public GameObject padreLugares;
        public List<GameObject> lugares = new List<GameObject>();

        public GameObject padreLugaresEspera;
        public List<GameObject> lugaresEspera = new List<GameObject>();

        public int usosHastaDesgaste = 1000;
        private List<bool> ocupados = new List<bool>();
        private List<bool> reparrables = new List<bool>();
        private List<int> usosRestantes = new List<int>();

        public GameObject lugarEmpiezaCola;
        public Vector3 desplazamiento;

        private int ticketActual = 0;
        private int turno = 0;

        // Start is called before the first frame update
        private void Start()
        {
            Transform[] allChildren = padreLugares.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugares.Add(child.gameObject);
                ocupados.Add(false);
                reparrables.Add(false);
                usosRestantes.Add(usosHastaDesgaste);
            }

            allChildren = padreLugaresEspera.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugaresEspera.Add(child.gameObject);
            }
            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            lugares.RemoveAt(0);
            lugaresEspera.RemoveAt(0);
            ocupados.RemoveAt(0);
            reparrables.RemoveAt(0);
            usosRestantes.RemoveAt(0);
        }

        // Update is called once per frame
        private void Update()
        {
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

        public GameObject dameLugarEsperar(int ticket)
        {
            return lugaresEspera[ticket - turno];
        }

        public Vector3 dameLugarVector(int turnoCliente)
        {
            return lugarEmpiezaCola.transform.position + (desplazamiento * (turnoCliente - turno));
        }

        public void liberarLugar(GameObject libre)
        {
            int result = lugares.FindIndex(element => element == libre);
            ocupados[result] = false;
            if (usosRestantes[result] <= 0)
                reparrables[result] = true;
        }

        public bool hayHueco()
        {
            int i = 0;
            while (i < ocupados.Count && (ocupados[i] || reparrables[i]))
            {
                i++;
            }
            if (i < ocupados.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
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
    }
}