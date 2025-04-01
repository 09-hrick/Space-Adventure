using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameStartPanel;
    [SerializeField] private GameObject player;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Text highScorePlaceHolder;

    private bool isGameOver = false;

    void Start()
    {
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false); // Hide Game Over panel initially
        DisablePlayer();
    }

    void Update()
    {
        if (!isGameOver && (player == null || !player.activeInHierarchy))
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);
            highScorePlaceHolder.text = HighScore.instance.highScore.ToString();
        }
    }

    public void StartGame()
    {
        gameStartPanel.SetActive(false);
        EnablePlayer();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DisablePlayer()
    {
        player.GetComponent<Rigidbody2D>().simulated = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        scoreManager.enabled = false;
    }

    private void EnablePlayer()
    {
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        scoreManager.enabled = true;
    }
}
