using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ston : MonoBehaviour
{
    public int Health;
    private float lasthealTime;
    public int SwordDamage;

    public HealthBar healthBar;
    public int maxHealth = 100;


    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage()
    {
        if (Health < 0) return;
        Health-= SwordDamage;
        healthBar.SetHealth(Health);
        lasthealTime = Time.time + 2;
        if (Health <= 0)
        {
            Destroy(gameObject);
            
             JoystickController.OnwinGame.Invoke();
            
        }
       
    }
    public void Update()
    {
        if (Health >= 5) return;
        if (lasthealTime < Time.time)
        {
            Health++;
            lasthealTime = Time.time + 2;
        }
        
    }





}
