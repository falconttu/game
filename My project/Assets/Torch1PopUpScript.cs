using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch1PopUpScript : MonoBehaviour
{

    public GameObject Torch1PopUp;
    public SphereCollider SphereCollider;


    void Update()
    {
        OnTriggerEnter(SphereCollider);
    }
    private void OnTriggerEnter(SphereCollider SphereCollider)
    {
        if (SphereCollider.isTrigger)
        {
            Torch1PopUp.SetActive(true);
        }

        else { Torch1PopUp.SetActive(false); }
    }

}
