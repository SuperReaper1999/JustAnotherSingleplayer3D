using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 100;
        }
	}
}
