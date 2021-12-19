using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie1 : MonoBehaviour
{

    public float platformSpeed = 2f;
    private bool isRunningToEndPosition = false;
    private bool isRunningToStartPosition = false;
    private bool playerOnPlatform = false;
    private float fromPosition;
    private float toPosition;
    private Transform oldParent;

    // Start is called before the first frame update
    private void Start()
    {
        fromPosition = 0f;
        toPosition = 10f;
    }

    private void Update()
    {
        if (playerOnPlatform)
        {
            if (transform.position.z >= toPosition)
            {
                isRunningToEndPosition = false;
                isRunningToStartPosition = true;
            }
            if (transform.position.z <= fromPosition)
            {
                isRunningToEndPosition = true;
                isRunningToStartPosition = false;
            }
            if (isRunningToEndPosition)
            {
                Vector3 move = transform.forward * platformSpeed * Time.deltaTime;
                transform.Translate(move);
            }
            if (isRunningToStartPosition)
            {
                Vector3 move = -transform.forward * platformSpeed * Time.deltaTime;
                transform.Translate(move);
            }
        }
        else
        {
            if (transform.position.z >= fromPosition)
            {
                Vector3 move = -transform.forward * platformSpeed * Time.deltaTime;
                transform.Translate(move);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            // zapamiętujemy "starego rodzica"
            oldParent = other.gameObject.transform.parent;
            // skrypt przypisany do windy, ale other może być innym obiektem
            other.gameObject.transform.parent = transform;

            if (transform.position.z <= fromPosition)
            {
                isRunningToEndPosition = true;
                isRunningToStartPosition = false;
            }

            if (transform.position.z >= toPosition)
            {
                isRunningToEndPosition = false;
                isRunningToStartPosition = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
