namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public enum Pensamiento
    {
        hamburguesa, patatas, bebida,
        helado, baño, papelera, comer, esperar, relax, cajaregistradora, satisfecho, hacerPedido, recogerPedido
    };

    public class AgentePiensa : MonoBehaviour
    {
        public GameObject camera;

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

        public float tiempoMostrar = 2;
        private float timer;

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

        public void mostrarImagen(MenuItem nuevo)
        {
            switch (nuevo)
            {
                case MenuItem.Hamburguesa:
                    mostrarImagen(Pensamiento.hamburguesa);
                    break;

                case MenuItem.Patatas:
                    mostrarImagen(Pensamiento.patatas);
                    break;

                case MenuItem.Bebida:
                    mostrarImagen(Pensamiento.bebida);
                    break;

                case MenuItem.Helado:
                    mostrarImagen(Pensamiento.helado);
                    break;
            }
        }

        public void mostrarImagen(Pensamiento nuevo)
        {
            switch (nuevo)
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
            }
            timer = tiempoMostrar;
            miImagen.enabled = true;
        }
    }
}