//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Tooltip ("Average number of seconds between appearences")]
    public float seenEverySeconds;

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;

    }

    // called from the animator at time of attack
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget == null)
        {
            // target is already destroyed by another attacker
            animator.SetBool("isAttacking", false);
        }
        else
        {
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                health.DealDamage(damage);
            }
        }
    }

    private void DestoryTarget()
    {
        Destroy(currentTarget);
    }
}
