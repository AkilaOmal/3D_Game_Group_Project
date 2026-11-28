//using UnityEngine;
//using UnityEngine.InputSystem;

//public class CursorLock : MonoBehaviour
//{
//    void Start()
//    {
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
//    }

//    void Update()
//    {
//        var k = Keyboard.current;
//        if (k != null && k.escapeKey.wasPressedThisFrame)
//        {
//            Cursor.lockState = CursorLockMode.None;
//            Cursor.visible = true;
//        }
//    }
//}

using UnityEngine;
using UnityEngine.InputSystem;

public class CursorLock : MonoBehaviour
{
    bool hidden;

    void Start()
    {
        Apply(true);
    }

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        // Esc or Tab = show/hide the cursor
        if (k.escapeKey.wasPressedThisFrame || k.tabKey.wasPressedThisFrame)
            Apply(!hidden);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Apply(bool hide)
    {
        hidden = hide;
        Cursor.visible = !hide;
#if UNITY_EDITOR
        Cursor.lockState = CursorLockMode.None;   // editor: never lock, so buttons stay clickable
#else
        Cursor.lockState = hide ? CursorLockMode.Locked : CursorLockMode.None;
#endif
    }
}