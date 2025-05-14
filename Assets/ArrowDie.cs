using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(arrowDies()); 
    }

    IEnumerator arrowDies()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
