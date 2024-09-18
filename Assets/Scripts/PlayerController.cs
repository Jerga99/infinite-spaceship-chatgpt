using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float throttlePower = 10f;
    public float gravity = -15f;
    private float verticalVelocity = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            verticalVelocity = throttlePower;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        transform.Translate(new Vector3(0, verticalVelocity * Time.deltaTime, 0));

        if (IsOutOfCameraView())
        {
            // Load the Game Over scene
            SceneManager.LoadScene("GameOverScene");
        }
    }

    bool IsOutOfCameraView()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        return screenPos.y < 0.05f || screenPos.y > 0.95f;
    }
}
