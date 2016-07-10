using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GunSwithHandler : MonoBehaviour {

    public List<GameObject> guns = new List<GameObject>();

	// Use this for initialization
	void Start () {
        // Sets all but the first gun in the list to be deactivated.
        for (int i = 1; i < guns.Count; i++)
        {
            guns[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("1"))
        {
            Debug.Log("primary equipped");
            guns[0].SetActive(true);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
        }
        else if(Input.GetKeyUp("2"))
        {
            Debug.Log("secondary equipped");
            guns[0].SetActive(false);
            guns[1].SetActive(true);
            guns[2].SetActive(false);
        }
        else if (Input.GetKeyUp("3"))
        {
            Debug.Log("RPG equipped");
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
        }
    }
}
