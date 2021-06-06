namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CajaManager : MonoBehaviour
    {
        //Menu que se va a ofrecer
        public GameObject menuPrefab;

        private List<GameObject> pedidosParaCompletar = new List<GameObject>();
        private List<GameObject> pedidosParaRecoger = new List<GameObject>();
        private List<GameObject> pedidosParaEmpezar = new List<GameObject>();

        private List<bool> cajaAtendida = new List<bool>();
        private List<bool> clienteEnCaja = new List<bool>();

        public GameObject lugarCaja;

        private void Start()
        {
            cajaAtendida.Add(false);

            clienteEnCaja.Add(false);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public bool hayPedidosParaEmpezar()
        {
            return pedidosParaEmpezar.Count > 0;
        }

        public bool hayPedidosParaCompletar()
        {
            return pedidosParaCompletar.Count > 0;
        }

        public bool hayPedidosParaRecoger()
        {
            return pedidosParaRecoger.Count > 0;
        }

        public GameObject pedidoPorEmpezar()
        {
            GameObject nuevo = pedidosParaEmpezar[0];
            //pedidosParaEmpezar.RemoveAt(0);
            return nuevo;
        }

        public GameObject pedidoPorCompletar()
        {
            GameObject nuevo = pedidosParaCompletar[0];
            pedidosParaCompletar.RemoveAt(0);
            return nuevo;
        }

        public GameObject pedidoPorEntregar()
        {
            GameObject nuevo = pedidosParaRecoger[0];
            pedidosParaRecoger.RemoveAt(0);
            return nuevo;
        }

        public bool hayClientesParaPedir()
        {
            int i = 0;
            while (i < clienteEnCaja.Count && !clienteEnCaja[i])
                i++;
            return i < clienteEnCaja.Count;
        }

        public void atenderCliente()
        {
            int i = 0;
            while (i < clienteEnCaja.Count && (!clienteEnCaja[i] || (clienteEnCaja[i] && cajaAtendida[i])))
                i++;

            cajaAtendida[i] = true;
        }

        public int darCajaCliente()
        {
            int i = 0;
            //while (!clienteEnCaja[i]) i++;
            clienteEnCaja[0] = true;
            return 0;
        }

        public bool meHanAtendido(int numCaja)
        {
            return cajaAtendida[numCaja];
        }

        public void hacerPedido(int numCaja, GameObject pedidoNuevo)
        {
            //pedidosParaCompletar.Add(pedidoNuevo);
            pedidosParaEmpezar.Add(pedidoNuevo);
            pedidosParaRecoger.Add(pedidoNuevo);
            clienteEnCaja[numCaja] = false;
        }

        public bool miPedidoListo(int id)
        {
            //int i = 0;
            //while (i < pedidosParaCompletar.Count && pedidosParaCompletar[i].IDPedido != id)
            //    i++;

            //return i < pedidosParaCompletar.Count;
            return false;
        }

        public GameObject damePedido()
        {
            return Instantiate(menuPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}