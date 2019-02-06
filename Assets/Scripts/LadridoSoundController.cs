using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadridoSoundController : MonoBehaviour {

    private AudioSource ladridosonido;
    public float tiempoInicio;


    private void Start()
    {
        ladridosonido= GetComponent<AudioSource>();
        StartCoroutine(startLadrar());
    }
    IEnumerator startLadrar()
    {
        yield return new WaitForSeconds(tiempoInicio);

        StartCoroutine(playLadrar());
       
    }
    IEnumerator playLadrar()
    {
        for (int i = 0; i < 3; i++)
        {

            ladridosonido.Play();
            yield return new WaitForSeconds(0.3f);
        }
    }

}
