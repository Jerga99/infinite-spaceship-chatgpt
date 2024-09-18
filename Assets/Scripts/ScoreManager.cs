using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;

    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }
}
