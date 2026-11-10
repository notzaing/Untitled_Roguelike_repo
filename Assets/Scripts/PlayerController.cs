using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Character stats
    public float atk_pwr = 0;
    public float speed = 0;
    public float atk_spd = 0;
    public float crit_chance = 0;
    public float dmg_rd = 0;
    public float health = 0;
    //variables setup
    private string chr_class;
    private bool origin_stat;
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
        startTime = Time.time; // taken from slides
        origin_stat = true;
    }

    // Update is called once per frame
    void Update()
    {
        float playerMoveSpeed = force * speed;
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
        if (canDash)
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
        if(origin_stat)
        {
            if (chr_class == "Assassin")
            {
                speed *= 1.5f;
                atk_spd *= 1.5f;
                atk_pwr *= 0.5f;
                origin_stat = false;
            }
            if (chr_class == "Warrior")
            {
                atk_pwr *= 1.5f;
                dmg_rd *= 1.5f;
                speed *= 0.5f;
                atk_spd *= 0.5f;
                origin_stat = false;
            }
            if (chr_class == "Scholar")
            {
                health += 1f;
                crit_chance *= 1.5f;
                atk_pwr *= 0.5f;
                origin_stat = false;
            }
            if (chr_class == "Dead")
            {
                atk_pwr *= 0.5f;
                atk_spd *= 0.5f;
                dmg_rd *= 0.5f;
                speed *= 0.5f;
                crit_chance *= 0.5f;
                health -= 1f;
                origin_stat = false;
            }
            if (chr_class == "Regular")
            {
                origin_stat = false;
            }
        }
    }
}
