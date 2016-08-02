using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public bool isPlayer = false;
    public bool isDamageable = true;
    public bool hasArmour = false;
    [SerializeField, Tooltip("what is the starting Health value?")]
    private int healthValue = 100;
    [SerializeField, Tooltip("what is the starting Armour value?")]
    private int armourValue = 0;

    [SerializeField, Tooltip("what is the maximum Health value without overload?")]
    private int maxHealthValue = 100;
    [SerializeField, Tooltip("what is the maximum Armour value without overload?")]
    private int maxArmourValue = 100;

    public GameObject destructionEffectPrefab;

    // TODO : Implement respawning for players.

    // Update is called once per frame
    void Update() {
        if (armourValue >= 1) {
            hasArmour = true;
        } else {
            hasArmour = false;
        }

        if (!isPlayer && healthValue <= 0)
        {
            Instantiate(destructionEffectPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.AngleAxis(90, Vector3.left));
            Destroy(this.gameObject);
        }
        else if (isPlayer && healthValue <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Allows adding for Armour and makes sure it doesn't go over the cap unless its overloaded.
    public void AddArmour(int a, bool overload) {
        if (overload)
        {
            armourValue += a;
        }
        else if (armourValue + a <= maxArmourValue)
        {
            armourValue += a;
        }
        else if (armourValue + a > maxArmourValue)
        {
            armourValue = maxArmourValue;
        }
    }

    // Allows adding for Health and makes sure it doesn't go over the cap unless its overloaded.
    public void AddHealth(int h, bool overload) {
        if (overload)
        {
            healthValue += h;
        }
        else if (healthValue + h <= maxHealthValue)
        {
            healthValue += h;
        }
        else if (healthValue + h > maxHealthValue)
        {
            healthValue = maxHealthValue;
        }
    }

    // Getter for CurrentArmour value.
    public int GetCurrentArmour() {
        return armourValue;
    }

    // Getter for CurrentHealth value.
    public int GetCurrentHealth() {
        return healthValue;
    }

    // Getter for MaxArmour value.
    public int GetMaxArmour()
    {
        return maxArmourValue;
    }

    // Getter for MaxHealth value.
    public int GetMaxHealth()
    {
        return maxHealthValue;
    }

    // Handles doing damage.
    public void DoDamage(float heathDamage, int armourDamage) {
        if (isDamageable)
        {
            if (hasArmour)
            {
                armourValue -= armourDamage;
                healthValue -= (int)heathDamage;
            }
            else
            {
                healthValue -= ((int)heathDamage + armourDamage);
            }
        }       
    }
}
