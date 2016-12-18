using UnityEngine;

public class Hurler : MonoBehaviour {

    public GameObject projectile, gun;
    public GameObject projectileParent;

    private Animator animator;
    private AttackerSpawner myLaneSpawner;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        SetMyLaneSpawner();

        projectileParent = GameObject.Find("Projectiles");

        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void Update()
    {
        if (isAttackerAheadInLane())
        {
            animator.SetBool("isUnderAttack", true);
        } else
        {
            animator.SetBool("isUnderAttack", false);
        }
    }

    private bool isAttackerAheadInLane()
    {
        if(myLaneSpawner.transform.childCount > 0)
        {
            foreach(Transform child in myLaneSpawner.transform)
            {
                if (child.position.x > transform.position.x)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

    private void SetMyLaneSpawner()
    {
        AttackerSpawner[] spawners = GameObject.FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            if(transform.position.y == spawner.transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError("No attack spawner found in lane " + transform.position.y);
    }
}
