using UnityEngine;

public class KillVolume : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       Object.Destroy(collision.gameObject); //destroy any game object that comes in contact with the kill volume
    }
}
