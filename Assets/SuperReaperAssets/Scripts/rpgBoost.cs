using UnityEngine;
using System.Collections;

public class rpgBoost : MonoBehaviour {

    private float rpgBoostTimer = 0.5f;

	// Update is called once per frame
	void Update () {
        rpgBoostTimer -= Time.deltaTime;
        if (rpgBoostTimer <= 0)
        {
            // boosts the RPG forward after a set ammount of time.
            Debug.Log("RPG boosted");
            GetComponent<Rigidbody>().velocity = transform.forward * 350;
            Destroy(this);
        }
	}
}
