<<<<<<< HEAD
//using System.Collections.Generic;
=======
>>>>>>> kalhara
//using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
//public class PlayerMovement : MonoBehaviour
//{
<<<<<<< HEAD
//    [Header("Ground")]
=======
>>>>>>> kalhara
//    public float walkSpeed = 3f;
//    public float runSpeed = 6f;
//    public float acceleration = 10f;
//    public float turnSpeed = 720f;
//    public float jumpHeight = 1.2f;
//    public float gravity = -20f;

<<<<<<< HEAD
//    [Header("Water")]
//    public float swimSpeed = 2f;
//    public float sinkSpeed = 1.5f;
//    public float swimUpSpeed = 2.5f;
//    public float swimDepth = 0.6f;   // water height above feet where swimming starts
//    public float floatDepth = 1.0f;  // depth where you float when holding Space

=======
>>>>>>> kalhara
//    CharacterController cc;
//    Animator anim;
//    Transform cam;
//    Vector3 velocity;
//    Vector3 moveDir;
//    float currentSpeed;
<<<<<<< HEAD
//    readonly List<WaterZone> waters = new List<WaterZone>();
=======
>>>>>>> kalhara
//    bool hasSpeed, hasMotion, hasGrounded, hasJump, hasFreeFall;

//    void Start()
//    {
//        cc = GetComponent<CharacterController>();
//        cam = Camera.main.transform;
//        anim = GetComponentInChildren<Animator>();

//        if (anim != null)
//        {
//            anim.applyRootMotion = false;
//            foreach (var p in anim.parameters)
//            {
//                if (p.name == "Speed") hasSpeed = true;
//                if (p.name == "MotionSpeed") hasMotion = true;
//                if (p.name == "Grounded") hasGrounded = true;
//                if (p.name == "Jump") hasJump = true;
//                if (p.name == "FreeFall") hasFreeFall = true;
//            }
//        }
//    }

<<<<<<< HEAD
//    void OnTriggerEnter(Collider other)
//    {
//        Debug.Log("Entered: " + other.name);
//        var w = other.GetComponentInParent<WaterZone>();
//        if (w != null && !waters.Contains(w)) waters.Add(w);
//    }

//    void OnTriggerExit(Collider other)
//    {
//        var w = other.GetComponentInParent<WaterZone>();
//        if (w != null) waters.Remove(w);
//    }

//    float WaterSurface()
//    {
//        float y = float.MinValue;
//        foreach (var w in waters) y = Mathf.Max(y, w.SurfaceY);
//        return y;
//    }

=======
>>>>>>> kalhara
//    void Update()
//    {
//        var k = Keyboard.current;
//        if (k == null) return;

<<<<<<< HEAD
//        // Water state
//        float depth = waters.Count > 0 ? WaterSurface() - transform.position.y : 0f;
//        bool swimming = waters.Count > 0 && depth > swimDepth;

//        // Input
=======
>>>>>>> kalhara
//        float x = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
//        float z = (k.wKey.isPressed ? 1 : 0) - (k.sKey.isPressed ? 1 : 0);

//        Vector3 camF = cam.forward; camF.y = 0; camF.Normalize();
//        Vector3 camR = cam.right; camR.y = 0; camR.Normalize();
<<<<<<< HEAD
//        Vector3 input = camF * z + camR * x;
=======
//        Vector3 input = (camF * z + camR * x);
>>>>>>> kalhara
//        bool hasInput = input.sqrMagnitude > 0.01f;

//        if (hasInput)
//        {
//            moveDir = input.normalized;
//            transform.rotation = Quaternion.RotateTowards(
//                transform.rotation,
//                Quaternion.LookRotation(moveDir),
//                turnSpeed * Time.deltaTime);
//        }

<<<<<<< HEAD
//        // Horizontal speed
//        float target = 0f;
//        if (hasInput)
//            target = swimming ? swimSpeed : (k.leftShiftKey.isPressed ? runSpeed : walkSpeed);
//        currentSpeed = Mathf.Lerp(currentSpeed, target, acceleration * Time.deltaTime);
//        if (currentSpeed < 0.05f) currentSpeed = 0f;

//        // Vertical movement
//        bool grounded = cc.isGrounded;
//        bool jumped = false;

//        if (swimming)
//        {
//            float targetY = -sinkSpeed;                       // sink slowly
//            if (k.spaceKey.isPressed)
//                targetY = depth > floatDepth ? swimUpSpeed : 0f;  // swim up, then float
//            velocity.y = Mathf.MoveTowards(velocity.y, targetY, 8f * Time.deltaTime);
//        }
//        else
//        {
//            if (grounded && velocity.y < 0) velocity.y = -2f;
//            if (grounded && k.spaceKey.wasPressedThisFrame)
//            {
//                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
//                jumped = true;
//            }
//            velocity.y += gravity * Time.deltaTime;
//        }

//        cc.Move((moveDir * currentSpeed + Vector3.up * velocity.y) * Time.deltaTime);

//        // Animation (legs keep moving in water)
=======
//        float target = hasInput ? (k.leftShiftKey.isPressed ? runSpeed : walkSpeed) : 0f;
//        currentSpeed = Mathf.Lerp(currentSpeed, target, acceleration * Time.deltaTime);
//        if (currentSpeed < 0.05f) currentSpeed = 0f;

//        bool grounded = cc.isGrounded;
//        bool jumped = false;
//        if (grounded && velocity.y < 0) velocity.y = -2f;
//        if (grounded && k.spaceKey.wasPressedThisFrame)
//        {
//            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
//            jumped = true;
//        }
//        velocity.y += gravity * Time.deltaTime;

//        cc.Move((moveDir * currentSpeed + Vector3.up * velocity.y) * Time.deltaTime);

>>>>>>> kalhara
//        if (anim != null)
//        {
//            if (hasSpeed) anim.SetFloat("Speed", currentSpeed);
//            if (hasMotion) anim.SetFloat("MotionSpeed", 1f);
<<<<<<< HEAD
//            if (hasGrounded) anim.SetBool("Grounded", swimming || grounded);
//            if (hasJump) anim.SetBool("Jump", !swimming && (jumped || !grounded));
=======
//            if (hasGrounded) anim.SetBool("Grounded", grounded);
//            if (hasJump) anim.SetBool("Jump", jumped || !grounded);
>>>>>>> kalhara
//            if (hasFreeFall) anim.SetBool("FreeFall", false);
//        }
//    }
//}
<<<<<<< HEAD

=======
>>>>>>> kalhara
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
<<<<<<< HEAD
    public float swimDepth = 0.6f;
    public float floatDepth = 1.0f;
=======
    public float swimDepth = 0.6f;   // water height above feet where swimming starts
    public float floatDepth = 1.0f;  // depth where you float when holding Space
>>>>>>> kalhara

    CharacterController cc;
    Animator anim;
    Transform cam;
<<<<<<< HEAD

    Vector3 velocity;
    Vector3 moveDir;

    float currentSpeed;

    readonly List<WaterZone> waters = new List<WaterZone>();
=======
    Vector3 velocity;
    Vector3 moveDir;
    float currentSpeed;
    readonly List<WaterZone> waters = new List<WaterZone>();
    bool hasSpeed, hasMotion, hasGrounded, hasJump, hasFreeFall;
>>>>>>> kalhara

    void Start()
    {
        cc = GetComponent<CharacterController>();
<<<<<<< HEAD

        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }

=======
        cam = Camera.main.transform;
>>>>>>> kalhara
        anim = GetComponentInChildren<Animator>();

        if (anim != null)
        {
            anim.applyRootMotion = false;
<<<<<<< HEAD
        }
        else
        {
            Debug.LogError("Animator not found on Player!");
=======
            foreach (var p in anim.parameters)
            {
                if (p.name == "Speed") hasSpeed = true;
                if (p.name == "MotionSpeed") hasMotion = true;
                if (p.name == "Grounded") hasGrounded = true;
                if (p.name == "Jump") hasJump = true;
                if (p.name == "FreeFall") hasFreeFall = true;
            }
>>>>>>> kalhara
        }
    }

    void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
        WaterZone water = other.GetComponentInParent<WaterZone>();

        if (water != null && !waters.Contains(water))
        {
            waters.Add(water);
        }
=======
        Debug.Log("Entered: " + other.name);
        var w = other.GetComponentInParent<WaterZone>();
        if (w != null && !waters.Contains(w)) waters.Add(w);
>>>>>>> kalhara
    }

    void OnTriggerExit(Collider other)
    {
<<<<<<< HEAD
        WaterZone water = other.GetComponentInParent<WaterZone>();

        if (water != null)
        {
            waters.Remove(water);
        }
=======
        var w = other.GetComponentInParent<WaterZone>();
        if (w != null) waters.Remove(w);
>>>>>>> kalhara
    }

    float WaterSurface()
    {
        float y = float.MinValue;
<<<<<<< HEAD

        foreach (WaterZone water in waters)
        {
            y = Mathf.Max(y, water.SurfaceY);
        }

=======
        foreach (var w in waters) y = Mathf.Max(y, w.SurfaceY);
>>>>>>> kalhara
        return y;
    }

    void Update()
    {
<<<<<<< HEAD
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

        // Get keyboard input
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

=======
        var k = Keyboard.current;
        if (k == null) return;

        // Water state
        float depth = waters.Count > 0 ? WaterSurface() - transform.position.y : 0f;
        bool swimming = waters.Count > 0 && depth > swimDepth;

        // Input
        float x = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
        float z = (k.wKey.isPressed ? 1 : 0) - (k.sKey.isPressed ? 1 : 0);

        Vector3 camF = cam.forward; camF.y = 0; camF.Normalize();
        Vector3 camR = cam.right; camR.y = 0; camR.Normalize();
        Vector3 input = camF * z + camR * x;
>>>>>>> kalhara
        bool hasInput = input.sqrMagnitude > 0.01f;

        if (hasInput)
        {
            moveDir = input.normalized;
<<<<<<< HEAD

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
            // Idle = 0
            // Walk = 0.5
            // Run = 1
            float groundAnimationSpeed = 0f;

            if (!swimming)
            {
                groundAnimationSpeed = Mathf.Clamp01(
                    currentSpeed / runSpeed
                );
            }

            anim.SetFloat("Speed", groundAnimationSpeed);

            // Water animation
            anim.SetBool("InWater", swimming);

            // 0 = Treading Water
            // 1 = Swimming
            float waterAnimationSpeed = 0f;

            if (swimming && hasInput)
            {
                waterAnimationSpeed = 1f;
            }

            anim.SetFloat("SwimSpeed", waterAnimationSpeed);
        }
    }
}
=======
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(moveDir),
                turnSpeed * Time.deltaTime);
        }

        // Horizontal speed
        float target = 0f;
        if (hasInput)
            target = swimming ? swimSpeed : (k.leftShiftKey.isPressed ? runSpeed : walkSpeed);
        currentSpeed = Mathf.Lerp(currentSpeed, target, acceleration * Time.deltaTime);
        if (currentSpeed < 0.05f) currentSpeed = 0f;

        // Vertical movement
        bool grounded = cc.isGrounded;
        bool jumped = false;

        if (swimming)
        {
            float targetY = -sinkSpeed;                       // sink slowly
            if (k.spaceKey.isPressed)
                targetY = depth > floatDepth ? swimUpSpeed : 0f;  // swim up, then float
            velocity.y = Mathf.MoveTowards(velocity.y, targetY, 8f * Time.deltaTime);
        }
        else
        {
            if (grounded && velocity.y < 0) velocity.y = -2f;
            if (grounded && k.spaceKey.wasPressedThisFrame)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                jumped = true;
            }
            velocity.y += gravity * Time.deltaTime;
        }

        cc.Move((moveDir * currentSpeed + Vector3.up * velocity.y) * Time.deltaTime);

        // Animation (legs keep moving in water)
        if (anim != null)
        {
            if (hasSpeed) anim.SetFloat("Speed", currentSpeed);
            if (hasMotion) anim.SetFloat("MotionSpeed", 1f);
            if (hasGrounded) anim.SetBool("Grounded", swimming || grounded);
            if (hasJump) anim.SetBool("Jump", !swimming && (jumped || !grounded));
            if (hasFreeFall) anim.SetBool("FreeFall", false);
        }
    }
}
>>>>>>> kalhara
