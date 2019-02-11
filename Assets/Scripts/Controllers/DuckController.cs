using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckController : MonoBehaviour {

    public float time_fly = 5;
    public float speed = 1.5f;
    public SpriteRenderer duck_sprite;
    public GameObject point;
    public AudioSource sound_cuak;
    public AudioSource sound_fall;
    public AudioSource sound_lands;
    private GameObject bg;
    

    private bool init=false;
    private bool cayo=false;
    private AudioSource sound;



    private bool salida=false;
    public bool muerto=false;
    void Start() {
        sound = GetComponent<AudioSource>();
        moverArriba();
        StartCoroutine(sonar());
        StartCoroutine(cuak());
        StartCoroutine(parpadearSprite());
        bg = GameObject.FindGameObjectWithTag("Bg");
        bg.GetComponent<Image>().enabled = false;
        bg.GetComponentInChildren<SpriteRenderer>().enabled = false;


    }
    private void Update()
    {
        if(!muerto)
        moverse();
    }
    public void morir()
    {
        if (!muerto)
        {
            GameObject.FindObjectOfType<GameController>().ducks_kill++;

            duck_sprite.enabled = (true);
            salida = true;

            duck_sprite.color = Color.red;
            StopAllCoroutines();
            StartCoroutine(animacion_morir());
            //GetComponent<Collider2D>().enabled = false;
           
        }
        muerto = true;


    }

    IEnumerator animacion_morir()
            
    {

        float cont = 0;
        transform.eulerAngles = new Vector3(0, 0, 180);
        GameObject point_temp = Instantiate(point, new Vector3(transform.position.x+0.74f, transform.position.y+1.24f, transform.position.z), Quaternion.identity);

        Destroy(point_temp, 0.5f);
        yield return new WaitForSeconds(0.5f);
        sound_fall.Play();
 

        while (!cayo)
        {
            transform.Translate(Vector3.up * Time.fixedDeltaTime *4);
            cont += 0.01f;
            yield return new WaitForSeconds(0.01f);

        }
     
        



    }

    public void moverse()
    {
        transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);

    }

 
   
    public void moverArriba()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-60, 60));

    }
    IEnumerator parpadearSprite()
    {
        float cont = 0;
        while (cont<=time_fly)
        {
            duck_sprite.enabled=(true);
            yield return new WaitForSeconds(0.3f);
            duck_sprite.enabled=(false);
            yield return new WaitForSeconds(0.3f);

            cont += 0.6f;

        }
    }

    IEnumerator cuak()
    {
        float cont = 0;
        while (cont <= time_fly)
        {
            
            sound_cuak.Play();
            yield return new WaitForSeconds(0.5f);
            sound_cuak.Play();
            yield return new WaitForSeconds(1.5f);

            cont += 2f;

        }
    }

    IEnumerator sonar()
    {
        float cont = 0.5f;
        
        while (cont<=time_fly)
        {
           
            sound.Play();
            yield return new WaitForSeconds(0.13f);
            cont += 0.13f;
            
        }
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-15, 15));

        bg.GetComponent<Image>().enabled = true;
        bg.GetComponentInChildren<SpriteRenderer>().enabled = true;
        //GetComponent<Collider2D>().enabled=false;
        salida = true;
 
        yield return new WaitForSeconds(1.5f);
        GameObject.FindObjectOfType<GameController>().pato_perdido();
        bg.GetComponent<Image>().enabled = false;
        bg.GetComponentInChildren<SpriteRenderer>().enabled = false;

        StopCoroutine("parpadearSprite");
        duck_sprite.enabled = (true);
       


        Destroy(this.gameObject,1);
    }

    IEnumerator sonar_caida()
    {
        sound_fall.Stop();

        sound_lands.Play();

        yield return new WaitForSeconds(0.5f);
        GameObject.FindObjectOfType<GameController>().pato1_capturado();
        cayo = true;
        Destroy(this.gameObject, 1.5f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(init && collision.gameObject.name == "caida")
        {
            StartCoroutine(sonar_caida());
        }

        if (init && !salida)
        {


            if (collision.gameObject.name == "up")
            {
                transform.eulerAngles = new Vector3(0, 0, Random.Range(120, 250));
                

            }
            if (collision.gameObject.name == "down")
            {
                transform.eulerAngles = new Vector3(0, 0, Random.Range(-60, 60));
            }
            if (collision.gameObject.name == "left")
            {
                transform.eulerAngles = new Vector3(0, 0, Random.Range(210, 320));
            }
            if (collision.gameObject.name == "rigth")
            {
                transform.eulerAngles = new Vector3(0, 0, Random.Range(30, 150));
            
            }
 
        }
        init = true;

    }
 
}
