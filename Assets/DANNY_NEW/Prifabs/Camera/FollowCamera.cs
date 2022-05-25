using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float smooth = 5.0f;
    public Vector3 offset = new Vector3(0, 2, -5);
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, target.position.z + -5), Time.deltaTime * smooth);
    }
}
