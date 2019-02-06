using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionDog : MonoBehaviour {

    private Animator animator;
	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine(ladrido());
	}
	
	
    IEnumerator ladrido()
    {
        animator.SetBool("isOler", true);
        yield return new WaitForSeconds(4);
        animator.SetBool("isOler", false);

    }
}
