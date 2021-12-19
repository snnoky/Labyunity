using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float doorSpeed = 2f;

    private GameObject doorTransform;
    private bool open = false;
    private float closeDoorPosition;

    // Start is called before the first frame update
    void Start()
    {
        doorTransform = GameObject.Find("Door");
        closeDoorPosition = doorTransform.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            if (doorTransform.transform.position.z >= 0f)
            {
                Vector3 move = -transform.up * doorSpeed * Time.deltaTime;
                doorTransform.transform.Translate(move);
            }
        }
        else
        {
            if (doorTransform.transform.position.z < closeDoorPosition)
            {
                Vector3 move = transform.up * doorSpeed * Time.deltaTime;
                doorTransform.transform.Translate(move);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = true;
            Debug.Log("open doors!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = false;
            Debug.Log("CLose doors!");

        }
    }

}
