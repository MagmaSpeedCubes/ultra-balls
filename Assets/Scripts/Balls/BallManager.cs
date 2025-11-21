using UnityEngine;
using System;

public class BallManager : MonoBehaviour
{
    public Ball ballData;
    
    protected Rigidbody2D rb;
    protected SpriteRenderer spr;
    [HideInInspector]public int numBounces = 0;
    void Awake()
    {
        Initialize();

    }

    protected void Initialize()
    {
        numBounces = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = ballData.gravityScale;
        transform.localScale = Vector3.one * ballData.sizeMultiplier;
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = ballData.sprite;
        spr.color = ballData.defaultColor;
        ApplyRandomForce();


    }

    protected void ApplyRandomForce()
    {
        float angle = UnityEngine.Random.Range(0f, ballData.powerMultiplier * Mathf.PI);
        Vector2 force = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * UnityEngine.Random.Range(5f, 10f);
        rb.AddForce(force, ForceMode2D.Impulse);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null)
        {
            HandleCollisions(damageable);
        }
    }

    virtual public void HandleCollisions(Damageable damageable)
    {
        object damageAmount = ReflectionCaller.CallReturnableFunction<float>("DamageFormulas", ballData.name, this);
        float damage = Convert.ToSingle(damageAmount);

        Damage(damage, damageable);
        
        numBounces++;
    }


    virtual public void Damage(float damage, Damageable other)
    {
        other?.Damage(damage, ballData.name);

    }
}
