using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableEvent : MonoBehaviour {

    public GameObject particleEffect;

    //When gameobject is enables, create effect
    private void OnEnable () {
        if (particleEffect != null) {
            GameObject createdEffect = Instantiate(particleEffect, transform.position, particleEffect.transform.rotation);
            Destroy(createdEffect, createdEffect.GetComponent<ParticleSystem>().main.duration);
        }
    }
}
