using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using System.Collections;
using System.Numerics;

public class GameManager : MonoBehaviour
{
    public Transform targetPos;

    private TextMeshProUGUI pickedText;
    private int pickedCount = 0;

    private TextMeshProUGUI depositedText;
    private int depositedCount = 0;

    public List<GameObject> pickedTrash = new List<GameObject>();

    public GameObject DepositUI;
    public Transform depositTarget;

    public GameObject statsUI;
    public GameObject successUI;
    public GameObject depositMenu;

    public float delayTime = 1.5f;
    private int garbage = 3000;
    
    


    private void Awake()
    {
        depositedCount = 0;
       

        pickedText = GameObject.Find("PickedTxt").GetComponent<TextMeshProUGUI>();
        depositedText = GameObject.Find("DepositedTxt").GetComponent<TextMeshProUGUI>();

        //DepositUI.SetActive(false);
        successUI.SetActive(false);
    }

    void Update()
    {
        TrashPicking();
        TrashDepositing();


    }

    void TrashPicking()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Trash"))
                {
                    Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.useGravity = false; // Disable the Gravity.
                    }

                    // Move the object to the specified target position.
                    hit.transform.position = targetPos.position;

                    if (rb != null)
                    {
                        rb.useGravity = true; // Re-enable the Gravity.


                        pickedTrash.Add(hit.transform.gameObject);

                        pickedCount++;
                        pickedText.text = "Picked: " + pickedCount;



                    }


                    garbage = pickedCount;


                }
            }
        }
    }

    public void TrashDepositing()
    {
        
        

        if (DepositUI.activeSelf)
        {

            StartCoroutine(depositDelay());

            


        }

        

        if (depositedCount == garbage)
        {
            
            DepositUI.SetActive(false);
            depositMenu.SetActive(false);
            statsUI.SetActive(false);
            successUI.SetActive(true);
            
            //Debug.Log("abc");
        }
    }

    IEnumerator depositDelay()
    {
        

        for (int i = 0; i < garbage; i++)
        {
            
            //isDepositing = true;

            GameObject go = pickedTrash[i];

            go.transform.position = depositTarget.position;

            depositedCount++;
            depositedText.text = "Deposited: " + depositedCount;
            //Debug.Log(depositedCount);
            //Debug.Log(garbage);
            

            yield return new WaitForSeconds(delayTime);

        }

        



    }

}