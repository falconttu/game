using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
public class Torch_toggle : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem ParticleSystem;
    public Collider Collider;
    public Light PointLight;
    public AudioSource AudioSource;

    void Start()
    {
        Collider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Collider.isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ParticleSystem.Play();
                PointLight.enabled = true;
                AudioSource.Play();
            }
        }
        
    }

    private void OnTriggerStay(Collider Collider)
    {
        Collider.isTrigger = true;
    }
}