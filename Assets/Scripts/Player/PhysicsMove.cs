using UnityEngine;

public class PhysicsMove : MonoBehaviour
{
    [SerializeField] private float pushForce = 5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float jumpPower = 10f;
    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = new Vector3(Input.GetAxis("Horizontal") * pushForce, 0, Input.GetAxis("Vertical") * pushForce);
        body.AddForce(force);

        //body.linearVelocity = Vector3.ClampMagnitude(body.linearVelocity, maxSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            body.AddForce(new Vector3(0f,jumpPower,0f), ForceMode.Impulse);
        }
    }
}
