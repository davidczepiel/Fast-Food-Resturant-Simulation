namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using BehaviorDesigner.Runtime;
    using BehaviorDesigner.Runtime.Tasks;

    using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
    using UnityEngine.AI;

    public class LugaresManager : MonoBehaviour
    {
        public GameObject padreLugares;
        public List<GameObject> lugares = new List<GameObject>();
        private List<bool> ocupados = new List<bool>();

        // Start is called before the first frame update
        private void Start()
        {
            Transform[] allChildren = padreLugares.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugares.Add(child.gameObject);
                ocupados.Add(false);
            }
            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            lugares.RemoveAt(0);
            ocupados.RemoveAt(0);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public GameObject dameLugar()
        {
            int i = 0;
            while (i < ocupados.Count && ocupados[i])
            {
                i++;
            }

            ocupados[i] = true;
            return lugares[i];
        }

        public void liberarLugar(GameObject libre)
        {
            int result = lugares.FindIndex(element => element == libre);
            ocupados[result] = false;
        }

        public bool hayHueco()
        {
            int i = 0;
            while (i < ocupados.Count && ocupados[i])
            {
                i++;
            }
            return i < ocupados.Count;
        }
    }
}