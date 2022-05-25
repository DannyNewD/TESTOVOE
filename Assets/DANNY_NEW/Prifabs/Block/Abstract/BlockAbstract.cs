using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockAbstract : MonoBehaviour
{ 
    [SerializeField] public CameraManager.CameraPositionState cameraPositionState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerLogick>() != null) 
        {
            OnTrigerCamera();
        }
    }
    public void OnTrigerCamera() 
    {
        CameraManager.instance.cameraPositionState = cameraPositionState;
    }
}
