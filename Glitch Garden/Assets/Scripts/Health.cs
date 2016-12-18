using UnityEngine;

public class Health : MonoBehaviour {

    public float health;

    public void DealDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            // placeholder: trigger animation die state. The animator would 
            // then call DestroyObject(). For now, just destroy here.
            DestroyObject();

        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
