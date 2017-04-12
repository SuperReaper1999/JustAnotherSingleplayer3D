using UnityEngine;
using System.Collections;

public class Telepad : MonoBehaviour
{

    public GameObject teleporterDestination;
    public GameObject thisTeleporterDestination;

    // Use this for initialization
    void Start()
    {

    }

    public void OnTriggerEnter(Collider col)
    {
        if (teleporterDestination.tag == "TeleporterPad")
        {
            col.gameObject.transform.position = teleporterDestination.GetComponent<Telepad>().thisTeleporterDestination.transform.position;
        }
        else
        {
            col.gameObject.transform.position = teleporterDestination.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
