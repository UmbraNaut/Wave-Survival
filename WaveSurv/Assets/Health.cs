using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Slider healthBar;
    private float decrement = 0.0f;
    private bool isin = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.minValue = 0;
        healthBar.value = currentHealth;
    }
    void Update()
    { 
        if (currentHealth < healthBar.value)
        {
            healthBar.value = healthBar.value - decrement;
            healthBar.value -= Time.deltaTime;
        }
        if (currentHealth - (decrement + 0.01f) > healthBar.value)
        {
            healthBar.value = healthBar.value - decrement;
            healthBar.value -= Time.deltaTime;
        }
        if (isin)
        {
            TakeDamage(Time.deltaTime * 5);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        decrement = (healthBar.value - currentHealth)/40;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Sent"))// Check if the object has the "Player" tag
            {
            TakeDamage(10);
            }
            if (other.CompareTag("Healer"))
            {
            TakeDamage(-5);
            }
            if (other.CompareTag("E1"))
            {
              TakeDamage(5);
            }
            if (other.CompareTag("E2"))
            {
              TakeDamage(10);
            }
            if (other.CompareTag("Lava"))
            {
              TakeDamage(1);
            }
            if (other.CompareTag("EB"))
            {
            TakeDamage(5);
            }
            if (other.CompareTag("Lava"))
            {
            isin = true;
            }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            isin = false;
        }
    }
}
