namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ClientesManager : MonoBehaviour
    {
        public List<Menu> menusPersonalizados = new List<Menu>();
        public GameObject menuDefecto;
        public GameObject clientePrefab;

        public Vector3 posSpwan;

        public float cadencia = 2;

        private float timer;

        // Start is called before the first frame update
        private void Start()
        {
            timer = cadencia;
        }

        // Update is called once per frame
        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = cadencia;
                Instantiate(clientePrefab, posSpwan, Quaternion.identity);
            }
        }

        public GameObject dameUnMenu()
        {
            GameObject nuevo = Instantiate(menuDefecto, new Vector3(0, 0, 0), Quaternion.identity);

            //if (menusPersonalizados.Count > 0)
            //{
            //    Menu actual = menusPersonalizados[0];
            //    menusPersonalizados.RemoveAt(0);
            //    return nuevo;
            //}
            //else
            //{
            Menu defecto = nuevo.GetComponent<Menu>();
            defecto.añadirItemAlPedido(MenuItem.Hamburguesa);
            defecto.añadirItemAlPedido(MenuItem.Patatas);
            defecto.añadirItemAlPedido(MenuItem.Bebida);
            defecto.añadirItemAlPedido(MenuItem.Helado);
            return nuevo;
            //}
        }

        public void clienteHaTerminado(GameObject cliente)
        {
            GameObject.Destroy(cliente);
        }

        public GameObject dameUnMenuHecho()
        {
            GameObject nuevo = Instantiate(menuDefecto, new Vector3(0, 0, 0), Quaternion.identity);

            //if (menusPersonalizados.Count > 0)
            //{
            //    Menu actual = menusPersonalizados[0];
            //    menusPersonalizados.RemoveAt(0);
            //    return nuevo;
            //}
            //else
            //{
            Menu defecto = nuevo.GetComponent<Menu>();
            defecto.añadirItemAlPedido(MenuItem.Hamburguesa);
            defecto.añadirItemAlPedido(MenuItem.Patatas);
            defecto.añadirItemAlPedido(MenuItem.Bebida);
            defecto.añadirItemAlPedido(MenuItem.Helado);
            defecto.itemMenuCompletado(MenuItem.Hamburguesa);
            defecto.itemMenuCompletado(MenuItem.Patatas);
            defecto.itemMenuCompletado(MenuItem.Bebida);
            defecto.itemMenuCompletado(MenuItem.Helado);
            return nuevo;
            //}
        }

        public void añadirMenuPersonalizado()
        {
        }
    }
}