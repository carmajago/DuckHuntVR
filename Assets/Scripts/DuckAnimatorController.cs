using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAnimatorController : MonoBehaviour
{

    // Use this for initialization
    private Animator animator;
    public Transform padre;
    public DuckController duckController;
    void Start()
    {
        animator = GetComponent<Animator>();
        duckController = GetComponentInParent<DuckController>();

    }

    // Update is called once per frame
    void Update()
    {
        float z = padre.eulerAngles.z * -1;

        Vector3 angulos = new Vector3(0, 0, z);
        transform.localEulerAngles = angulos;
        float angulo = padre.eulerAngles.z;


        if (!duckController.muerto)
        {

            if ((angulo <= 10 && angulo >= 350) || (angulo <= 10 && angulo >= -10))
            {
                animator.SetBool("LR", false);
                animator.SetBool("LR_UP", false);
                animator.SetBool("UP", true);
                transform.localScale = new Vector3(4, 4, 4);

            }
            else

            if (angulo <= 105 && angulo >= 75)
            {
                animator.SetBool("LR", true);
                animator.SetBool("LR_UP", false);
                animator.SetBool("UP", false);
                transform.localScale = new Vector3(-4, 4, 4);
            }
            else
            if (angulo <= 285 && angulo >= 255)
            {
                animator.SetBool("LR", true);
                animator.SetBool("LR_UP", false);
                animator.SetBool("UP", false);
                transform.localScale = new Vector3(4, 4, 4);
            }
            else if (angulo >= 10 && angulo <= 170)
            {
                animator.SetBool("LR", false);
                animator.SetBool("LR_UP", true);
                animator.SetBool("UP", false);
                transform.localScale = new Vector3(-4, 4, 4);
            }
            else if ((angulo >= 170 && angulo <= 350) || (angulo <= -10 && angulo >= -170))
            {
                animator.SetBool("LR", false);
                animator.SetBool("LR_UP", true);
                animator.SetBool("UP", false);
                transform.localScale = new Vector3(4, 4, 4);
            }

        }
        else
        {
            animator.SetBool("muerto", true);
        }

    }
}
