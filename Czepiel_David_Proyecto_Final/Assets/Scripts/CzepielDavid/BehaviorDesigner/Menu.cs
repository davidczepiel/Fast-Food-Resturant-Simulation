﻿namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public enum MenuItem { Hamburguesa, Patatas, Bebida, Helado };

    public class Menu : MonoBehaviour
    {
        private List<bool> elementosMenu = new List<bool>() { false, false, false, false };
        private List<bool> elementosHaciendose = new List<bool>() { false, false, false, false };
        private List<bool> pedido = new List<bool>() { false, false, false, false };

        private int itemsParaComer = 0;

        private int ordenComer = 0;

        public int IDPedido = 0;

        private bool listo = false;
        private bool recogido = false;

        private void Start()
        {
            //for (int i = 0; i < 4; i++)
            //{
            //    elementosMenu.Add(false);
            //    elementosHaciendose.Add(false);
            //    pedido.Add(false);
            //}
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void añadirItemAlPedido(MenuItem item)
        {
            pedido[(int)item] = true;
        }

        public bool itemHecho(MenuItem item)
        {
            return elementosMenu[(int)item] || elementosHaciendose[(int)item];
        }

        public void itemMenuCompletado(MenuItem item)
        {
            elementosMenu[(int)item] = true;
            itemsParaComer++;
        }

        public bool menuCompletado()
        {
            int i = 0;
            while (i < pedido.Count && pedido[i] == elementosMenu[i]) i++;

            return i >= pedido.Count;
        }

        public void setId(int id)
        {
            IDPedido = id;
        }

        public int getID()
        {
            return IDPedido;
        }

        public void setListo(bool a)
        {
            listo = a;
        }

        public bool getListo()
        {
            return listo;
        }

        public void setRecogido(bool a)
        {
            recogido = a;
        }

        public bool getRecogido()
        {
            return recogido;
        }

        /// <summary>
        /// Devuelve true/false dependiendo de si ha terminado de comer los elementos principales (helado no)
        /// </summary>
        /// <returns></returns>
        public bool comer()
        {
            while (ordenComer < elementosMenu.Count && !elementosMenu[ordenComer]) ordenComer++;
            if (ordenComer < elementosMenu.Count) elementosMenu[ordenComer] = false;

            ordenComer++;
            return ordenComer >= elementosMenu.Count;
        }

        public bool meQuedaPostre()
        {
            return elementosMenu[(int)MenuItem.Helado];
        }
    }
}