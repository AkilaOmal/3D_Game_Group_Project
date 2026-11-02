using UnityEngine;

public class TrashCollect : MonoBehaviour
{
    private bool playerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            Debug.Log("Press E to Collect Trash");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            CollectTrash();
        }
    }

    void CollectTrash()
    {
        Debug.Log("Trash Collected!");

        Destroy(gameObject);
    }
}