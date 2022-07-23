using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOneBehavior : MonoBehaviour
{
    public float multiplicatorSpeed = 0.99f, forceReturn = 3;
    private Rigidbody2D rB;
    public bool going = false;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
{
        if(going)
        {
            rB.velocity *= multiplicatorSpeed;
            if (rB.velocity.magnitude < 1)
            {
                going = false;
            }             
        }
        else
        {
            rB.velocity = (player.position - transform.position).normalized * rB.velocity.magnitude * (1 + 1 - multiplicatorSpeed) * forceReturn;

            if(Vector2.Distance(transform.position, player.position) < 0.5f)
            {
                rB.velocity = Vector2.zero;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Ennemi")
        {
            SpawnerBehavior.instance.DeleteEnnemy(collider.gameObject);
        }
    }
}
