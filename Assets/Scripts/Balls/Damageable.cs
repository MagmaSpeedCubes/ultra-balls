using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth = 100f;
    public float armor = 0f;
    public Infographic[] healthBars;
    [HideInInspector] public float health;


    void Awake()
    {
        health = maxHealth;
        UpdateInfographics();

    }

    public void Damage(float amount, string type)
    {
        health -= amount * (1-armor);

        if (health <= 0)
        {
            Die();
        }
        else
        {
            UpdateInfographics();
        }
    }

    void UpdateInfographics()
    {
        foreach (Infographic bar in healthBars)
        {
            bar.setValue(health);
        }
    }

    

    void Die()
    {
        Destroy(gameObject);
    }
}
