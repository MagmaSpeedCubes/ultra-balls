using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Damageable", menuName = "Scriptable Objects/Damageable")]
public class Damageable : ScriptableObject
{
    public float armor = 0f;

    public AudioClip damageSound;
    public AudioClip deathSound;
    
}