using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private ScoreManager ScoremanagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ScoremanagerScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            bool killplayer = ScoremanagerScript.deductLife();

            if(!killplayer)
            {
                Destroy(player.gameObject);
            }
        }
    }
}
