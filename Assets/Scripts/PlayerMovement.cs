using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private ScoreManager scoreManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    
    void Update()
    {
        float directionY = Input.GetAxis("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (0, playerDirection.y*playerSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Life")
        {
            scoreManager.addLife();
        }
        Destroy(collision.gameObject);
    }
}
