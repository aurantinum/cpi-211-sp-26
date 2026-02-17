using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject lightBulb;
    [SerializeField] bool lightState = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))    
        {
            print("yup!");
            lightState = !lightState; //if it's true, become false, if it's false become true
        }

        if(lightState)
        {
            lightBulb.SetActive(true);
        }
        else
        {
            lightBulb.SetActive(false);
        }
    }
}
