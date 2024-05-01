using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed = 5f;
    public float rotationSpeed = 50f;
    public float acceleration = 3f;
    public float deceleration = 3f;
    public float currentVelocity = 0f;
    public float currentAngle = 0f;
    private int dir = 1;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Forward(int state)
    {
        if (state != 0)
        {
            if (dir != state && currentVelocity > 0.05)
            {
                Break(2);
            }
            else
            {
                dir = state;
                Accelerate();
            }
        }
        else
        {
            Break();
        }
        if (currentVelocity > speed)
        {
            currentVelocity = speed;
        }
        if (currentVelocity - rigidbody2D.velocity.magnitude > 0.3)
        {
            currentVelocity = rigidbody2D.velocity.magnitude;
        }
        rigidbody2D.velocity = transform.up * currentVelocity * dir;
    }

    public void Rotate(float horizontalInput)
    {
        currentAngle += Time.deltaTime * horizontalInput * rotationSpeed;
        rigidbody2D.rotation = -currentAngle;
    }

    private void Accelerate()
    {
        currentVelocity += Time.deltaTime * acceleration;
        currentVelocity = Mathf.Min(currentVelocity, speed);
    }
    private void Break(int multiplyer = 1)
    {
        currentVelocity -= Time.deltaTime * deceleration * multiplyer;
        currentVelocity = Mathf.Max(currentVelocity, 0);
    }
}
