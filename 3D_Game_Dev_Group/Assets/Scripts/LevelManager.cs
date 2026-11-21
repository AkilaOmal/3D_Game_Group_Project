
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class LevelManager : MonoBehaviour
//{
//    public void OpenLevel1()
//    {
//        SceneManager.LoadScene("Level1");
//    }

//    public void OpenLevel2()
//    {
//        SceneManager.LoadScene("Level2");
//    }

//    public void OpenLevel3()
//    {
//        SceneManager.LoadScene("Level3");
//    }
//}

//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class LevelManager : MonoBehaviour
//{
//    public void CompleteLevel1()
//    {
//        PlayerPrefs.SetInt("Level2Unlocked", 1);
//        PlayerPrefs.Save();

//        SceneManager.LoadScene("Level2");
//    }

//    public void CompleteLevel2()
//    {
//        PlayerPrefs.SetInt("Level3Unlocked", 1);
//        PlayerPrefs.Save();

//        SceneManager.LoadScene("Level3");
//    }

//    public void CompleteLevel3()
//    {
//        PlayerPrefs.SetInt("GameCompleted", 1);
//        PlayerPrefs.Save();

//        SceneManager.LoadScene("Level3");
//    }
//}


using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Open Level 1
    public void OpenLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    // Open Level 2 only if unlocked
    public void OpenLevel2()
    {
        if (PlayerPrefs.GetInt("Level2Unlocked", 0) == 1)
        {
            SceneManager.LoadScene("Level2");
        }
    }

    // Open Level 3 only if unlocked
    public void OpenLevel3()
    {
        if (PlayerPrefs.GetInt("Level3Unlocked", 0) == 1)
        {
            SceneManager.LoadScene("Level3");
        }
    }

    // Complete Level 1 and unlock Level 2
    public void CompleteLevel1()
    {
        PlayerPrefs.SetInt("Level2Unlocked", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Level2");
    }

    // Complete Level 2 and unlock Level 3
    public void CompleteLevel2()
    {
        PlayerPrefs.SetInt("Level3Unlocked", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Level3");
    }

    // Complete Level 3
    public void CompleteLevel3()
    {
        PlayerPrefs.SetInt("GameCompleted", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("LevelSelect");
    }
}
