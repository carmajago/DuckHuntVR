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
    {            // Bit shift the index of the layer (8) to get a bit mask
        if (Input.GetMouseButtonDown(0) && shots>0)
        {
            shoot();
            int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, (Input.mousePosition), Color.green);
            Debug.Log("Did Hit");
            hit.transform.SendMessageUpwards("morir");
        }
        else
        {
            Debug.DrawRay(transform.position, (Input.mousePosition), Color.green);
            Debug.Log("Did not Hit");
        }
      
            

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

    public void recargar()
    {
        shots_sprites[0].SetActive(true);
        shots_sprites[1].SetActive(true);
        shots_sprites[2].SetActive(true);
        shots = 3;

    }

}
