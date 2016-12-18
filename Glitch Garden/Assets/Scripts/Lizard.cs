using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {

    private Animator animator;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<Defender>())
        {
            Invoke("StartAttack", 0.85f);
            attacker.Attack(obj);
            return;
        }

        if (obj.GetComponent<Projectile>())
        {
            Debug.Log("projectile impact");
            return;
        }
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
