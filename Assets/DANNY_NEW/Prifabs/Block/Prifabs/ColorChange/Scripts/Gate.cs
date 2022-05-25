using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] int indexGate;
    [SerializeField] BlockColorSwitch colorSwitch;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            colorSwitch.SetColorPlayr(indexGate);
        }
    }
}
