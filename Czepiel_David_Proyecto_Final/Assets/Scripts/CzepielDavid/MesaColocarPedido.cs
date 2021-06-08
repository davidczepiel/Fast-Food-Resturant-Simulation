namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MesaColocarPedido : MonoBehaviour
    {
        // Start is called before the first frame update
        private List<List<GameObject>> pedidosAcumulados = new List<List<GameObject>>();

        public GameObject padreLugares;
        public List<GameObject> mesas = new List<GameObject>();

        public Vector3 separacion = new Vector3(0, 2.5f, 0);

        private void Start()
        {
            Transform[] allChildren = padreLugares.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                mesas.Add(child.gameObject);
                pedidosAcumulados.Add(new List<GameObject>());
            }

            //Esto es debido a que se mete en el vector al propio padre, lo cual no interesa
            mesas.RemoveAt(0);
            pedidosAcumulados.RemoveAt(0);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public GameObject dameLugarPonerMenu()
        {
            GameObject lugar;
            int menorAcumulacion = 1000;
            int indice = 0;
            for (int i = 0; i < pedidosAcumulados.Count; i++)
            {
                if (pedidosAcumulados[i].Count < menorAcumulacion)
                {
                    indice = i;
                    menorAcumulacion = pedidosAcumulados[i].Count;
                }
            }
            return mesas[indice];
        }

        public GameObject dameMesaConEstePedido(GameObject pedido)
        {
            GameObject mesa = null;
            int i = 0;
            while (i < pedidosAcumulados.Count)
            {
                if (pedidosAcumulados[i].Contains(pedido))
                {
                    mesa = mesas[i];
                    break;
                }
                i++;
            }
            return mesa;
        }

        public void dejarPedidoEnMesa(GameObject mesa, GameObject pedido)
        {
            pedidosAcumulados[mesas.IndexOf(mesa)].Add(pedido);
            pedido.transform.position = mesa.transform.position + (separacion * pedidosAcumulados[mesas.IndexOf(mesa)].Count);
        }

        public void cogerPedido(GameObject pedido)
        {
            int i = 0;
            while (i < pedidosAcumulados.Count)
            {
                if (pedidosAcumulados[i].Contains(pedido)) break;
                i++;
            }

            pedidosAcumulados[i].Remove(pedido);
        }
    }
}