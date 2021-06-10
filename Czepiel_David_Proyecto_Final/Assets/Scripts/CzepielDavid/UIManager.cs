namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UIManager : MonoBehaviour
    {
        public List<GameObject> imagenesMandar;

        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void mostrarElementos(List<bool> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                imagenesMandar[i].SetActive(lista[i]);
            }
        }

        public void cambiarVisibilidadElemento(MenuItem item)
        {
            imagenesMandar[(int)item].SetActive(!imagenesMandar[(int)item].activeSelf);
        }
    }
}