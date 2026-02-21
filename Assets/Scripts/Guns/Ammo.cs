using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 3f;
    [SerializeField] private int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Object.Destroy(gameObject, lifeSpan); //que this object up to die
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDamage(int damage)
    {
        this.damage = damage; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.TryGetComponent<Health>(out var otherHealth))
        {
            otherHealth.TakeDamage(damage);
            Object.Destroy(gameObject);
        }
    }

}
