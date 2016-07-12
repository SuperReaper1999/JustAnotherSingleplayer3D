using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public bool isPlayer = false;
    public bool isDamageable = true;
    public bool hasArmor = false;
    [SerializeField]
    private int healthValue = 100;
    [SerializeField]
    private int armorValue = 0;

    public GameObject destructionEffectPrefab;

    // Use this for initialization.
    void Start()
    {
        if (hasArmor)
        {
            armorValue = 70;
        }
        else {
            armorValue = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (armorValue >= 1) {
            hasArmor = true;
        } else {
            hasArmor = false;
        }

        if (!isPlayer && healthValue <= 0)
        {
            Instantiate(destructionEffectPrefab, transform.position + new Vector3(0,1,0), Quaternion.AngleAxis(90, Vector3.left));
            Destroy(this.gameObject);
        }
    }

    // Getter for health value.
    public int GetHealth() {
        return healthValue;
    }

    // Handles doing damage.
    public void DoDamage(float damageToDo) {
        if (isDamageable)
        {
            if (hasArmor)
            {
                float damage = damageToDo;
                if (armorValue >= 70)
                {
                    damage = damageToDo / 3.5f;
                    Debug.Log("armorValue >= 70");
                }
                else if (armorValue >= 50)
                {
                    damage = damageToDo / 3f;
                    Debug.Log("armorValue >= 50");
                }
                else if (armorValue >= 30)
                {
                    damage = damageToDo / 2f;
                    Debug.Log("armorValue >= 30");
                }
                else if (armorValue >= 5)
                {
                    damage = damageToDo / 1.5f;
                    Debug.Log("armorValue >= 5");
                }
                else
                {
                    damage = damageToDo / 1.25f;
                    Debug.Log("armorValue < 5");
                }
                armorValue -= (int)damageToDo / 2;
                healthValue -= (int)damage;
            }
            else
            {
                healthValue -= (int)damageToDo;
            }
        }       
    }
}
