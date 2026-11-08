using UnityEngine;

public class Player_Attributes : MonoBehaviour
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origin_stat = true;
    }

    // Update is called once per frame
    void Update()
    {
        while(origin_stat)
        {
            if (chr_class == "Assassin")
            {
                speed *= 1.5f;
                atk_spd *= 1.5f;
                atk_pwr *= 0.5f;
            }
            if(chr_class == "Warrior")
            {
                atk_pwr *= 1.5f;
                dmg_rd *= 1.5f;
                speed *= 0.5f;
                atk_spd *= 0.5f;
            }
            if (chr_class == "Scholar")
            {
                health += 1f;
                crit_chance *= 1.5f;
                atk_pwr *= 0.5f;
            }
            if(chr_class == "Dead")
            {
                atk_pwr *= 0.5f;
                atk_spd *= 0.5f;
                dmg_rd *= 0.5f;
                speed *= 0.5f;
                crit_chance *= 0.5f;
                health -= 1f;
            }
        }
       
    }
}
