//using UnityEngine;
//using UnityEngine.InputSystem;

//public class TrashCollect : MonoBehaviour
//{
//    public int pointsValue = 10;

//    private bool playerNearby = false;

//private void OnTriggerEnter(Collider other)
//{
//    if (other.transform.root.CompareTag("Player"))
//    {
//        playerNearby = true;

//        Debug.Log("Press E to Collect");
//    }
//}

//private void OnTriggerExit(Collider other)
//{
//    if (other.transform.root.CompareTag("Player"))
//    {
//        playerNearby = false;
//    }
//}

//void Update()
//{
//    if (playerNearby &&
//    Keyboard.current != null &&
//    Keyboard.current.eKey.wasPressedThisFrame)
//    {
//        CollectTrash();
//    }
//}

//void CollectTrash()
//{
//    if (GameManager.Instance != null)
//    {
//        GameManager.Instance.AddPoints(pointsValue);
//    }

//    Debug.Log("Trash Collected!");

//    Destroy(gameObject);
//}
//private void OnTriggerEnter(Collider other)
//{
//    Debug.Log("Trigger Enter: " + other.name);

//    if (other.transform.root.CompareTag("Player"))
//    {
//        playerNearby = true;

//        Debug.Log("Player Nearby");
//        Debug.Log("Press E to Collect");
//    }
//}
//    private void Start()
//    {
//        Debug.Log("TrashCollect Script Started");
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        Debug.Log("TRIGGER DETECTED: " + other.name);
//    }
//}

using UnityEngine;
using UnityEngine.InputSystem;

public class TrashCollect : MonoBehaviour
{
    public int pointsValue = 10;

    private bool playerNearby = false;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER DETECTED: " + other.name);

        CharacterController playerController =
            other.GetComponentInParent<CharacterController>();

        if (playerController != null)
        {
            playerNearby = true;

            Debug.Log("PLAYER NEAR TRASH");
            Debug.Log("Press E to Collect");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterController playerController =
            other.GetComponentInParent<CharacterController>();

        if (playerController != null)
        {
            playerNearby = false;

            Debug.Log("PLAYER LEFT TRASH");
        }
    }



    //void Update()
    //{
    //    if (playerNearby == false)
    //    {
    //        return;
    //    }

    //    if (Keyboard.current != null &&
    //        Keyboard.current.eKey.wasPressedThisFrame)
    //    {
    //        Debug.Log("E KEY PRESSED");

    //        CollectTrash();
    //    }
    //}
    void Update()
    {
        if (playerNearby &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            CollectTrash();
        }
    }


    //void CollectTrash()
    //{
    //    Debug.Log("COLLECT FUNCTION CALLED");

    //    if (GameManager.Instance != null)
    //    {
    //        void CollectTrash()
    //        {
    //            Debug.Log("COLLECT FUNCTION CALLED");

    //            if (GameManager.Instance != null)
    //            {
    //                GameManager.Instance.AddPoints(pointsValue);

    //                Debug.Log("POINTS ADDED: " + pointsValue);
    //            }
    //            else
    //            {
    //                Debug.LogError("GameManager Instance is NULL");
    //            }

    //            Destroy(gameObject);
    //        }

    //    }
    //}
    void CollectTrash()
    {
        Debug.Log("1. COLLECT FUNCTION CALLED");

        if (GameManager.Instance == null)
        {
            Debug.LogError("2. GameManager Instance is NULL!");
            return;
        }

        Debug.Log("3. GameManager Instance Found");

        Debug.Log("4. Points Value: " + pointsValue);

        GameManager.Instance.AddPoints(pointsValue);

        Debug.Log("5. AddPoints Method Finished");

        Destroy(gameObject);
    }
}


