using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour {


    public SpriteRenderer duck_sprite;

	void Start () {
		
	}
	
	public void morir()
    {
        duck_sprite.color = Color.red;
    }

    public void moverse()
    {

    }
}
