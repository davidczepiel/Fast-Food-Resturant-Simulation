namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ClientesManager : MonoBehaviour
    {
        public List<List<bool>> menusPersonalizados = new List<List<bool>>();
        public GameObject menuDefecto;
        public GameObject clientePrefab;

        public List<bool> elementosSiguientePedido = new List<bool>();

        public Vector3 posSpwan;

        public float cadencia = 2;

        private float timer;

        // Start is called before the first frame update
        private void Start()
        {
            timer = cadencia;
            elementosSiguientePedido.Add(false);
            elementosSiguientePedido.Add(false);
            elementosSiguientePedido.Add(false);
            elementosSiguientePedido.Add(false);
        }

        // Update is called once per frame
        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = cadencia;
                //Instantiate(clientePrefab, posSpwan, Quaternion.identity);
            }
        }

        public GameObject dameUnMenu()
        {
            GameObject nuevo = Instantiate(menuDefecto, new Vector3(0, 0, 0), Quaternion.identity);

            List<bool> actual;
            if (menusPersonalizados.Count > 0)
            {
                actual = menusPersonalizados[0];
                menusPersonalizados.RemoveAt(0);
            }
            else
            {
                actual = new List<bool>();
                actual.Add(true);
                actual.Add(true);
                actual.Add(true);
                actual.Add(true);
            }
            Menu menu = nuevo.GetComponent<Menu>();
            for (int i = 0; i < actual.Count; i++)
            {
                if (actual[i])
                    menu.añadirItemAlPedido((MenuItem)i);
            }
            return nuevo;
        }

        public void toggleMenuItem(int item)
        {
            elementosSiguientePedido[item] = !elementosSiguientePedido[item];
        }

        public void generarPedido()
        {
            List<bool> nueva = new List<bool>();
            for (int i = 0; i < elementosSiguientePedido.Count; i++)
            {
                if (elementosSiguientePedido[i])
                    nueva.Add(true);
                else
                    nueva.Add(false);
            }
            menusPersonalizados.Add(nueva);
            Instantiate(clientePrefab, posSpwan, Quaternion.identity);
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