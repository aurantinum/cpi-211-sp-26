using UnityEngine;

public class betterLightSwitch : MonoBehaviour
{
    private Light light;
    private float origIntensity;
    private float origRange;
    private Color origColor;

    [SerializeField] private bool lightState = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        origIntensity = light.intensity;
        origRange = light.range;
        origColor = light.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            lightState = !lightState;
        }

        if(lightState)
        {
            //light.intensity = origIntensity;
            light.color = origColor;
            //light.range = origRange;
            //light.enabled = true;
        }
        else
        {
            //light.intensity = 0;
            light.color = Color.black;
            //light.range = 0;
            //light.enabled = false;
        }
    }
}
