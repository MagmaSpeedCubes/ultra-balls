using UnityEngine;
using System.Collections.Generic;
public class LevelManager : MonoBehaviour
{
    [SerializeField] protected int ballLayer;
    public static LevelManager instance;
    public List<BallManager> activeBalls;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Debug.LogWarning("Multiple instances detected for LevelManager. Destroying duplicate.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Physics2D.IgnoreLayerCollision(ballLayer, ballLayer, true);
    }

    void AbilityTick()
    {
        foreach(BallManager ball in activeBalls)
        {
            if(ball != null)
            {
                ball.OnAbilityTick();
            }
            else
            {
                activeBalls.Remove(ball);
            }
            
        }
    }

    public void StartLevel()
    {
        InvokeRepeating("AbilityTick", LevelStats.ABILITY_TICK_INTERVAL, LevelStats.ABILITY_TICK_INTERVAL);

    }

    public void EndLevel()
    {
        CancelInvoke("AbilityTick");
    }

    public void AddBall(BallManager ball)
    {
        activeBalls.Add(ball);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
}
