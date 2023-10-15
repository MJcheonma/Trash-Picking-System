using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositLocTrigger : MonoBehaviour
{
    public GameObject depositUI; // Reference to the DepositUI GameObject.

    private void Start()
    {
        depositUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Triggered");

        if (collision.gameObject.CompareTag("DepositLoc"))
        {
            //Debug.Log("Found it!");
            depositUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}