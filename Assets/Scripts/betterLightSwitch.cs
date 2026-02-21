using UnityEngine;

public class betterLightSwitch : MonoBehaviour
{
    private Light sourceLight;
    private float origIntensity;
    private float origRange;
    private Color origColor;

    [SerializeField] private bool lightState = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sourceLight = GetComponent<Light>();
        origIntensity = sourceLight.intensity;
        origRange = sourceLight.range;
        origColor = sourceLight.color;
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
            sourceLight.color = origColor;
            //light.range = origRange;
            //light.enabled = true;
        }
        else
        {
            //light.intensity = 0;
            sourceLight.color = Color.black;
            //light.range = 0;
            //light.enabled = false;
        }
    }
}
