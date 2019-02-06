using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int level=1;
    public int score = 0;

    public List<GameObject> duck_sprites;
    public GameObject duck_prefab;
    private int contador_patos;

    private void Start()
    {
        StartCoroutine(parpadearSprite(0));
       

        //duck.GetComponent<DuckController>().morir();
        StartCoroutine(parpadearSprite(1));
    }

    public void soltarPato()
    {
        if (contador_patos < 10)
        {
            contador_patos++;
        }
    }

    IEnumerator parpadearSprite(int pato)
    {
        bool bandera = true;
        while (contador_patos<10)
        {
            duck_sprites[pato].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            duck_sprites[pato].SetActive(false);
            yield return new WaitForSeconds(0.3f);


        }
    }

    public void crearPatos(int indice)
    {
        GameObject duck = Instantiate(duck_prefab);
        duck.GetComponent<DuckController>().duck_sprite = duck_sprites[0].GetComponent<SpriteRenderer>();
    }


}
