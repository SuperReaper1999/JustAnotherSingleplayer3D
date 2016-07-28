using UnityEngine;
using System.Collections;

public class BlinkScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Blink"))
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit))
            {
                transform.position = Vector3.Slerp(transform.position, rayHit.point, 1);
            }
        }
	}
}
