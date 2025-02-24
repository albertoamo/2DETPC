using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagle : MonoBehaviour
{
    public float speed = 4f;
    public float AITick = 1f;

    public Rigidbody2D cRigidbody;
    public SpriteRenderer cRenderer;
    public Seeker cSeeker;
    public Transform player;

    private Path path;
    private int currentPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdatePath", 0f, AITick); //
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentPoint = 0;
        }
    }

    void UpdatePath()
    {
        cSeeker.StartPath(cRigidbody.position, player.position, OnPathComplete);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If enemy in range, we look for the player
        // Otherwise we return to our origin point

        if (path != null && currentPoint < path.vectorPath.Count)
        {
            Vector3 dir = path.vectorPath[currentPoint] - transform.position;
            Vector3 playerDir = player.position - transform.position;

            cRigidbody.linearVelocity = dir.normalized * speed;

            if (dir.magnitude < 0.1 && currentPoint < path.vectorPath.Count)
                currentPoint = currentPoint + 1;

            cRenderer.flipX = playerDir.x < 0 ? false : true;

            // If distance is smaller than quantity, hit the player
        }
    }
}
