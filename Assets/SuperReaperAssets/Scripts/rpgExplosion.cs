using UnityEngine;
using System.Collections;

public class rpgExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;

    // Upon colliding with objects creates explosion.
    public void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
