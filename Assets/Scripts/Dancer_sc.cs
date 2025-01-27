using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer_sc : MonoBehaviour
{
    Animator anim;

    void Start()
    {
		anim = GetComponent<Animator>();
    }

    void Update()
    {
		Dance();

		Move();
    }

	void Dance()
	{
		if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			anim.SetInteger("Dance", 0);
			transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			anim.SetInteger("Dance", 1);
			transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			anim.SetInteger("Dance", 2);
			transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			anim.SetInteger("Dance", 3);
			transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
		}
	}

    void Move()
    {
        float xInput = Input.GetAxis("Yatay");
        float zInput = Input.GetAxis("Dikey");

        transform.Translate(new Vector3(xInput, 0, zInput) * 3 * Time.deltaTime);
    }
}
