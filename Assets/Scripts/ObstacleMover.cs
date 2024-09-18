using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destroy the obstacle if it goes off-screen
        if (IsOutOfCameraView())
        {
            Destroy(gameObject);
        }
    }

    bool IsOutOfCameraView()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        return screenPos.x < 0;
    }
}
