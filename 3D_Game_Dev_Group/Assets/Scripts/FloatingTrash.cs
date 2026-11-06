using UnityEngine;

public class FloatingTrash : MonoBehaviour
{
    [Header("Water Settings")]
    public float waterLevel = 0.5f;

    [Header("Flow Settings")]
    public Vector3 flowDirection = new Vector3(0, 0, 1);
    public float flowSpeed = 0.5f;

    [Header("Floating Animation")]
    public float floatAmount = 0.05f;
    public float floatFrequency = 1f;

    private Vector3 startPosition;
    private Vector3 direction;

    void Start()
    {
        startPosition = transform.position;

        direction = flowDirection.normalized;
    }

    void Update()
    {
        // Move along river
        transform.position +=
        direction * flowSpeed * Time.deltaTime;

        // Floating movement
        float wave = Mathf.Sin(
        Time.time * floatFrequency
        ) * floatAmount;

        Vector3 pos = transform.position;

        pos.y = waterLevel + wave;

        transform.position = pos;
    }
}