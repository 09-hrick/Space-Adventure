using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public float score;
    [SerializeField] private int maxLife;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Transform heartsPlaceHolder;
    public int life { get; private set; }
    
    void Start()
    {
        score = 0f;
        life = maxLife;
        foreach (Transform child in heartsPlaceHolder)
        {
            Destroy(child);
        }
        for(int i = 0; i < life; i++)
        {
            GameObject newHeartPrefab = Instantiate(heartPrefab);
            newHeartPrefab.transform.SetParent(heartsPlaceHolder, false);
        }
        Debug.Log(life);
    } 
    
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
            HighScore.instance.highScore = Mathf.Max(HighScore.instance.highScore, (int)score);
            Debug.Log("HighScore: "+ HighScore.instance.highScore);
        }
    }
    public bool deductLife()
    {
        if (life == 0)
        {
            //player is dead
            return false;
        }
        Transform childHeartToremove = heartsPlaceHolder.GetChild(life - 1);
        Destroy(childHeartToremove.gameObject);
        life--;
        return true;

    }
    public void addLife()
    {
        if(life == maxLife)
        {
            return ;
        }
        GameObject newHeartPrefab = Instantiate(heartPrefab);
        newHeartPrefab.transform.SetParent(heartsPlaceHolder, false);
        life++;
    }
}
