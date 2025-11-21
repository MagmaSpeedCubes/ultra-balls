using UnityEngine;

public class MitosisManager : BallManager
{
    [SerializeField] protected float bounceGrowAmount = 0.1f;
    [SerializeField] protected int copies = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null)
        {
            HandleCollisions(damageable);
        }
    }

    override public void HandleCollisions(Damageable damageable)
    {
        base.HandleCollisions(damageable);
        ballData.sizeMultiplier += bounceGrowAmount;
        transform.localScale = Vector3.one * ballData.sizeMultiplier;

        if(ballData.sizeMultiplier > 1.0f)
        {
            //split into two balls of half size each
            for(int i=0; i < copies; i++)
            {
                Debug.Log("Split #" + i);
                GameObject newBall = Instantiate(this.gameObject, transform.position, Quaternion.identity);
                BallManager newBallManager = newBall.GetComponent<BallManager>();
                newBallManager.ballData = this.ballData;
                newBallManager.numBounces = 0;
                newBall.transform.localScale = Vector3.one * (ballData.sizeMultiplier / 2.0f);
                ballData.sizeMultiplier /= copies;
                transform.localScale = Vector3.one * ballData.sizeMultiplier;

            }
            Debug.Log("Split complete");
            Destroy(this.gameObject);
            
            

        } 
    }
}
