using UnityEngine;

public class TranslateMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = speed * Time.deltaTime;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, 0);
        transform.Translate(move);
        
        
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed, 0, 0);
        }*/
    }
}
