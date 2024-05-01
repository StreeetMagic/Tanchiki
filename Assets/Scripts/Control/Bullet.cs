using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 25;
    public Rigidbody2D rb;
    void Awake()
    {
        Destroy(gameObject, 5f);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.collider.name);
        if (other.gameObject.tag == "Player" && other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().SetDamage(damage);
        }
        Destroy(gameObject);
    }

}
