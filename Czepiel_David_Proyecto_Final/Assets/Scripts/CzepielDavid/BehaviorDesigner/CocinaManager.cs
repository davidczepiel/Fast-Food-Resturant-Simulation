namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CocinaManager : MonoBehaviour
    {
        //Menu que se va a ofrecer
        public GameObject menuPrefab;

        public GameObject padreLugaresHacerHamburguesa;
        public List<GameObject> lugaresHacerHamburguesa = new List<GameObject>();

        public GameObject padreLugaresHacerPatatas;
        public List<GameObject> lugaresHacerPatatas = new List<GameObject>();

        private List<bool> ocupados = new List<bool>();

        public List<GameObject> pedidosHaciendose = new List<GameObject>();

        private void Start()
        {
            Transform[] allChildren = padreLugaresHacerHamburguesa.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugaresHacerHamburguesa.Add(child.gameObject);
            }
            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            lugaresHacerHamburguesa.RemoveAt(0);

            allChildren = padreLugaresHacerPatatas.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugaresHacerPatatas.Add(child.gameObject);
            }
            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            lugaresHacerPatatas.RemoveAt(0);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public GameObject dameLugarHacerItem(MenuItem item)
        {
            switch (item)
            {
                case MenuItem.Hamburguesa:
                    return dameLugarHacerHamburguesa();
                    break;

                case MenuItem.Patatas:
                    return dameLugarHacerPatatas();
                    break;

                default:
                    return null;
                    break;
            }
        }

        private GameObject dameLugarHacerHamburguesa()
        {
            int i = Random.Range(0, lugaresHacerHamburguesa.Count - 1);
            return lugaresHacerHamburguesa[i];
        }

        private GameObject dameLugarHacerPatatas()
        {
            int i = Random.Range(0, lugaresHacerPatatas.Count - 1);
            return lugaresHacerPatatas[i];
        }

        public void empezarPedido(GameObject nuevo)
        {
            pedidosHaciendose.Add(nuevo);
        }

        public bool hayPedidosHaciendose()
        {
            return pedidosHaciendose.Count > 0;
        }
    }
}