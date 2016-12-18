using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Animator animator;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<Gravestone>())
        {
            animator.SetTrigger("jump trigger");
            return;
        }

        if (obj.GetComponent<Defender>())
        {
            Invoke("StartAttack", 1.25f);
            attacker.Attack(obj);
            return;
        }

        if (obj.GetComponent<Projectile>())
        {
            Debug.Log("projectile impact");
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //StopAttack();
    }

    private void StartAttack()
    {
        animator.SetBool("isAttacking", true);
    }

    private void StopAttack()
    {
        animator.SetBool("isAttacking", false);
    }


}
