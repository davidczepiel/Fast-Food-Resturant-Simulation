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
        public List<GameObject> lugaresHacerHamburguesas = new List<GameObject>();

        public GameObject padreLugaresHacerPatatas;
        public List<GameObject> lugaresHacerPatatas = new List<GameObject>();

        public GameObject padreLugaresHacerBebida;
        public List<GameObject> lugaresHacerBebidas = new List<GameObject>();

        public GameObject padreLugaresHacerHelado;
        public List<GameObject> lugaresHacerHelados = new List<GameObject>();

        private List<bool> ocupados = new List<bool>();

        public List<GameObject> pedidosHaciendose = new List<GameObject>();

        private void Start()
        {
            Transform[] allChildren = padreLugaresHacerHamburguesa.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugaresHacerHamburguesas.Add(child.gameObject);
            }
            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            lugaresHacerHamburguesas.RemoveAt(0);

            allChildren = padreLugaresHacerPatatas.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugaresHacerPatatas.Add(child.gameObject);
            }
            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            lugaresHacerPatatas.RemoveAt(0);

            allChildren = padreLugaresHacerBebida.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugaresHacerBebidas.Add(child.gameObject);
            }
            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            lugaresHacerBebidas.RemoveAt(0);

            allChildren = padreLugaresHacerHelado.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                lugaresHacerHelados.Add(child.gameObject);
            }
            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            lugaresHacerHelados.RemoveAt(0);
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

                case MenuItem.Bebida:
                    return dameLugarHacerBebidas();
                    break;

                case MenuItem.Helado:
                    return dameLugarHacerHelados();
                    break;

                default:
                    return null;
                    break;
            }
        }

        private GameObject dameLugarHacerHamburguesa()
        {
            int i = Random.Range(0, lugaresHacerHamburguesas.Count - 1);
            return lugaresHacerHamburguesas[i];
        }

        private GameObject dameLugarHacerPatatas()
        {
            int i = Random.Range(0, lugaresHacerPatatas.Count - 1);
            return lugaresHacerPatatas[i];
        }

        private GameObject dameLugarHacerBebidas()
        {
            int i = Random.Range(0, lugaresHacerBebidas.Count - 1);
            return lugaresHacerBebidas[i];
        }

        private GameObject dameLugarHacerHelados()
        {
            int i = Random.Range(0, lugaresHacerHelados.Count - 1);
            return lugaresHacerHelados[i];
        }

        public void empezarPedido(GameObject nuevo)
        {
            pedidosHaciendose.Add(nuevo);
        }

        public void quitarPedido(GameObject pedido)
        {
            if (pedidosHaciendose.Contains(pedido))
                pedidosHaciendose.Remove(pedido);
        }

        public bool hayPedidosHaciendose()
        {
            return pedidosHaciendose.Count > 0;
        }

        public bool pedidoHaciendose(GameObject pedido)
        {
            return pedidosHaciendose.Contains(pedido);
        }

        public GameObject pedidoEnElQueAyudar(List<int> posiblesElementos)
        {
            GameObject pedido = null;
            int i = 0;
            bool bucle = true;
            while (i < pedidosHaciendose.Count && bucle)
            {
                GameObject actual = pedidosHaciendose[i];
                Menu menu = actual.GetComponent<Menu>();
                for (int j = 0; j < posiblesElementos.Count; j++)
                {
                    if (menu.menuRequiereItem((MenuItem)posiblesElementos[j]) && !menu.itemHecho((MenuItem)posiblesElementos[j]))
                    {
                        bucle = false;
                        pedido = actual;
                        break;
                    }
                }
                i++;
            }

            return pedido;
        }

        public GameObject pedidoTerminadoParteCocina()
        {
            GameObject pedido = null;

            int i = 0;
            bool bucle = true;
            while (i < pedidosHaciendose.Count && bucle)
            {
                GameObject actual = pedidosHaciendose[i];
                Menu menu = actual.GetComponent<Menu>();
                if (menu.cocinaTerminado())
                {
                    pedido = actual;
                    bucle = false;
                }
                i++;
            }
            return pedido;
        }
    }
}