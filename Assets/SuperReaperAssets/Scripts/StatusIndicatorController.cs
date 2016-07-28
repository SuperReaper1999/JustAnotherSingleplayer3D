using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusIndicatorController : MonoBehaviour {

    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armourText;
    [SerializeField]
    private Health playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
        healthText.text = playerHealth.GetCurrentHealth().ToString();
        armourText.text = playerHealth.GetCurrentArmour().ToString();
    }
}
