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
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    private void OnTriggerStay(Collider Collider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ParticleSystem.Play();
            PointLight.enabled = true;
            AudioSource.Play();
        }
    }
}