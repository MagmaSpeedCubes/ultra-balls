using UnityEngine;

public class GlassDamageManager : DamageManager
{

    override public void Damage(float amount, string type, BallManager source = null)
    {
        if (amount >= maxHealth)
        {
            Destroy(source.gameObject);
            base.Damage(maxHealth, type, source);
        }

    }


}
