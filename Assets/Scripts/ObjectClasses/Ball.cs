using UnityEngine;

[System.Serializable]
public class Ball : MonoBehaviour
{

    [HideInInspector] public Sprite sprite;
    public BallPrefab prefab;
    public Ownable ownable;

    [HideInInspector]public float gravity;
    [HideInInspector]public float power;
    [HideInInspector]public float size;
    [HideInInspector]public float movementSpeed;
    [HideInInspector]public int price;

    [HideInInspector]public AudioClip bounceSound;
    [HideInInspector]public AudioClip specialSound;


    public GameObject ballPrefabObject;

    public Ball(BallPrefab pfb, Ownable own)
    {
        prefab = pfb;
        ownable = own;

    }
    void Awake()
    {
        float gravityMultiplier = float.Parse(ownable.FindTag("gravityMultiplier"));
        gravity = prefab.gravity * gravityMultiplier;

        float powerMultiplier = float.Parse(ownable.FindTag("powerMultiplier"));
        power = prefab.power * powerMultiplier;

        float sizeMultiplier = float.Parse(ownable.FindTag("sizeMultiplier"));
        size = prefab.size * sizeMultiplier;

        float movementSpeedMultiplier = float.Parse(ownable.FindTag("movementSpeedMultiplier"));
        movementSpeed = prefab.movementSpeed * movementSpeedMultiplier;

        float priceMultiplier = float.Parse(ownable.FindTag("priceMultiplier"));
        price = (int)(prefab.price * priceMultiplier);

        sprite = ownable.sprite;

        bounceSound = prefab.bounceSound;
        specialSound = prefab.specialSound;
    }
}
