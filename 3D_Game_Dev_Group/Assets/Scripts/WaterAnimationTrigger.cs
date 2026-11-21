
using UnityEngine;

public class WaterAnimationTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator animator = other.GetComponentInChildren<Animator>();

            if (animator != null)
            {
                animator.SetBool("InWater", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator animator = other.GetComponentInChildren<Animator>();

            if (animator != null)
            {
                animator.SetBool("InWater", false);
                animator.SetFloat("SwimSpeed", 0f);
            }
        }
    }
}
