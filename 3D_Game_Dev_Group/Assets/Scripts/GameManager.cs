using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI References")]
    public GameObject startMenuPanel;
    public GameObject hudPanel;
    public TextMeshProUGUI pointsText;

    private int points = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        points = 0;
        UpdatePointsUI();

        // Show Start Menu
        if (startMenuPanel != null)
        {
            startMenuPanel.SetActive(true);
        }

        // Hide Game HUD
        if (hudPanel != null)
        {
            hudPanel.SetActive(false);
        }

        // Pause Game
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        points = 0;
        UpdatePointsUI();

        if (startMenuPanel != null)
        {
            startMenuPanel.SetActive(false);
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(true);
        }

        // Start Game
        Time.timeScale = 1f;
    }

    public void AddPoints(int amount)
    {
        Debug.Log("AddPoints Method Started");

        points += amount;

        Debug.Log("Current Points: " + points);

        UpdatePointsUI();
    }

    void UpdatePointsUI()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points;
        }
        else
        {
            Debug.LogError("Points Text is NOT assigned in GameManager!");
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;

        Application.Quit();

        Debug.Log("Game Quit");
    }
}
