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

    void Update()
    {
        if (playerNearby &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E KEY PRESSED");

            CollectTrash();
        }
    }

    void CollectTrash()
    {
        Debug.Log("COLLECT FUNCTION CALLED");

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager Instance is NULL!");
            return;
        }

        Debug.Log("GameManager Instance Found");
        Debug.Log("Points Value: " + pointsValue);

        GameManager.Instance.AddPoints(pointsValue);

        Debug.Log("POINTS ADDED: " + pointsValue);

        Destroy(gameObject);
    }
}
