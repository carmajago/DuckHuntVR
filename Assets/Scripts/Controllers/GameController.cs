using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public int round = 1;
    public int dificulty = 1;
    public int score = 0;
    public int min_ducks = 6;
    public int ducks_kill = 0;

    public AudioSource gameOver;
    public AudioSource fail;
    public AudioSource perfec;
    public AudioSource roundClear;
    public AudioSource countingHits;

    public GameObject perro_miedo;
    public GameObject perro_captura_1;

    public List<GameObject> duck_sprites;
    public GameObject duck_prefab;
    public GunController gunController;

    public TextMeshProUGUI score_text;
    public TextMeshProUGUI round_text;

    private int contador_patos;
    private CountGUIDucksController countGUI;
    private void Start()
    {
        gunController = GameObject.FindObjectOfType<GunController>();
        if (dificulty == 1)
            StartCoroutine(crearPato_1());
        else
            StartCoroutine(crearPato_2());

        countGUI = GameObject.FindObjectOfType<CountGUIDucksController>();
        countGUI.refrescarDifucultad(min_ducks);
    }



    public IEnumerator crearPato_1()
    {
        yield return new WaitForSeconds(8f);
        while (true)
        {
            contador_patos = 0;
            ducks_kill = 0;
            GameObject duck = null;
            round_text.text = round.ToString();

            while (contador_patos < 11 )
            {
              
                if (duck == null)
                {

                    if (contador_patos == 10)
                    {
                        contador_patos++;
                        break;
                    }
                    gunController.recargar();

                    duck = Instantiate(duck_prefab);
                    duck.GetComponent<DuckController>().duck_sprite = duck_sprites[contador_patos].GetComponent<SpriteRenderer>();
                    contador_patos++;
                }
                yield return new WaitForSeconds(0.1f);
            }
            for (int i = 0; i < 10; i++)
            {

                if (duck_sprites[i].GetComponent<SpriteRenderer>().color == Color.red)
                {
                    if (i > 0)
                        if (duck_sprites[i - 1].GetComponent<SpriteRenderer>().color != Color.red)
                        {
                            duck_sprites[i - 1].GetComponent<SpriteRenderer>().color = Color.red;
                            duck_sprites[i].GetComponent<SpriteRenderer>().color = Color.white;
                            i-=2;
                            countingHits.Play();
                            yield return new WaitForSeconds(0.3f);
                        }
                }
            }

            StartCoroutine(parpadearPatos());
    


            if (ducks_kill < min_ducks) {

                fail.Play();
                yield return new WaitForSeconds(2f);
                gameOver.Play();
                break;
            }else if (ducks_kill == 10)
            {
                roundClear.Play();
                yield return new WaitForSeconds(4.5f);
                GameObject.FindGameObjectWithTag("perfect").GetComponent<SpriteRenderer>().enabled = true;
                perfec.Play();
                yield return new WaitForSeconds(2f);

                GameObject.FindGameObjectWithTag("perfect").GetComponent<SpriteRenderer>().enabled = false;




            }
            else
            {
                roundClear.Play();
                yield return new WaitForSeconds(5f);

            }



            if (min_ducks < 10)
                min_ducks++;
            countGUI.refrescarDifucultad(min_ducks);

            despintarPatos();
            round++;
        }

       
    }
  
    public IEnumerator crearPato_2()
    {
        yield return null;

    }
    public IEnumerator parpadearPatos()
    {
        for (int i = 0; i < 10; i++)
        {

            foreach (var item in duck_sprites)
            {
                item.SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);

            foreach (var item in duck_sprites)
            {
                item.SetActive(true);
            }
        }
    }

    public void pato_perdido()
    {
        perro_miedo.GetComponent<Animator>().SetTrigger("inicio");
        StartCoroutine(retraso_sonido());
    }
    IEnumerator retraso_sonido()
    {
        yield return new WaitForSeconds(0.3f);
        perro_miedo.GetComponent<AudioSource>().Play();

    }

    public void pato1_capturado()
    {
        perro_captura_1.GetComponent<Animator>().SetTrigger("inicio");
        perro_captura_1.GetComponent<AudioSource>().Play();


    }

    public void despintarPatos()
    {
        foreach (var item in duck_sprites)
        {
            item.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
