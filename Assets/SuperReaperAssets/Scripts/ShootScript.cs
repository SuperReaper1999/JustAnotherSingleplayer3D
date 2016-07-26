using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

    public string gunName;

    [SerializeField, Tooltip("Prefab of the bullet this gun will fire.")]
    private GameObject bulletPrefab;

    // private GunSwithHandler gunSwitchHand;

    [SerializeField, Tooltip("should this gun be fully automatic by default?")]
    private bool isFullAuto;
    [SerializeField, Tooltip("how long the user must wait until firing another shot.")]
    private float cooldownTime;
    [SerializeField, Tooltip("how fast will the bullet travel in m/s.")]
    private int bulletSpeed = 100;

    private float cooldownTimer;

    // Use this for initialization
    void Start () {
        // gunSwitchHand = transform.parent.GetComponent<GunSwithHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;
        // Instantiates a bullets while the shoot button is held.
        if (Input.GetButton("Fire1") && cooldownTimer <= 0 && isFullAuto && Time.timeScale != 0)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(transform.forward));
            bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
            cooldownTimer = cooldownTime;
        }

        // Instantiates a bullet when the shoot button is pressed.
        if (Input.GetButtonDown("Fire1") && !isFullAuto && cooldownTimer <= 0 && Time.timeScale != 0)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(transform.forward));
            bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
            cooldownTimer = cooldownTime;
        }
	}
}
