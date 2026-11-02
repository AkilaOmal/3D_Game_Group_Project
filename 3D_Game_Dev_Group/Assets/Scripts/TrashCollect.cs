//using UnityEngine;

//public class TrashCollect : MonoBehaviour
//{
//    private bool playerNearby = false;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerNearby = true;

//            Debug.Log("Press E to Collect Trash");
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerNearby = false;
//        }
//    }

//    void Update()
//    {
//        if (playerNearby && Input.GetKeyDown(KeyCode.E))
//        {
//            CollectTrash();
//        }
//    }

//    void CollectTrash()
//    {
//        Debug.Log("Trash Collected!");

//        Destroy(gameObject);
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
        if (other.transform.root.CompareTag("Player"))
        {
            playerNearby = true;

            Debug.Log("Press E to Collect");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    void Update()
    {
        if (playerNearby &&
        Keyboard.current != null &&
        Keyboard.current.eKey.wasPressedThisFrame)
        {
            CollectTrash();
        }
    }

    void CollectTrash()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddPoints(pointsValue);
        }

        Debug.Log("Trash Collected!");

        Destroy(gameObject);
    }
}