using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.VirtualTexturing;

public class Torch_toggle : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem ParticleSystem;
    public Collider Collider;
    public Light PointLight;
    public AudioSource AudioSource;

    bool Player_in_Range;
    bool Torch_on;

    void Start()
    {
        Player_in_Range = false;
        Torch_on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_in_Range)
        {
           if (Torch_on == false)
           {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    UnityEngine.Debug.Log("E pressed");
                    ParticleSystem.Play();
                    PointLight.enabled = true;
                    AudioSource.Play();
                    Torch_on = true;
                }
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