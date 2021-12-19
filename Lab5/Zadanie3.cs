using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    private bool isRunning = false;
    private Transform oldParent;
    private int currentWayPoint = 0;
    private int nextWayPoint = 1;
    //private int currentWayPoint = 1;
    private float platformSpeed = 2f;
    //private Vector3 wayPoint1;
    private Vector3 startPosition;
    //private Vector3 wayPoint2;
    //private Vector3 wayPoint3;
    //private Vector3 wayPoint4;
    public Vector3[] vectors;

    // Start is called before the first frame update
    void Start()
    {
        //wayPoint1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //wayPoint2 = new Vector3(transform.position.x+10f, transform.position.y, transform.position.z);
        //wayPoint3 = new Vector3(transform.position.x+10f, transform.position.y+5f, transform.position.z);
        //wayPoint4 = new Vector3(transform.position.x, transform.position.y+5f, transform.position.z+5f);
        vectors[0] = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (transform.position == vectors[vectors.Length-1])
            {
                nextWayPoint = 0;
                currentWayPoint = vectors.Length-1;
                float step = platformSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, vectors[nextWayPoint], step);
            }
            if (transform.position == vectors[nextWayPoint])
            {
                currentWayPoint++;
                nextWayPoint++;
            }
            else
            {
                float step = platformSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, vectors[nextWayPoint], step);
            }


            //if (currentWayPoint == 1)
            //{
            //    float step = platformSpeed * Time.deltaTime; // calculate distance to move
            //    transform.position = Vector3.MoveTowards(transform.position, wayPoint2, step);
            //    if (transform.position == wayPoint2)
            //    {
            //        currentWayPoint = 2;
            //    }
            //}
            //if (currentWayPoint == 2)
            //{
            //    float step = platformSpeed * Time.deltaTime; // calculate distance to move
            //    transform.position = Vector3.MoveTowards(transform.position, wayPoint3, step);
            //    if (transform.position == wayPoint3)
            //    {
            //        currentWayPoint = 3;
            //    }
            //}
            //if (currentWayPoint == 3)
            //{
            //    float step = platformSpeed * Time.deltaTime; // calculate distance to move
            //    transform.position = Vector3.MoveTowards(transform.position, wayPoint4, step);
            //    if (transform.position == wayPoint4)
            //    {
            //        currentWayPoint = 4;
            //    }
            //}
            //if (currentWayPoint == 4)
            //{
            //    float step = platformSpeed * Time.deltaTime; // calculate distance to move
            //    transform.position = Vector3.MoveTowards(transform.position, wayPoint1, step);
            //    if (transform.position == wayPoint1)
            //    {
            //        currentWayPoint = 1;
            //    }
            //}
        }
        else
        {
            nextWayPoint = 0;
            currentWayPoint = vectors.Length - 1;
            float step = platformSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, vectors[nextWayPoint], step);
        }
        //else
        //{
        //    float step = platformSpeed * Time.deltaTime; // calculate distance to move
        //    transform.position = Vector3.MoveTowards(transform.position, wayPoint1, step);
        //    if (transform.position == wayPoint1)
        //    {
        //        currentWayPoint = 1;
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // zapamiętujemy "starego rodzica"
            oldParent = other.gameObject.transform.parent;
            // skrypt przypisany do windy, ale other może być innym obiektem
            other.gameObject.transform.parent = transform;

            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent = oldParent;
            isRunning = false;
        }
    }


}
