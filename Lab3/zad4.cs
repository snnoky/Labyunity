﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad4 : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // pobranie wartości zmiany pozycji w danej osi
        // wartości są z zakresu [-1, 1]
        // kontroler ruchu dla osi jest pobierany z domyślnych ustawień
        // Input Manager (preferences)
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        // tworzymy wektor prędkości
        Vector3 velocity = new Vector3(mH, 0, mV);
        velocity = velocity.normalized * speed * Time.deltaTime;
        // wykonujemy przesunięcie Rigidbody z uwzględnieniem sił fizycznych
        rb.MovePosition(transform.position + velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Debug.Log("Wall touched.");
        }
    }
}
