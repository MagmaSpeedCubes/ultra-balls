using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;


    void Awake()
    {
        health = maxHealth;
    }

    void Damage(float amount, string type)
    {
        
    }
}
