using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] private Button button;

    private readonly float _buttonFlashSpeed = 2.0f;
    

    public void UpdateText(string newScoreText,string newTimerText)
    {
        scoreText.text = newScoreText;
        timerText.text = newTimerText;
    }
    
    public void StartUpgradeButtonFlashing()
    {
        var alpha = Mathf.PingPong(Time.time * _buttonFlashSpeed, 1.0f);
        var newColor = button.colors;
        newColor.normalColor = new Color(newColor.normalColor.r,newColor.normalColor.g,newColor.normalColor.b, alpha);
        button.colors = newColor;
    }
}
