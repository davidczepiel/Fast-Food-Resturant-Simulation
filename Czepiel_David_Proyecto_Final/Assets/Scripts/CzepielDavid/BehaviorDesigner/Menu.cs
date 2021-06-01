namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public enum MenuItem { Hamburguesa, Patatas, Bebida, Helado };

    public class Menu : MonoBehaviour
    {
        // Start is called before the first frame update
        private List<bool> menuItemsCompleted;

        private List<bool> menuItemsComer;

        private int itemsParaComer = 0;

        private int ordenComer = 0;

        private void Start()
        {
            menuItemsComer = new List<bool>();
            menuItemsComer.Add(true);
            menuItemsComer.Add(true);
            menuItemsComer.Add(true);
            menuItemsComer.Add(true);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void añadirItem(MenuItem item)
        {
            //menuItemsComer[(int)item] = true;
            itemsParaComer++;
        }

        public void servir()
        {
        }

        /// <summary>
        /// Devuelve true/false dependiendo de si ha terminado de comer los elementos principales (helado no)
        /// </summary>
        /// <returns></returns>
        public bool comer()
        {
            while (ordenComer < menuItemsComer.Count && !menuItemsComer[ordenComer]) ordenComer++;
            if (ordenComer < menuItemsComer.Count) menuItemsComer[ordenComer] = false;

            ordenComer++;
            return ordenComer >= menuItemsComer.Count;
        }

        public bool meQuedaPostre()
        {
            return menuItemsComer[(int)MenuItem.Helado];
        }
    }
}