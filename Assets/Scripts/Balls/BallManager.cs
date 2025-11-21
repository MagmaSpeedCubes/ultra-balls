using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Ball ballData;
    protected float power = 1f;
    
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = ballData.gravityScale;
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
        other?.Damage(power, "basic");

    }
}
