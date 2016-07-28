using UnityEngine;
using System.Collections;

public class ExplosionDamage : MonoBehaviour {

    // When this script is instantiated applies force to objects and creates explosion effects.
    private IEnumerator Start()
    {
        // wait one frame because some explosions instantiate debris which should then
        // be pushed by physics force
        yield return null;

        float multiplier = GetComponent<UnityStandardAssets.Effects.ParticleSystemMultiplier>().multiplier;

        float r = 10 * multiplier;
        var cols = Physics.OverlapSphere(transform.position, r);
        foreach (var col in cols)
        {
            if (col.GetComponent<Health>())
            {
                col.GetComponent<Health>().DoDamage(200 / (Vector3.Distance(transform.position, col.transform.position) / 2 ));
                Debug.Log(200 / (Vector3.Distance(transform.position, col.transform.position)));
            }
        }
    }
}
