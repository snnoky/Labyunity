using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie4 : MonoBehaviour
{
    public float speedV = 2.0f;
    public float speedH = 2.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotationY += speedV * Input.GetAxis("Mouse X");
        rotationX += -speedH * Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
