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
    public AudioSource AudioSource;

    public bool InCollider = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Do something when triggered
        OnCollisionEnter(SphereCollider);
    }

    private void OnCollisionEnter(SphereCollider sphereCollider)
    {
        if (sphereCollider.gameObject.tag == "Player")
        {
            InCollider = true;

            if (InCollider == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ParticleSystem.Play();
                    PointLight.enabled = true;
                    AudioSource.Play();
                }

            }
        }
    }
}