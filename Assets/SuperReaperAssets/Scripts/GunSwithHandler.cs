 using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GunSwithHandler : MonoBehaviour {

    public List<GameObject> guns = new List<GameObject>();

    private int currentActiveGun = 0;

    // TODO : simplify this.

    // Use this for initialization
    void Start () {
        // Sets all but the first gun in the list to be deactivated.
        for (int i = 1; i < guns.Count; i++)
        {
            guns[i].SetActive(false);
        }
    }

    // Handles switching weapons with scroll.
    void WeaponScrollSwitcher(bool plusOrMinus) {

        if (plusOrMinus)
        {
            currentActiveGun++;
            if (currentActiveGun >= guns.Count)
            {
                currentActiveGun = 0;
            }
        }
        else if (!plusOrMinus)
        {
            currentActiveGun--;
            Debug.Log(currentActiveGun);
            if (currentActiveGun <= 0)
            {
                currentActiveGun = guns.Count - 1;
            }
        }
        guns[0].SetActive(false);
        guns[1].SetActive(false);
        guns[2].SetActive(false);
        guns[3].SetActive(false);
        guns[currentActiveGun].SetActive(true);
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            WeaponScrollSwitcher(true);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            WeaponScrollSwitcher(false);
        }

        if (Input.GetKeyUp("1"))
        {
            Debug.Log("primary equipped");
            guns[0].SetActive(true);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(false);
        }
        else if(Input.GetKeyUp("2"))
        {
            Debug.Log("secondary equipped");
            guns[0].SetActive(false);
            guns[1].SetActive(true);
            guns[2].SetActive(false);
            guns[3].SetActive(false);
        }
        else if (Input.GetKeyUp("3"))
        {
            Debug.Log("RPG equipped");
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
            guns[3].SetActive(false);
        }
        else if (Input.GetKeyUp("4"))
        {
            Debug.Log("BatmanGun equipped");
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(true);
        }
    }
}
