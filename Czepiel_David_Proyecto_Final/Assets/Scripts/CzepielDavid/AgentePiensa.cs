using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentePiensa : MonoBehaviour
{
    public GameObject camera;

    public Sprite hamburguesa;
    public Sprite patatas;
    public Sprite helado;
    public Sprite bebida;

    public float tiempoMostrar = 2;
    private float timer;

    public enum Pensamiento { hamburguesa, patatas, bebida, helado };

    public SpriteRenderer miImagen;

    // Start is called before the first frame update
    private void Start()
    {
        timer = tiempoMostrar;
        camera = GameObject.Find("Main Camera");
        miImagen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            miImagen.enabled = false;
        }
        this.transform.forward = (camera.transform.position - this.transform.position).normalized;

        if (Input.GetKeyDown("space"))
        {
            mostrarImagen(Pensamiento.hamburguesa);
        }
    }

    public void mostrarImagen(Pensamiento nuevo)
    {
        switch (nuevo)
        {
            case Pensamiento.hamburguesa:
                timer = tiempoMostrar;
                miImagen.enabled = true;
                miImagen.sprite = hamburguesa;
                break;

            case Pensamiento.patatas:
                timer = tiempoMostrar;
                miImagen.enabled = true;
                miImagen.sprite = patatas;
                break;

            case Pensamiento.bebida:
                break;

            case Pensamiento.helado:
                break;
        }
    }
}