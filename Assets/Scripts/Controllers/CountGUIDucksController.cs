using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountGUIDucksController : MonoBehaviour
{


    public List<GameObject> indicators;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void refrescarDifucultad(int dificultad)
    {
        for (int i = 0; i < dificultad; i++)
        {
            indicators[i].SetActive(true);
        }
    }


   
}
