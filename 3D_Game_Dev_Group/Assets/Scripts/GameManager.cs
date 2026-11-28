<<<<<<< HEAD
//using UnityEngine;
//using TMPro;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager Instance;

//    [Header("UI References")]
//    public GameObject startMenuPanel;
//    public GameObject hudPanel;

//    public TextMeshProUGUI pointsText;

//    private int points = 0;

//    void Awake()
//    {
//        Instance = this;
//    }

//    void Start()
//    {
//        points = 0;

//        UpdatePointsUI();

//        // Show Start Menu
//        startMenuPanel.SetActive(true);

//        // Hide Game HUD
//        hudPanel.SetActive(false);

//        // Pause Game
//        Time.timeScale = 0f;
//    }

//    public void StartGame()
//    {
//        points = 0;

//        UpdatePointsUI();

//        startMenuPanel.SetActive(false);

//        hudPanel.SetActive(true);

//        // Start Game
//        Time.timeScale = 1f;
//    }

//    public void AddPoints(int amount)
//    {
//        points += amount;

//        UpdatePointsUI();

//        Debug.Log("Current Points: " + points);
//    }

//    void UpdatePointsUI()
//    {
//        pointsText.text = "Points: " + points;
//    }

//    public void QuitGame()
//    {
//        Time.timeScale = 1f;

//        Application.Quit();

//        Debug.Log("Game Quit");
//    }
//}

=======
>>>>>>> kalhara
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI References")]
    public GameObject startMenuPanel;
    public GameObject hudPanel;
<<<<<<< HEAD
=======

>>>>>>> kalhara
    public TextMeshProUGUI pointsText;

    private int points = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        points = 0;
<<<<<<< HEAD
        UpdatePointsUI();

        if (startMenuPanel != null)
        {
            startMenuPanel.SetActive(true);
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(false);
        }

=======

        UpdatePointsUI();

        // Show Start Menu
        startMenuPanel.SetActive(true);

        // Hide Game HUD
        hudPanel.SetActive(false);

        // Pause Game
>>>>>>> kalhara
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        points = 0;
<<<<<<< HEAD
        UpdatePointsUI();

        if (startMenuPanel != null)
        {
            startMenuPanel.SetActive(false);
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    //public void AddPoints(int amount)
    //{
    //    points += amount;

    //    UpdatePointsUI();

    //    Debug.Log("Current Points: " + points);
    //}
    public void AddPoints(int amount)
    {
        Debug.Log("6. AddPoints Method Started");

        points += amount;

        Debug.Log("7. Points Total: " + points);

        UpdatePointsUI();

        Debug.Log("8. UI Update Called");
=======

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
>>>>>>> kalhara
    }

    void UpdatePointsUI()
    {
<<<<<<< HEAD
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points;
        }
        else
        {
            Debug.LogError("Points Text is NOT assigned in GameManager!");
        }
=======
        pointsText.text = "Points: " + points;
>>>>>>> kalhara
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
<<<<<<< HEAD
        Application.Quit();
=======

        Application.Quit();

        Debug.Log("Game Quit");
>>>>>>> kalhara
    }
}
