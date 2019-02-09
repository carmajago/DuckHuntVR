using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int level=1;
    public int dificulty=1;
    public int score = 0;

    public GameObject perro_miedo;
    public GameObject perro_captura_1;

    public List<GameObject> duck_sprites;
    public GameObject duck_prefab;
    public GunController gunController;
    private int contador_patos;

    private void Start()
    {
        gunController = GameObject.FindObjectOfType<GunController>();
        if(dificulty == 1)
        StartCoroutine(crearPato_1());
        else
        StartCoroutine(crearPato_2());
    }



    public IEnumerator crearPato_1()
    {
        GameObject duck = null;
        yield return new WaitForSeconds(8f);

        while (contador_patos < 10)
        {
            if(duck == null)
            {
                Debug.Log(contador_patos);

                gunController.recargar();
               
                duck= Instantiate(duck_prefab);
                duck.GetComponent<DuckController>().duck_sprite = duck_sprites[contador_patos].GetComponent<SpriteRenderer>();
                contador_patos++;
            }
            yield return new WaitForSeconds(0.1f);
        }


    }
    public IEnumerator crearPato_2()
    {
        GameObject duck = null;
        yield return new WaitForSeconds(8f);

        while (contador_patos < 10)
        {
            if (duck == null)
            {
                Debug.Log(contador_patos);
                gunController.recargar();

                duck = Instantiate(duck_prefab);
                duck.GetComponent<DuckController>().duck_sprite = duck_sprites[contador_patos].GetComponent<SpriteRenderer>();
                contador_patos++;
            }
            yield return new WaitForSeconds(0.1f);
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


}
