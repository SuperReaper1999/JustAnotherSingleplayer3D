using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public bool isPlayer = false;
    public bool isDamageable = true;
    public bool hasArmour = false;
    [SerializeField]
    private int healthValue = 100;
    [SerializeField]
    private int armourValue = 0;

    public GameObject destructionEffectPrefab;

    // Use this for initialization.
    void Start()
    {
        if (hasArmour)
        {
            armourValue = 70;
        }
        else {
            armourValue = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (armourValue >= 1) {
            hasArmour = true;
        } else {
            hasArmour = false;
        }

        if (!isPlayer && healthValue <= 0)
        {
            Instantiate(destructionEffectPrefab, transform.position + new Vector3(0,1,0), Quaternion.AngleAxis(90, Vector3.left));
            Destroy(this.gameObject);
        }
    }

    // Allows adding for Armour.
    public void AddArmour(int a) {
        armourValue += a;
    }

    // Allows adding for Health.
    public void AddHealth(int h) {
        healthValue += h;
    }

    // Getter for Armour value.
    public int GetArmour() {
        return armourValue;
    }

    // Getter for Health value.
    public int GetHealth() {
        return healthValue;
    }

    // Handles doing damage.
    public void DoDamage(float damageToDo) {
        if (isDamageable)
        {
            if (hasArmour)
            {
                float damage = damageToDo;
                if (armourValue >= 70)
                {
                    damage = damageToDo / 3.5f;
                    Debug.Log("armorValue >= 70");
                }
                else if (armourValue >= 50)
                {
                    damage = damageToDo / 3f;
                    Debug.Log("armorValue >= 50");
                }
                else if (armourValue >= 30)
                {
                    damage = damageToDo / 2f;
                    Debug.Log("armorValue >= 30");
                }
                else if (armourValue >= 5)
                {
                    damage = damageToDo / 1.5f;
                    Debug.Log("armorValue >= 5");
                }
                else
                {
                    damage = damageToDo / 1.25f;
                    Debug.Log("armorValue < 5");
                }
                armourValue -= (int)damageToDo / 2;
                healthValue -= (int)damage;
            }
            else
            {
                healthValue -= (int)damageToDo;
            }
        }       
    }
}
