using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public float force = 0.01f;
    public float dashForce = 0.1f;
    public float duration = 1f;
    public Color canDashColour = Color.green;
    public Color noDashColour = Color.blue;
    private float startTime; // taken from slides


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
        startTime  = Time.time; // taken from slides
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime; // taken from slides
        bool canDash = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (elapsedTime >= duration & canDash == false)
        {
            canDash = true;
        }
        bool dash = Input.GetKey(KeyCode.Space);
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
        if(canDash)
        {
            spriteRenderer.color = canDashColour;
        }
        if (dash & canDash)
        {
            Vector2 position = (Vector2)transform.position + move * dashForce;
            transform.position = position;
            startTime = Time.time;
            canDash = false;
            spriteRenderer.color = noDashColour;
        }
        else
        {
            Vector2 position = (Vector2)transform.position + move * force;
            transform.position = position;
        }

    }
}

