using UnityEngine;
using System.Collections;

public class FreyaHealth : MonoBehaviour
{
   public int maxHealth = 100;
   public int currentHealth;

   public float invincibilityTimeAfterHit = 3f;
   public float invincibilityFlashDelay = 0.15f;
   public bool isInvincible = false;

   public SpriteRenderer graphics;
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

     public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {           
            currentHealth -= damage;
            HealthBar.SetHealth(currentHealth);  

            if(currentHealth <= 0)
            {
                Die();
                return;
            }          

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Death");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }

        
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
