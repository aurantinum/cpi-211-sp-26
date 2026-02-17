using UnityEngine;

public class BaseHitScanGun : MonoBehaviour
{
    [SerializeField] private Transform gunBarrel;
    [SerializeField] private float shotDelay = 0.5f;
    [SerializeField] private bool fullAuto = true;
    [SerializeField] private int damage = 1;
    private bool canShoot = true;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer > shotDelay)
            {
                canShoot = true;
                timer = 0;
            }
        }

        //the actual shot
        if ((canShoot) && (fullAuto ? Input.GetButton("Fire2") : Input.GetButtonDown("Fire2")))
        {
            canShoot = false;
            Ray shotRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0, 0.5f));
            RaycastHit hit;

            if(Physics.Raycast(shotRay, out hit))
            {
                print("HIT SOMETHING! " + hit.collider.gameObject.name);
            }

        }
    }
}
