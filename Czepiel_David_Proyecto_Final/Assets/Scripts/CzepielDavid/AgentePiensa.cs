using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pensamiento
{
    hamburguesa, patatas, bebida,
    helado, baño, papelera, comer, esperar, relax, cajaregistradora, satisfecho, hacerPedido, recogerPedido, pedidoCocinaTerminado
};

public class AgentePiensa : MonoBehaviour
{
    //Camara a la que nos vamos a mostrar
    public GameObject camera;

    //Lista de sprites con los que vamos a trabajar

    public Sprite hamburguesa;
    public Sprite patatas;
    public Sprite bebida;
    public Sprite helado;
    public Sprite baño;
    public Sprite papelera;
    public Sprite comer;
    public Sprite esperar;
    public Sprite relax;
    public Sprite cajaRegistradora;
    public Sprite satisfecho;
    public Sprite hacerPedido;
    public Sprite recogerPedido;
    public Sprite pedidoCocinaTerminado;

    private SpriteRenderer miImagen;

    private void Start()
    {
        camera = GameObject.Find("Main Camera");
        miImagen = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        this.transform.forward = (camera.transform.position - this.transform.position).normalized;
    }

    /// <summary>
    /// Ajustamos la imagen a mostrar a un item que nos indiquen
    /// </summary>
    /// <param name="item">item que queremos mostrar</param>
    public void mostrarImagenMenuItem(MenuItem item)
    {
        switch (item)
        {
            case MenuItem.Hamburguesa:
                mostrarImagenPensamiento(Pensamiento.hamburguesa);
                break;

            case MenuItem.Patatas:
                mostrarImagenPensamiento(Pensamiento.patatas);
                break;

            case MenuItem.Bebida:
                mostrarImagenPensamiento(Pensamiento.bebida);
                break;

            case MenuItem.Helado:
                mostrarImagenPensamiento(Pensamiento.helado);
                break;
        }
    }

    /// <summary>
    /// Ajustamos la imagen a mostrar a un pensamiento concreto
    /// </summary>
    /// <param name="pensamiento">pensamiento a mostrar</param>
    public void mostrarImagenPensamiento(Pensamiento pensamiento)
    {
        switch (pensamiento)
        {
            case Pensamiento.hamburguesa:
                miImagen.sprite = hamburguesa;
                break;

            case Pensamiento.patatas:
                miImagen.sprite = patatas;
                break;

            case Pensamiento.bebida:
                miImagen.sprite = bebida;
                break;

            case Pensamiento.helado:
                miImagen.sprite = helado;
                break;

            case Pensamiento.baño:
                miImagen.sprite = baño;
                break;

            case Pensamiento.papelera:
                miImagen.sprite = papelera;
                break;

            case Pensamiento.comer:
                miImagen.sprite = comer;
                break;

            case Pensamiento.esperar:
                miImagen.sprite = esperar;
                break;

            case Pensamiento.relax:
                miImagen.sprite = relax;
                break;

            case Pensamiento.cajaregistradora:
                miImagen.sprite = cajaRegistradora;
                break;

            case Pensamiento.satisfecho:
                miImagen.sprite = satisfecho;
                break;

            case Pensamiento.hacerPedido:
                miImagen.sprite = hacerPedido;
                break;

            case Pensamiento.recogerPedido:
                miImagen.sprite = recogerPedido;
                break;

            case Pensamiento.pedidoCocinaTerminado:
                miImagen.sprite = pedidoCocinaTerminado;
                break;
        }
    }
}