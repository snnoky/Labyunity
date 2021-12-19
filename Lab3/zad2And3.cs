using UnityEngine;

public class zad2And3 : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject otherObject;

    private Rigidbody rb;
    private bool rotate = false;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        otherObject.transform.position = transform.TransformPoint(0.5f, 1f, 0.21f);
        if (rb.position.x > 10 && rb.position.z == 0)
        {
            rb.transform.position = new Vector3(10f, 0f, 0f);
        }
        if (rb.position.x == 10 && rb.position.z > 10)
        {
            rb.transform.position = new Vector3(10f, 0f, 10f);
        }
        if (rb.position.x < 0 && rb.position.z == 10)
        {
            rb.transform.position = new Vector3(0f, 0f, 10f);
        }
        if (rb.position.x == 0 && rb.position.z < 0)
        {
            rb.transform.position = new Vector3(0f, 0f, 0f);
            rotate = true;
        }

        if (rb.position.x == 10 && rb.position.z == 0)
        {
            rb.transform.Rotate(0, -90, 0);
        }
        if (rb.position.x == 10 && rb.position.z == 10)
        {
            rb.transform.Rotate(0, -90, 0);
        }
        if (rb.position.x == 0 && rb.position.z == 10)
        {
            rb.transform.Rotate(0, -90, 0);
        }
        if (rb.position.x == 0 && rb.position.z == 0 && rotate == true)
        {
            rb.transform.Rotate(0, -90, 0);
        }

        if (rb.position.x < 10 && rb.position.z == 0)
        {
            Vector3 velocity = new Vector3(10, 0, 0);
            velocity = velocity.normalized * speed * Time.deltaTime;

            rb.MovePosition(transform.position + velocity);

        }
        if (rb.position.x == 10 && rb.position.z < 10)
        {
            Vector3 velocity = new Vector3(0, 0, 10);
            velocity = velocity.normalized * speed * Time.deltaTime;

            rb.MovePosition(transform.position + velocity);

        }
        if (rb.position.x > 0 && rb.position.z == 10)
        {
            Vector3 velocity = new Vector3(-10, 0, 0);
            velocity = velocity.normalized * speed * Time.deltaTime;

            rb.MovePosition(transform.position + velocity);

        }
        if (rb.position.x == 0 && rb.position.z > 0)
        {
            Vector3 velocity = new Vector3(0, 0, -10);
            velocity = velocity.normalized * speed * Time.deltaTime;

            rb.MovePosition(transform.position + velocity);
        }   
    }
}
