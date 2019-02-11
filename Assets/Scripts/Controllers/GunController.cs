using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GunController : MonoBehaviour {

    public int shots = 3;
    private AudioSource sound;
    public List<GameObject> shots_sprites; //sprites de las balas disponibles

    private SteamVR_Behaviour_Pose trackedObj;
    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    public GameObject model_gun;
    public GameObject particula;


    private void Awake()
    {
        sound = GetComponent<AudioSource>();
            trackedObj = GetComponent<SteamVR_Behaviour_Pose>();

    }

    private void Update()
    {            // Bit shift the index of the layer (8) to get a bit mask

        Vector3 fwd = model_gun.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(model_gun.transform.position, fwd*100f, Color.red);

        if (spawn.GetStateDown(trackedObj.inputSource) && shots>0)
        {
            shoot();
            int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        

        RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer

            
            if (Physics.Raycast(model_gun.transform.position,fwd, out hit, Mathf.Infinity, layerMask))
        {

                //GameObject temp= Instantiate(particula);
                //Debug.Log(hit.transform.tag);
                //temp.transform.position = hit.transform.position;
                //Destroy(temp, 3);
                if (hit.transform.tag == ("pato"))
                {
                    hit.transform.SendMessageUpwards("morir");

                }
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
