using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static HighScore instance;
    public int highScore;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        { 
            Destroy(gameObject);
        }

    }
}