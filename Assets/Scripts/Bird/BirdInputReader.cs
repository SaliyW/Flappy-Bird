using UnityEngine;

public class BirdInputReader : MonoBehaviour
{
    public bool IsJumpKeyDown()
    {
        KeyCode jump = KeyCode.Space;

        return Input.GetKeyDown(jump);
    }
}
