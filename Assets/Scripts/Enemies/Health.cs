using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 5f;
    [SerializeField] float currentHealth;
    public float health { get { return currentHealth; } private set { currentHealth = value; }   }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float healthLost) 
    {
        FindFirstObjectByType<ReticleController>().PlayerDealtDamage();
        currentHealth -= healthLost;
        if(currentHealth <= 0)
        {
            Destroy(gameObject); //add a method for dying
        }
    }
}
