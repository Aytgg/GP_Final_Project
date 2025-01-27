using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_sc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    [SerializeField]
    float sensY = 2;
    [SerializeField]
    float sensX = 2;
    void Look()
    {
        float rotY = 0;
        float rotX = 0;

        rotY += Input.GetAxis("Mouse X") * sensY;
        rotX += Input.GetAxis("Mouse Y") * -1 * sensX;

        rotX = Mathf.Clamp(rotX, -60, 60);

        // transform.localEulerAngles += new Vector3(rotX, 0, 0);
        // transform.parent.transform.rotation.y += rotY;
        transform.parent.transform.Rotate(0, rotY, 0);
        // transform.parent.transform.GetChild(2).transform.Rotate(rotX, 0, 0);
    }
}
