using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Ground")]
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float acceleration = 10f;
    public float turnSpeed = 720f;
    public float jumpHeight = 1.2f;
    public float gravity = -20f;

    [Header("Water")]
    public float swimSpeed = 2f;
    public float sinkSpeed = 1.5f;
    public float swimUpSpeed = 2.5f;
    public float swimDepth = 0.6f;
    public float floatDepth = 1.0f;

    CharacterController cc;
    Animator anim;
    Transform cam;

    Vector3 velocity;
    Vector3 moveDir;

    float currentSpeed;

    readonly List<WaterZone> waters = new List<WaterZone>();

    // Animator parameter checks
    bool hasSpeed;
    bool hasMotion;
    bool hasGrounded;
    bool hasJump;
    bool hasFreeFall;
    bool hasInWater;
    bool hasSwimSpeed;

    void Start()
    {
        cc = GetComponent<CharacterController>();

        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogError("Main Camera not found!");
        }

        anim = GetComponentInChildren<Animator>();

        if (anim != null)
        {
            anim.applyRootMotion = false;

            foreach (AnimatorControllerParameter p in anim.parameters)
            {
                if (p.name == "Speed") hasSpeed = true;
                if (p.name == "MotionSpeed") hasMotion = true;
                if (p.name == "Grounded") hasGrounded = true;
                if (p.name == "Jump") hasJump = true;
                if (p.name == "FreeFall") hasFreeFall = true;
                if (p.name == "InWater") hasInWater = true;
                if (p.name == "SwimSpeed") hasSwimSpeed = true;
            }
        }
        else
        {
            Debug.LogError("Animator not found on Player!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        WaterZone water = other.GetComponentInParent<WaterZone>();

        if (water != null && !waters.Contains(water))
        {
            waters.Add(water);
        }
    }

    void OnTriggerExit(Collider other)
    {
        WaterZone water = other.GetComponentInParent<WaterZone>();

        if (water != null)
        {
            waters.Remove(water);
        }
    }

    float WaterSurface()
    {
        float y = float.MinValue;

        foreach (WaterZone water in waters)
        {
            y = Mathf.Max(y, water.SurfaceY);
        }

        return y;
    }

    void Update()
    {
        Keyboard k = Keyboard.current;

        if (k == null || cam == null)
        {
            return;
        }

        // Check water
        float depth = 0f;

        if (waters.Count > 0)
        {
            depth = WaterSurface() - transform.position.y;
        }

        bool swimming = waters.Count > 0 && depth > swimDepth;

        // Keyboard input
        float x = (k.dKey.isPressed ? 1 : 0)
                - (k.aKey.isPressed ? 1 : 0);

        float z = (k.wKey.isPressed ? 1 : 0)
                - (k.sKey.isPressed ? 1 : 0);

        Vector3 camF = cam.forward;
        camF.y = 0;
        camF.Normalize();

        Vector3 camR = cam.right;
        camR.y = 0;
        camR.Normalize();

        Vector3 input = camF * z + camR * x;

        bool hasInput = input.sqrMagnitude > 0.01f;

        if (hasInput)
        {
            moveDir = input.normalized;

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(moveDir),
                turnSpeed * Time.deltaTime
            );
        }

        // Horizontal movement
        float targetSpeed = 0f;

        if (hasInput)
        {
            if (swimming)
            {
                targetSpeed = swimSpeed;
            }
            else if (k.leftShiftKey.isPressed)
            {
                targetSpeed = runSpeed;
            }
            else
            {
                targetSpeed = walkSpeed;
            }
        }

        currentSpeed = Mathf.Lerp(
            currentSpeed,
            targetSpeed,
            acceleration * Time.deltaTime
        );

        if (currentSpeed < 0.05f)
        {
            currentSpeed = 0f;
        }

        // Vertical movement
        bool grounded = cc.isGrounded;
        bool jumped = false;

        if (swimming)
        {
            float targetY = -sinkSpeed;

            if (k.spaceKey.isPressed)
            {
                targetY = depth > floatDepth ? swimUpSpeed : 0f;
            }

            velocity.y = Mathf.MoveTowards(
                velocity.y,
                targetY,
                8f * Time.deltaTime
            );
        }
        else
        {
            if (grounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            if (grounded && k.spaceKey.wasPressedThisFrame)
            {
                velocity.y = Mathf.Sqrt(
                    jumpHeight * -2f * gravity
                );

                jumped = true;
            }

            velocity.y += gravity * Time.deltaTime;
        }

        // Move player
        cc.Move(
            (moveDir * currentSpeed + Vector3.up * velocity.y)
            * Time.deltaTime
        );

        // Animation
        if (anim != null)
        {
            float groundAnimationSpeed = 0f;

            if (!swimming)
            {
                groundAnimationSpeed = Mathf.Clamp01(
                    currentSpeed / runSpeed
                );
            }

            if (hasSpeed)
            {
                anim.SetFloat("Speed", groundAnimationSpeed);
            }

            if (hasMotion)
            {
                anim.SetFloat("MotionSpeed", hasInput ? 1f : 0f);
            }

            if (hasGrounded)
            {
                anim.SetBool("Grounded", swimming || grounded);
            }

            if (hasJump)
            {
                anim.SetBool("Jump", !swimming && jumped);
            }

            if (hasFreeFall)
            {
                anim.SetBool(
                    "FreeFall",
                    !swimming && !grounded && velocity.y < 0f
                );
            }

            if (hasInWater)
            {
                anim.SetBool("InWater", swimming);
            }

            float waterAnimationSpeed = 0f;

            if (swimming && hasInput)
            {
                waterAnimationSpeed = 1f;
            }

            if (hasSwimSpeed)
            {
                anim.SetFloat("SwimSpeed", waterAnimationSpeed);
            }
        }
    }
}

