using System.Collections;
using UnityEngine;

public class ReticleController : MonoBehaviour
{
    [SerializeField] GameObject baseReticle;
    [SerializeField] GameObject damageReticle;
    [SerializeField] float hitmarkerFlashTime = 0.1f;

    public void PlayerDealtDamage()
    {
        StartCoroutine(nameof(FlashDamageReticle));
    }

    IEnumerator FlashDamageReticle()
    {
        baseReticle.SetActive(false);
        damageReticle.SetActive(true);
        yield return new WaitForSeconds(hitmarkerFlashTime);
        baseReticle.SetActive(true);
        damageReticle.SetActive(false);
    }
}
