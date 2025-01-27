using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField] AudioClip[] sfxClips;
    /**
    * 0 - eewww
    * 1 - fire
    * 2 - x
    * 3 - x
    */
    GameObject leftWall, rightWall;

    void Start()
    {
        leftWall = GameObject.Find("Left");
        rightWall = GameObject.Find("Right");
    }

    void Update()
    {
        if (!PauseMenu_sc.isPaused)
        {
            Move();
            Fire();
            PlaySound();

            ChangeScene();
        }
    }

    void ChangeScene()
    {
        if (Input.GetButtonDown("Submit"))
        {
            PauseMenu_sc pm = GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenu_sc>();
            if (GameManager_sc.currentScene == 1)
                pm.LoadScene(2);
            else if (GameManager_sc.currentScene == 2)
                pm.LoadScene(1);

            AudioSource.PlayClipAtPoint(sfxClips[2], transform.position);
        }
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
        {
            Instantiate(
                bulletPrefab,
                // transform.GetChild(2).transform.position,
                transform.GetChild(2).transform.GetChild(2).transform.position,// + new Vector3(-.2f, .2f, .5f),
                // transform.position + new Vector3(0.55f, 1.2f, 0.4f),
                transform.GetChild(2).transform.rotation * Quaternion.Euler(90, 0, 0)
                // transform.rotation * Quaternion.Euler(90, 0, 0)
                // Quaternion.Euler(90, 0, 0)
            );

            AudioSource.PlayClipAtPoint(sfxClips[1], transform.position);
        }
    }

    void PlaySound()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            AudioSource.PlayClipAtPoint(sfxClips[0], leftWall.transform.position, 1f);
        if (Input.GetKeyDown(KeyCode.E))
            AudioSource.PlayClipAtPoint(sfxClips[0], rightWall.transform.position, 1f);
    }
}
