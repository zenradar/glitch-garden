using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;

    private GameObject currentTarget;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(transform.position.x > 12)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<Attacker>())
        {
            currentTarget = obj;
            StrikeCurrentTarget(damage);
            Invoke("DestroySelf", 0.1f);
        }
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget != null)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void DestoryTarget()
    {
        Destroy(currentTarget);
    }
}
