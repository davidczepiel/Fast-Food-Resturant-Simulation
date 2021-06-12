using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoAereo : MonoBehaviour
{
    //Camara a la que nos vamos a mostrar
    private GameObject camera;

    private TextMesh text;

    private void Start()
    {
        text = this.gameObject.GetComponent<TextMesh>();
        camera = GameObject.Find("Main Camera");
    }

    /// <summary>
    /// Esto metodo es utilizado para modificar el texto que se muestra
    /// </summary>
    /// <param name="texto"></param>
    public void ponerTexto(string texto)
    {
        //Esta comprobación es necesario debido a que cuando los lugares manager instancia uno de estos objetos, este método se llama antes que
        //start y por ello la varuable text aun no se ha inicializado
        if (text == null)
            text = this.gameObject.GetComponent<TextMesh>();

        text.text = texto;
        if (texto == "0")
            text.color = Color.red;
        else
            text.color = Color.white;
    }

    private void Update()
    {
        this.transform.forward = -(camera.transform.position - this.transform.position).normalized;
    }
}