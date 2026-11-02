//using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
//public class PlayerMovement : MonoBehaviour
//{
//    public float speed = 5f;
//    public float runSpeed = 8f;
//    public float jumpHeight = 1.5f;
//    public float gravity = -20f;
//    public float turnSpeed = 10f;

//    CharacterController cc;
//    Vector3 velocity;
//    Transform cam;

//    void Start()
//    {
//        cc = GetComponent<CharacterController>();
//        cam = Camera.main.transform;
//    }

//    void Update()
//    {
//        var k = Keyboard.current;
//        if (k == null) return;

//        float x = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
//        float z = (k.wKey.isPressed ? 1 : 0) - (k.sKey.isPressed ? 1 : 0);

//        Vector3 camF = cam.forward; camF.y = 0; camF.Normalize();
//        Vector3 camR = cam.right; camR.y = 0; camR.Normalize();
//        Vector3 move = (camF * z + camR * x).normalized;

//        float s = k.leftShiftKey.isPressed ? runSpeed : speed;

//        //if (move.sqrMagnitude > 0.01f)
//        //    transform.rotation = Quaternion.Slerp(
//        //        transform.rotation,
//        //        Quaternion.LookRotation(move),
//        //        turnSpeed * Time.deltaTime);
//        if (move.sqrMagnitude > 0.01f)
//            transform.rotation = Quaternion.RotateTowards(
//                transform.rotation,
//                Quaternion.LookRotation(move),
//                turnSpeed * Time.deltaTime);

//        if (cc.isGrounded && velocity.y < 0) velocity.y = -2f;
//        if (cc.isGrounded && k.spaceKey.wasPressedThisFrame)
//            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
//        velocity.y += gravity * Time.deltaTime;

//        //cc.Move((move * s + Vector3.up * velocity.y) * Time.deltaTime);
//        float facing = move.sqrMagnitude > 0.01f
//    ? Mathf.Clamp01(Vector3.Dot(transform.forward, move))
//    : 0f;
//cc.Move((move * s * Mathf.Max(0.3f, facing) + Vector3.up * velocity.y) * Time.deltaTime);
//    }
//}
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float acceleration = 10f;
    public float turnSpeed = 720f;
    public float jumpHeight = 1.2f;
    public float gravity = -20f;

    CharacterController cc;
    Animator anim;
    Transform cam;
    Vector3 velocity;
    Vector3 moveDir;
    float currentSpeed;
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

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        float x = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
        float z = (k.wKey.isPressed ? 1 : 0) - (k.sKey.isPressed ? 1 : 0);

        Vector3 camF = cam.forward; camF.y = 0; camF.Normalize();
        Vector3 camR = cam.right; camR.y = 0; camR.Normalize();
        Vector3 input = (camF * z + camR * x);
        bool hasInput = input.sqrMagnitude > 0.01f;

        if (hasInput)
        {
            moveDir = input.normalized;
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(moveDir),
                turnSpeed * Time.deltaTime);
        }

        float target = hasInput ? (k.leftShiftKey.isPressed ? runSpeed : walkSpeed) : 0f;
        currentSpeed = Mathf.Lerp(currentSpeed, target, acceleration * Time.deltaTime);
        if (currentSpeed < 0.05f) currentSpeed = 0f;

        bool grounded = cc.isGrounded;
        bool jumped = false;
        if (grounded && velocity.y < 0) velocity.y = -2f;
        if (grounded && k.spaceKey.wasPressedThisFrame)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumped = true;
        }
        velocity.y += gravity * Time.deltaTime;

        cc.Move((moveDir * currentSpeed + Vector3.up * velocity.y) * Time.deltaTime);

        if (anim != null)
        {
            if (hasSpeed) anim.SetFloat("Speed", currentSpeed);
            if (hasMotion) anim.SetFloat("MotionSpeed", 1f);
            if (hasGrounded) anim.SetBool("Grounded", grounded);
            if (hasJump) anim.SetBool("Jump", jumped || !grounded);
            if (hasFreeFall) anim.SetBool("FreeFall", false);
        }
    }
}