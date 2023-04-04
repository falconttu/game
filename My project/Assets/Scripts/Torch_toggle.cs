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

    bool Player_in_Range;

    void Start()
    {
        Player_in_Range = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_in_Range)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ParticleSystem.Play();
                PointLight.enabled = true;
                AudioSource.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider Collider)
    {
        Player_in_Range = true;
    }

    private void OnTriggerStay(Collider Collider)
    {
        Player_in_Range = true;
    }

    private void OnTriggerExit(Collider Collider)
    {
        Player_in_Range = false;
    }
}