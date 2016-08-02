using UnityEngine;
using System.Collections.Generic;

public class GunSwitchHandler : MonoBehaviour {

    private List<GameObject> guns = new List<GameObject>();

    private int currentActiveGunIndex = 0;

    // Use this for initialization
    void Start () {
        foreach (Transform child in transform)
        {
            guns.Add(child.gameObject);
        }

        // Sets all but the first gun in the list to be deactivated.
        SwitchWeapon(0);
    }

    // Handles switching weapons with scroll.
    void HandleScroll(float scrollAmount) {

        if (scrollAmount > 0)
        {
            currentActiveGunIndex++;
            if (currentActiveGunIndex >= guns.Count)
            {
                currentActiveGunIndex = 0;
            }
            SwitchWeapon(currentActiveGunIndex);
        }
        else if(scrollAmount < 0)
        {
            currentActiveGunIndex--;
            Debug.Log(currentActiveGunIndex);
            if (currentActiveGunIndex < 0)
            {
                currentActiveGunIndex = guns.Count - 1;
            }
            SwitchWeapon(currentActiveGunIndex);
        }
    }

    // Disables all weapons that are not the weapon that was passed to it.
    private void SwitchWeapon(int weaponToSwitchTo) {
        for (int i = 0; i < guns.Count; i++)
        {
            guns[i].SetActive(false);
        }
        guns[weaponToSwitchTo].SetActive(true);
    }

	// Update is called once per frame
	void Update () {

        HandleScroll(Input.GetAxis("Mouse ScrollWheel"));

        for (int i = 0; i <= guns.Count; i++)
        {
            if (Input.GetKeyUp(i.ToString()))
            {
                SwitchWeapon(i-1);
            }
        }
    }
}
