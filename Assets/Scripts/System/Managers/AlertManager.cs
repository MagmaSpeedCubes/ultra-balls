using UnityEngine;

public class AlertManager : MonoBehaviour
{
    public static AlertManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple AlertManagers detected: Destroying duplicate.");
        }
    }

    // Update is called once per frame
    public void ThrowUIAlert(string type, string title, string message)
    {


    }
}
