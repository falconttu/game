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

    void Start()
    {
        SphereCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(SphereCollider.isTrigger)
       {
            Debug.Log("Player is in range of torch");
            if (Input.GetKeyDown(KeyCode.E))
            {
                ParticleSystem.Play();
                PointLight.enabled = true;
                AudioSource.Play();
            }

       }
    }

    private void OnTriggerEnter(Collider SphereCollider)
    {
            SphereCollider.isTrigger = true;
    }
}