using UnityEngine;
using System.Collections;

public class InputBehaviour : MonoBehaviour {

    private static bool mouseLeft;
    public static bool MouseLeft
    {
        get { return mouseLeft; }
    }

    private static bool mouseRight;
    public static bool MouseRight
    {
        get { return mouseRight; }
    }

    private static Vector2 mousePosition;
    public static Vector2 MousePosition
    {
        get { return mousePosition; }
    }

    private KeyCode mouse_left;
    private KeyCode mouse_right;

    private void Update()
    {
        mouse_left = KeyCode.Mouse0;
        mouse_right = KeyCode.Mouse1;

        mouseLeft = Input.GetKeyDown(mouse_left);
        mouseRight = Input.GetKeyDown(mouse_right);

        mousePosition = Input.mousePosition;
    }
}
