using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{

    private Animator animator;
    private bool lizardAttack;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<Lizard>())
        {
            lizardAttack = true;
        }
        if(!obj.GetComponent<Projectile>())
        {
            StartAttack();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Fox>() && !lizardAttack)
        {
            StopAttack();
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