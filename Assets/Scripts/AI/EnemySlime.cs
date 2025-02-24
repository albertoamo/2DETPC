using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// El enemigo se mueva de un waypoint al siguiente
// El enemigo persiga al jugador y le cause da�o si esta dentro de un rango

public class EnemySlime : MonoBehaviour
{
    public Rigidbody2D cRigidbody;
    public SpriteRenderer cRenderer;
    public Transform[] waypoints;

    // AI Self variables
    public float speed = 0.5f;

    // AI Logic Variables
    public float detDistance = 3f;
    public float damageForce = 5f;

    private int currentPoint = 0;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerDir = player.transform.position - transform.position; //Posicion jugador - posicion enemigo

        if (playerDir.magnitude < detDistance && playerDir.x > 0) // El jugador esta dentro del rango y lo estoy viendo
        {
            Debug.Log("El enemigo persige al jugador");

            cRigidbody.linearVelocity = new Vector2(playerDir.normalized.x * speed, cRigidbody.linearVelocity.y);
        }
        else
        {
            Vector3 dir = waypoints[currentPoint].position - transform.position;
            dir.y = 0;
            Debug.Log(dir.magnitude);
            // Bucle de la patrol
            if (dir.magnitude < 0.25f)
            {
                currentPoint = (currentPoint + 1) % waypoints.Length;
                Debug.Log("He llegado al waypoint");
            }

            cRigidbody.linearVelocity = new Vector2(dir.normalized.x * speed, cRigidbody.linearVelocity.y);
        }

        EnemyOrientation();
    }

    void EnemyOrientation()
    {
        // Accedo al componente Sprite Renderer
        if (cRigidbody.linearVelocity.x < 0)
            cRenderer.flipX = false;
        else if (cRigidbody.linearVelocity.x > 0)
            cRenderer.flipX = true;
    }

    // Entramos dentro del trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthController hCtr = collision.gameObject.GetComponent<PlayerHealthController>();

        if(hCtr)
        {
            hCtr.Damage();

            Rigidbody2D cRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            cRigidbody.AddForce(Vector2.up * damageForce, ForceMode2D.Impulse); // Vector2.up == new Vector2(0,1)

            Debug.Log(collision.name);
        }
    }
}
