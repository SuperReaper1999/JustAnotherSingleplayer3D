using UnityEngine;
using System.Collections;

public class PickupHandler : MonoBehaviour {

    // TODO : add sound effects for pickups.

    [SerializeField, Tooltip("what type of pickup is this? true = Health, false = Armour")]
    private bool isHealthOrArmour = true;
    [SerializeField, Tooltip("Is this pickup allowed to overload its max value?")]
    private bool isOverload = false;

    [SerializeField, Tooltip("How much armour/health should this give?")]
    private int pickupValue = 0;

    // Update is called once per frame
    void Update() {
        if (isOverload)
        {
            GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);
        }
        else if (!isOverload && isHealthOrArmour)
        {
            GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 255);
        }
        else if (!isOverload && !isHealthOrArmour)
        {
            GetComponent<Renderer>().material.color = new Color32(0, 0, 255, 255);
        }
    }

    // Called when an object enters this objects trigger.
    public void OnTriggerEnter(Collider col) {
        Debug.Log(col.gameObject);
        if (col.tag == "Player")
        {
            Health playerHealth = col.gameObject.GetComponent<Health>();
            if (isHealthOrArmour)
            {
                if (isOverload == false && playerHealth.GetCurrentHealth() >= playerHealth.GetMaxHealth())
                {
                    // Play sound effect and display Health full message here.
                }
                else
                {
                    playerHealth.AddHealth(pickupValue, isOverload);
                    Destroy(transform.parent.gameObject);
                }
                
            }
            else
            {
                if (isOverload == false && playerHealth.GetCurrentArmour() >= playerHealth.GetMaxArmour())
                {
                    // Play sound effect and display Armour full message here.
                }
                else
                {
                    playerHealth.AddArmour(pickupValue, isOverload);
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}