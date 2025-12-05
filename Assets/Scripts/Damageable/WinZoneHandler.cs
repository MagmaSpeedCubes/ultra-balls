using UnityEngine;

public class WinHandler : DamageHandler
{
    override public void Damage(float amount, string type, BallHandler source = null)
    {
        LevelManager.instance.EndLevel();
    }
}
