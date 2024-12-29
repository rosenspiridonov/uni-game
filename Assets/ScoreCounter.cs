using TMPro;

using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score = 0;

    private void Update()
    {
        score += Time.deltaTime;
    }

    private void OnGUI()
    {
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }
}
