//using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
//public class PlayerMovement : MonoBehaviour
//{
//    public float walkSpeed = 3f;
//    public float runSpeed = 6f;
//    public float acceleration = 10f;
//    public float turnSpeed = 720f;
//    public float jumpHeight = 1.2f;
//    public float gravity = -20f;

//    CharacterController cc;
//    Animator anim;
//    Transform cam;
//    Vector3 velocity;
//    Vector3 moveDir;
//    float currentSpeed;
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

//    void Update()
//    {
//        var k = Keyboard.current;
//        if (k == null) return;

//        float x = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
//        float z = (k.wKey.isPressed ? 1 : 0) - (k.sKey.isPressed ? 1 : 0);

//        Vector3 camF = cam.forward; camF.y = 0; camF.Normalize();
//        Vector3 camR = cam.right; camR.y = 0; camR.Normalize();
//        Vector3 input = (camF * z + camR * x);
//        bool hasInput = input.sqrMagnitude > 0.01f;

//        if (hasInput)
//        {
//            moveDir = input.normalized;
//            transform.rotation = Quaternion.RotateTowards(
//                transform.rotation,
//                Quaternion.LookRotation(moveDir),
//                turnSpeed * Time.deltaTime);
//        }

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

//        if (anim != null)
//        {
//            if (hasSpeed) anim.SetFloat("Speed", currentSpeed);
//            if (hasMotion) anim.SetFloat("MotionSpeed", 1f);
//            if (hasGrounded) anim.SetBool("Grounded", grounded);
//            if (hasJump) anim.SetBool("Jump", jumped || !grounded);
//            if (hasFreeFall) anim.SetBool("FreeFall", false);
//        }
//    }
//}
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
    public float swimDepth = 0.6f;   // water height above feet where swimming starts
    public float floatDepth = 1.0f;  // depth where you float when holding Space

    CharacterController cc;
    Animator anim;
    Transform cam;
    Vector3 velocity;
    Vector3 moveDir;
    float currentSpeed;
    readonly List<WaterZone> waters = new List<WaterZone>();
    bool hasSpeed, hasMotion, hasGrounded, hasJump, hasFreeFall;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        anim = GetComponentInChildren<Animator>();

        if (anim != null)
        {
            anim.applyRootMotion = false;
            foreach (var p in anim.parameters)
            {
                if (p.name == "Speed") hasSpeed = true;
                if (p.name == "MotionSpeed") hasMotion = true;
                if (p.name == "Grounded") hasGrounded = true;
                if (p.name == "Jump") hasJump = true;
                if (p.name == "FreeFall") hasFreeFall = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered: " + other.name);
        var w = other.GetComponentInParent<WaterZone>();
        if (w != null && !waters.Contains(w)) waters.Add(w);
    }

    void OnTriggerExit(Collider other)
    {
        var w = other.GetComponentInParent<WaterZone>();
        if (w != null) waters.Remove(w);
    }

    float WaterSurface()
    {
        float y = float.MinValue;
        foreach (var w in waters) y = Mathf.Max(y, w.SurfaceY);
        return y;
    }

    void Update()
    {
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
        bool hasInput = input.sqrMagnitude > 0.01f;

        if (hasInput)
        {
            moveDir = input.normalized;
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