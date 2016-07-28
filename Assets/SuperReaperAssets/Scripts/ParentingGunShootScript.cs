using UnityEngine;
using System.Collections;

public class ParentingGunShootScript : MonoBehaviour {

    [SerializeField]
    private GameObject firstObject;

    [SerializeField]
    private GameObject secondObject;

    // Use this for initialization
    void Start () {

    }
	
    // TODO : make this script give the object its rigidbody back using another script that gets created on the object to store its RigidBodies values.
    // TODO : add visual indicator of what object is selected and a way to clear the selected objects.

	// Update is called once per frame
	void Update () {
        // Handles Parenting objects to each other when pressing fire.
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit))
            {
                if (rayHit.rigidbody != null && firstObject == null)
                {
                    firstObject = rayHit.transform.gameObject;
                }
                else if (rayHit.rigidbody != null && secondObject == null)
                {
                    secondObject = rayHit.transform.gameObject;
                }

                if (firstObject != null && secondObject != null)
                {
                    Destroy(firstObject.GetComponent<Rigidbody>());
                    firstObject.transform.parent = secondObject.transform;
                    firstObject = null;
                    secondObject = null;
                }
            }
        }
        else if (Input.GetButton("Fire2") && Time.timeScale != 0)
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit))
            {
                rayHit.transform.parent = null; // Become Batman.
            }
        }
    }
}
