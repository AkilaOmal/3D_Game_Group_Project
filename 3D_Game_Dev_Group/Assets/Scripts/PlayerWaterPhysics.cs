//using UnityEngine;
//using System.Collections;

//public class PlayerWaterPhysics : MonoBehaviour
//{
//    [Header("Water Settings")]
//    public LayerMask waterLayer;

//    [Header("Floating")]
//    public float floatHeight = 0.9f;
//    public float floatSpeed = 3f;

//    [Header("Sink")]
//    public float sinkDepth = 0.3f;
//    public float sinkSpeed = 1f;

//    private CharacterController controller;
//    private Animator animator;

//    private bool isInWater = false;
//    private bool isSinking = false;

//    private float waterLevel;
//    private float originalY;

//    void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        animator = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        if (isInWater)
//        {
//            HandleFloating();
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (((1 << other.gameObject.layer) & waterLayer) != 0)
//        {
//            if (!isInWater)
//            {
//                EnterWater(other);
//            }
//        }
//    }

//    void EnterWater(Collider water)
//    {
//        isInWater = true;

//        waterLevel = water.bounds.max.y;

//        originalY = transform.position.y;

//        StartCoroutine(SinkAndFloat());
//    }

//    IEnumerator SinkAndFloat()
//    {
//        isSinking = true;

//        float targetY = waterLevel - sinkDepth;

//        while (transform.position.y > targetY)
//        {
//            transform.position = Vector3.MoveTowards(
//            transform.position,
//            new Vector3(
//            transform.position.x,
//            targetY,
//            transform.position.z
//            ),
//            sinkSpeed * Time.deltaTime
//            );

//            yield return null;
//        }

//        isSinking = false;
//    }

//    void HandleFloating()
//    {
//        if (!isSinking)
//        {
//            float targetY = waterLevel - floatHeight;

//            Vector3 pos = transform.position;

//            pos.y = Mathf.Lerp(
//            pos.y,
//            targetY,
//            Time.deltaTime * floatSpeed
//            );

//            transform.position = pos;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (((1 << other.gameObject.layer) & waterLayer) != 0)
//        {
//            isInWater = false;
//            isSinking = false;
//        }
//    }
//}
using UnityEngine;
using System.Collections;

public class PlayerWaterPhysics : MonoBehaviour
{
    public float sinkDepth = 0.5f;
    public float sinkSpeed = 1f;
    public float floatHeight = 0.9f;
    public float floatSpeed = 2f;

    private CharacterController controller;

    private bool inWater = false;
    private bool sinking = false;

    private float waterLevel;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            if (!inWater)
            {
                inWater = true;

                waterLevel = other.bounds.center.y;

                if (controller != null)
                {
                    controller.enabled = false;
                }

                StartCoroutine(SinkPlayer());
            }
        }
    }

    IEnumerator SinkPlayer()
    {
        sinking = true;

        float targetY = waterLevel - sinkDepth;

        while (transform.position.y > targetY)
        {
            Vector3 pos = transform.position;

            pos.y = Mathf.MoveTowards(
            pos.y,
            targetY,
            sinkSpeed * Time.deltaTime
            );

            transform.position = pos;

            yield return null;
        }

        sinking = false;
    }

    void Update()
    {
        if (inWater && !sinking)
        {
            Vector3 pos = transform.position;

            float targetY = waterLevel - floatHeight;
        }
    }
}