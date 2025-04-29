using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanturnPickUp : MonoBehaviour
{
    private GameObject OB;
    public GameObject handUI;
    public GameObject lanturn;
    public GameObject LanturnArms; // Reference to the LanturnArms GameObject
    public float lampDuration; // Duration for which the lamp will stay on

    private bool inReach;

    void Start()
    {
        OB = this.gameObject;
        handUI.SetActive(false);
        lanturn.SetActive(false);
        LanturnArms.SetActive(false); // Ensure LanturnArms is inactive at the start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            handUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            handUI.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            handUI.SetActive(false);
            lanturn.SetActive(true);
            LanturnArms.SetActive(true); // Activate the LanturnArms GameObject
            StartCoroutine(TurnOffLampAfterDuration());
        }
    }

    IEnumerator TurnOffLampAfterDuration()
    {
        Debug.Log("Lamp will turn off after " + lampDuration + " seconds.");
        yield return new WaitForSeconds(lampDuration);
        Debug.Log("Turning off LanturnArms.");
        LanturnArms.SetActive(false); // Deactivate the LanturnArms GameObject
    }
}
