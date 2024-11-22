using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    [SerializeField]
    float mvSpeed = 3;
    Rigidbody rb;
    void Move()
    {
        rb = GetComponent<Rigidbody>();

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xInput, 0, zInput) * mvSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
            rb.AddForce(new Vector3(0, 50, 0) * mvSpeed);
    }

    [SerializeField] GameObject bulletPrefab;
    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(
                bulletPrefab,
                // transform.GetChild(2).transform.position,
                transform.GetChild(2).transform.GetChild(2).transform.position,// + new Vector3(-.2f, .2f, .5f),
                // transform.position + new Vector3(0.55f, 1.2f, 0.4f),
                transform.GetChild(2).transform.rotation * Quaternion.Euler(90, 0, 0)
                // transform.rotation * Quaternion.Euler(90, 0, 0)
                // Quaternion.Euler(90, 0, 0)
            );
    }
}
