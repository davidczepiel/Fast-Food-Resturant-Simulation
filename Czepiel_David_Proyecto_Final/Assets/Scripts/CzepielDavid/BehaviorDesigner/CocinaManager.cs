namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CocinaManager : MonoBehaviour
    {
        //Menu que se va a ofrecer
        public GameObject menuPrefab;

        private List<Menu> pedidosParaDar;

        //Posiciones de la cola
        public GameObject padreLugares;

        public List<GameObject> lugares = new List<GameObject>();
        private List<bool> ocupados = new List<bool>();

        public GameObject lugarCaja;

        private bool ocupado = true;
        private int ticketActual = 0;
        private int turno = 0;

        private void Start()
        {
            pedidosParaDar = new List<Menu>();
            Menu ejemplo = new Menu();
            ejemplo.añadirItem(MenuItem.Hamburguesa);
            ejemplo.añadirItem(MenuItem.Patatas);
            ejemplo.añadirItem(MenuItem.Bebida);
            ejemplo.añadirItem(MenuItem.Helado);
            pedidosParaDar.Add(ejemplo);

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
            if (Input.GetKeyDown("space"))
            {
                ocupado = false;
            }
        }

        public bool meToca(int turnoEsperando)
        {
            if (turnoEsperando == turno && !ocupado)
            {
                turno++;
                ocupado = true;
                return true;
            }
            else
                return false;
        }

        public int miPosicionEnLaCola(int ticketCliente)
        {
            return ticketCliente - turno;
        }

        public int dameLugarCola()
        {
            return ticketActual++;
        }

        public GameObject dameLugar(int turnoCliente)
        {
            return lugares[turnoCliente - turno];
        }

        public void liberarLugar(GameObject libre)
        {
            int result = lugares.FindIndex(element => element == libre);
            ocupados[result] = false;
        }

        public bool miPedidoListo(int id)
        {
            int i = 0;
            while (i < pedidosParaDar.Count && pedidosParaDar[i].IDPedido != id)
                i++;

            return i < pedidosParaDar.Count;
        }

        public GameObject damePedido()
        {
            return Instantiate(menuPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}