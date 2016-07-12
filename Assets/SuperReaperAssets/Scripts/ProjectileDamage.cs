using UnityEngine;
using System.Collections;

public class ProjectileDamage : MonoBehaviour {

    [SerializeField]
    private int projectilesDamage;

    private float lifeTime;

    // Update is called once per frame
    void Update() {
        lifeTime += Time.deltaTime;
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Health>() != null)
        {
            float damageToDo = projectilesDamage - lifeTime * 4;
            Debug.Log(damageToDo);
            collision.collider.GetComponent<Health>().DoDamage(projectilesDamage - lifeTime*4);
        }
        Destroy(this);
    }
}
