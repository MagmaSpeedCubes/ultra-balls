using UnityEngine;

public class Ball : MonoBehaviour
{
    public float gravityScale = 1.0f;
    public float power = 1f;
    private Rigidbody2d rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null)
        {
            Damage(damageable);
        }
    }


    virtual public void Damage(Damageable other)
    {
        other?.damage(power, "basic");

    }
}
