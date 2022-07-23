using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBehavior : MonoBehaviour
{
    public float speed;
    public bool active;

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            transform.position -= new Vector3 (0, speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Respawn")
        {
            SpawnerBehavior.instance.DeleteEnnemy(gameObject);
        }
    }
}


