using UnityEngine;
using System.Collections;

public class NewShootingScript : MonoBehaviour {

    private enum GunClass { Rifle, Pistol, Launcher }

    [SerializeField, Tooltip("What class of gun is this in?")]
    private GunClass gunClass;

    [SerializeField, Tooltip("How much damage does this gun do to Health?")]
    private int healthDamage;
    [SerializeField, Tooltip("How much damage does this gun do to Armour?")]
    private int armourDamage;
    [SerializeField, Tooltip("should this gun be fully automatic by default?")]
    private bool isFullAuto;
    [SerializeField, Tooltip("how long the user must wait until firing another shot.")]
    private float cooldownTime;
    [SerializeField, Tooltip("How far should the guns bullets reach?")]
    private int maxRange;

    private GunAmmoHandler ammoHandler;

    public LayerMask layersToHit;

    private float cooldownTimer;

    // TODO : Make this the primary shooting script to replace the old one.

    // Use this for initialization
    void Start () {
        ammoHandler = transform.parent.GetComponent<GunAmmoHandler>();
    }

    private int CheckAmmo()
    {
        switch (gunClass)
        {
            case GunClass.Rifle:
                return ammoHandler.GetRifleAmmo();
            case GunClass.Pistol:
                return ammoHandler.GetPistolAmmo();
            case GunClass.Launcher:
                return ammoHandler.GetLauncherAmmo();
            default:
                Debug.Log("unhandled case " + gunClass);
                return 0;
        }
    }

    private void RemoveAmmo(int ammountToRemove)
    {
        switch (gunClass)
        {
            case GunClass.Rifle:
                ammoHandler.SetRifleAmmo(-ammountToRemove);
                break;
            case GunClass.Pistol:
                ammoHandler.SetPistolAmmo(-ammountToRemove);
                break;
            case GunClass.Launcher:
                ammoHandler.SetLauncherAmmo(-ammountToRemove);
                break;
            default:
                Debug.Log("unhandled case " + gunClass);
                break;
        }
    }

    // Update is called once per frame
    void Update () {
        cooldownTimer -= Time.deltaTime;
        // Performs a RayCast while the shoot button is held.
        if (Input.GetButton("Fire1") && cooldownTimer <= 0 && isFullAuto && Time.timeScale != 0)
        {
            if (CheckAmmo() == 0) { if (!transform.parent.GetComponent<AudioSource>().isPlaying) { transform.parent.GetComponent<AudioSource>().Play(); } return; }
            RemoveAmmo(1);
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit, maxRange, layersToHit))
            {
                if (rayHit.transform.gameObject.GetComponent<Health>())
                {
                    rayHit.transform.gameObject.GetComponent<Health>().DoDamage(healthDamage, armourDamage);
                }
            }
            cooldownTimer = cooldownTime;
        }

        // Performs a RayCast when the shoot button is pressed.
        if (Input.GetButtonDown("Fire1") && !isFullAuto && cooldownTimer <= 0 && Time.timeScale != 0)
        {
            if (CheckAmmo() == 0) { transform.parent.GetComponent<AudioSource>().Play(); return; }
            RemoveAmmo(1);
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit, maxRange, layersToHit))
            {
                if (rayHit.transform.gameObject.GetComponent<Health>())
                {
                    rayHit.transform.gameObject.GetComponent<Health>().DoDamage(healthDamage, armourDamage);
                }
            }
            cooldownTimer = cooldownTime;
        }
    }
}
