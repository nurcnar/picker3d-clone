using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x-18,target.transform.position.y+18,target.transform.position.z-2.8f);
        //transform.rotation = Quaternion.Euler(15,90,0);
    }
}
