using UnityEngine;
using System.Collections;

public class PickupHandler : MonoBehaviour {

    // TODO : Add sound effects for pickups.

    private enum PickupType {Armour, Health, Ammo};
    private enum AmmoPickupType { Rifle, Pistol, Launcher };

    [SerializeField, Tooltip("What type of pickup is this?")]
    private PickupType pickupType;

    [SerializeField, Tooltip("If this is ammo what type of ammo is it?")]
    private AmmoPickupType ammoPickupType;

    [SerializeField, Tooltip("Is this pickup allowed to overload its max value?")]
    private bool isOverload = false;

    [SerializeField, Tooltip("How much of the selected pickup type should this give?")]
    private int pickupAmount = 0;

    // Start is called on initialization.
    void Start() {
        if (isOverload)
        {
            GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            switch (pickupType)
            {
                case PickupType.Health:
                    GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 255);
                    break;

                case PickupType.Armour:
                    GetComponent<Renderer>().material.color = new Color32(0, 0, 255, 255);
                    break;

                default:
                    Debug.Log("unhandled case " + pickupType);
                    break;
            }
        }
    }

    private void HandlePickupHealth(Collider col) {
        Health playerHealth = col.gameObject.GetComponent<Health>();
        if (isOverload == false && playerHealth.GetCurrentHealth() >= playerHealth.GetMaxHealth())
        {
            // Play sound effect and display Health full message here.
        }
        else
        {
            playerHealth.AddHealth(pickupAmount, isOverload);
            Destroy(transform.parent.gameObject);
        }
    }

    private void HandlePickupArmour(Collider col) {
        Health playerHealth = col.gameObject.GetComponent<Health>();
        if (isOverload == false && playerHealth.GetCurrentArmour() >= playerHealth.GetMaxArmour())
        {
            // Play sound effect and display Armour full message here.
        }
        else
        {
            playerHealth.AddArmour(pickupAmount, isOverload);
            Destroy(transform.parent.gameObject);
        }
    }

    private void HandlePickupAmmo(Collider col) {

        GunAmmoHandler ammoHandler = col.GetComponentInChildren<GunAmmoHandler>();
        switch (ammoPickupType)
        {
            case AmmoPickupType.Rifle:
                ammoHandler.SetRifleAmmo(pickupAmount);
                break;

            case AmmoPickupType.Pistol:
                ammoHandler.SetPistolAmmo(pickupAmount);
                break;

            case AmmoPickupType.Launcher:
                ammoHandler.SetLauncherAmmo(pickupAmount);
                break;
            default:
                Debug.Log("unhandled case " + ammoPickupType);
                break;
        }
        Destroy(transform.parent.gameObject);
    }

    // Called when an object enters this objects trigger.
    public void OnTriggerEnter(Collider col) {

        if (col.tag != "Player")
        {
            return;
        }

        switch(pickupType)
        {
            case PickupType.Health:
                HandlePickupHealth(col);
                break;

            case PickupType.Armour:
                HandlePickupArmour(col);
                break;

            case PickupType.Ammo:
                HandlePickupAmmo(col);
                break;

            default:
                Debug.Log("unhandled case " + pickupType);
                break;
        }
    }
}