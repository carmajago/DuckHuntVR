using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public int shots = 3;
    private AudioSource sound;
    public List<GameObject> shots_sprites; //sprites de las balas disponibles

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    public void shoot()
    {
        if (shots > 0)
        {
            shots--;
            shots_sprites[shots].SetActive(false);
            sound.Play();
        }
    }

}
