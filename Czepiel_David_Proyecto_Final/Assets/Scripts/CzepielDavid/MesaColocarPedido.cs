namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MesaColocarPedido : MonoBehaviour
    {
        //Padre de las mesas
        public GameObject padreLugares;

        //Lista de mesas
        public List<GameObject> mesas = new List<GameObject>();

        //Separación entre cada uno de los pedidos acumulados
        public Vector3 separacion = new Vector3(0, 2.5f, 0);

        //lista de listas que representa los pedidos acumulados en cada mesa
        private List<List<GameObject>> pedidosAcumulados = new List<List<GameObject>>();

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

        /// <summary>
        /// Devuelve la mesa con menos menus acumulados para dejar un nuevo menu en ella
        /// </summary>
        /// <returns>Mesa en la que dejar el menu</returns>
        public GameObject dameMesaParaDejarMenu()
        {
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

        /// <summary>
        /// Devuelve la mesa que contenga un pedido determinado
        /// </summary>
        /// <param name="pedido">pedido que estamos buscando</param>
        /// <returns>mesa que contiene el pedido</returns>
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

        /// <summary>
        /// Se deja un pedido determinado en una mesa que nosostros indiquemos
        /// </summary>
        /// <param name="mesa">mesa en la que dejar el pedido</param>
        /// <param name="pedido">pedido que vamos a dejar</param>
        public void dejarPedidoEnMesa(GameObject mesa, GameObject pedido)
        {
            pedidosAcumulados[mesas.IndexOf(mesa)].Add(pedido);
            pedido.transform.position = mesa.transform.position + (separacion * pedidosAcumulados[mesas.IndexOf(mesa)].Count);
        }

        /// <summary>
        /// Se elimina un pedido determinado de las acumulaciones de las  mesas
        /// </summary>
        /// <param name="pedido">pedido que queremos quitar</param>
        public void quitarPedidoDeLasMesas(GameObject pedido)
        {
            int i = 0;
            while (i < pedidosAcumulados.Count)
            {
                if (pedidosAcumulados[i].Contains(pedido)) break;
                i++;
            }

            pedidosAcumulados[i].Remove(pedido);

            for (int j = 0; j < pedidosAcumulados[i].Count; j++)
            {
                pedidosAcumulados[i][j].transform.position = mesas[i].transform.position + (separacion * (1 + j));
            }
        }
    }
}