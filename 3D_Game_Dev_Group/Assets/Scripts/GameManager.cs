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
        startMenuPanel.SetActive(true);

        // Hide Game HUD
        hudPanel.SetActive(false);

        // Pause Game
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        points = 0;

        UpdatePointsUI();

        startMenuPanel.SetActive(false);

        hudPanel.SetActive(true);

        // Start Game
        Time.timeScale = 1f;
    }

    public void AddPoints(int amount)
    {
        points += amount;

        UpdatePointsUI();

        Debug.Log("Current Points: " + points);
    }

    void UpdatePointsUI()
    {
        pointsText.text = "Points: " + points;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;

        Application.Quit();

        Debug.Log("Game Quit");
    }
}
