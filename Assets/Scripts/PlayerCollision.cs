using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private int lives = 3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            lives--;
            Destroy(collision.gameObject);

            if (lives <= 0)
            {
                // Load Game Over scene or display Game Over UI
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
