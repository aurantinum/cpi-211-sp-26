using UnityEngine;

public class BasicCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target.position; //might need to reverse that
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
