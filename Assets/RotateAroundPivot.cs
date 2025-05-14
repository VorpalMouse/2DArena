using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPivot : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(pivot.transform.position, new Vector3(0,0,1), rotateSpeed*Time.deltaTime);
    }
}
