using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    //public InputAction Dash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
        //Dash.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        bool dash = Input.GetKey(KeyCode.Space);
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
        if (dash)
        {
            Vector2 position = (Vector2)transform.position + move * 0.1f;
            transform.position = position;
        }
        else
        {
            Vector2 position = (Vector2)transform.position + move * 0.01f;
            transform.position = position;
        }
    }
}
