using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_sc : MonoBehaviour
{
    [SerializeField] float mvSpeed = 10;

    void Update()
    {
        transform.Translate(Vector3.up * mvSpeed * Time.deltaTime);
        Destroy(this.gameObject, 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "MapFloor")
            Destroy(this.gameObject);
    }
}
