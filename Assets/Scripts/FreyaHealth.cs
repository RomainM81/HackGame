using UnityEngine;

public class FreyaHealth : MonoBehaviour
{
   public int maxHealth = 100;
   public int currentHealth;

   public HealthBar HealthBar;

    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)) {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
    }
}
