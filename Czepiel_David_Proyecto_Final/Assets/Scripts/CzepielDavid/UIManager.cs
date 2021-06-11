namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UIManager : MonoBehaviour
    {
        //Imagenes que vamos a ir activando/desactivando
        public List<GameObject> imagenesMandar;

        /// <summary>
        /// Metodo que sirve para activar/desactivar las imagenes de la UI dependiendo de la lista del bools que nos llega
        /// </summary>
        /// <param name="lista">lista de bools que representa el estado de las imagenes que queremos obteenr</param>
        public void mostrarElementos(List<bool> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                imagenesMandar[i].SetActive(lista[i]);
            }
        }

        /// <summary>
        /// Metodo que sirve para cambiar la visibilidad de una imagen en concreto
        /// </summary>
        /// <param name="item">item cuya imagen queremos modificar</param>
        public void cambiarVisibilidadElemento(MenuItem item)
        {
            imagenesMandar[(int)item].SetActive(!imagenesMandar[(int)item].activeSelf);
        }
    }
}