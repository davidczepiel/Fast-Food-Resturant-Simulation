namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public enum MenuItem { Hamburguesa, Patatas, Bebida, Helado };

    public class Menu : MonoBehaviour
    {
        public List<GameObject> misCosas;

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
            for (int i = 0; i < misCosas.Count; i++)
            {
                misCosas[i].SetActive(false);
            }
        }

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

        public bool cocinaTerminado()
        {
            bool cierto = true;
            if (!elementosMenu[0] && pedido[0])
                cierto = false;
            if (!elementosMenu[1] && pedido[1])
                cierto = false;

            return cierto;
        }

        public bool menuRequiereItem(MenuItem item)
        {
            return pedido[(int)item];
        }

        public void empezarHacerItem(MenuItem item)
        {
            elementosHaciendose[(int)item] = true;
        }

        public void itemMenuCompletado(MenuItem item)
        {
            elementosMenu[(int)item] = true;
            misCosas[(int)item].SetActive(true);
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