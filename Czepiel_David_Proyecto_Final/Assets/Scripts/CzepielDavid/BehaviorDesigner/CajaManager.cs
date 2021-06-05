namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CajaManager : MonoBehaviour
    {
        //Menu que se va a ofrecer
        public GameObject menuPrefab;

        private List<Menu> pedidosParaDar;

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
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                ocupado = false;
            }
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