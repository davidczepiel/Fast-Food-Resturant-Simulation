namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ClientesManager : MonoBehaviour
    {
        public List<Menu> menusPersonalizados = new List<Menu>();
        public GameObject menuDefecto;

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public GameObject dameUnMenu()
        {
            GameObject nuevo = Instantiate(menuDefecto, new Vector3(0, 0, 0), Quaternion.identity);

            if (menusPersonalizados.Count > 0)
            {
                Menu actual = menusPersonalizados[0];
                menusPersonalizados.RemoveAt(0);
                return nuevo;
            }
            else
            {
                Menu defecto = nuevo.GetComponent<Menu>();
                defecto.añadirItem(MenuItem.Hamburguesa);
                defecto.añadirItem(MenuItem.Patatas);
                defecto.añadirItem(MenuItem.Bebida);
                defecto.añadirItem(MenuItem.Helado);
                return nuevo;
            }
        }

        public void añadirMenuPersonalizado()
        {
        }
    }
}