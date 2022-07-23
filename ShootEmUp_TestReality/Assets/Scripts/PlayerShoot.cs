using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float baseSpeed, maxSpeed, speedBySec;
    private float speed;


    private GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GameObject.Find("ProjectileOne");
        projectile.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Charging();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Firing();
        }
    }

    private void Charging()
    {
        speed = speed < maxSpeed ? speed += speedBySec * Time.deltaTime : maxSpeed;
    }

    private void Firing()
    {
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        projectile.GetComponent<ProjectileOneBehavior>().going = true;
        projectile.transform.position = transform.position;
        speed = baseSpeed;
    }
}
