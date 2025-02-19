using UnityEngine;

public class ProjectileFollow : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform targetPosition;
    public Vector3 origVelocity = Vector3.up;

    public float speed = 18f;
    public float duration = 1f;     // Duration to complete the interpolation (1 second)
    private float timeElapsed = 0f;  // Time that has passed since the start of interpolation

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        float t = Mathf.Clamp01(timeElapsed / duration);

        Vector3 targetVelocity = (targetPosition.position - transform.position).normalized;
        Vector3 targetVector = Vector3.Lerp(origVelocity, targetVelocity, t);

        // Apply the velocity to the rigidbody 
        rb.linearVelocity = targetVector * speed * Time.fixedDeltaTime;
    }
}
