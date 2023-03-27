using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Torch_toggle : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem ParticleSystem;
    public SphereCollider SphereCollider;
    public Light PointLight;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SphereCollider.isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ParticleSystem.Play();
                PointLight.enabled = true;
            }
        }
    }

}
