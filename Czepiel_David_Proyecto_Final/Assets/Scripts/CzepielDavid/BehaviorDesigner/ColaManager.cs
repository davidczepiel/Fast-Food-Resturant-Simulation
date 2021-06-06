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
            ejemplo.itemMenuCompletado(MenuItem.Hamburguesa);
            ejemplo.itemMenuCompletado(MenuItem.Patatas);
            ejemplo.itemMenuCompletado(MenuItem.Bebida);
            ejemplo.itemMenuCompletado(MenuItem.Helado);
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