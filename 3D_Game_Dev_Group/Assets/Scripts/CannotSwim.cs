
using UnityEngine;
using TMPro;
using System.Collections;

public class CannotSwim : MonoBehaviour
{
    public CharacterController controller;
    public MonoBehaviour playerMovement;
    public Transform safePoint;
    public TMP_Text messageText;

    private bool inWater = false;

    void Start()
    {
        messageText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !inWater)
        {
            StartCoroutine(ReturnToLand());
        }
    }

    IEnumerator ReturnToLand()
    {
        inWater = true;

        // Stop player movement
        playerMovement.enabled = false;

        // Show message
        messageText.text = "You can't swim! Returning to land...";
        messageText.gameObject.SetActive(true);

        // Return player to safe point
        controller.enabled = false;
        transform.position = safePoint.position;
        controller.enabled = true;

        // Wait 2 seconds
        yield return new WaitForSeconds(2f);

        // Hide message
        messageText.gameObject.SetActive(false);

        // Enable player movement
        playerMovement.enabled = true;

        inWater = false;
    }
}
