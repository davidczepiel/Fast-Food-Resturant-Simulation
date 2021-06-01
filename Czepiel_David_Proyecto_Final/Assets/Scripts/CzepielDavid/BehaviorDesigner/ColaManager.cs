namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ColaManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private List<Menu> pedidosParaDar;

        public GameObject menuPrefab;

        public GameObject puntoCola;
        public Vector3 desplazamientoCola;

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
        }

        public GameObject damePedido()
        {
            return Instantiate(menuPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}