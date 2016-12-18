using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Projectile>())
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        animator.SetBool("isUnderAttack", true);
    }

    private void StopAttack()
    {
        animator.SetBool("isUnderAttack", false);
    }
}
