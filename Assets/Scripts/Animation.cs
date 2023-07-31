using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{   
    private int x = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
   
        transform.localScale = gameObject.transform.localScale + new Vector3(Mathf.Sin(x * Mathf.Deg2Rad), Mathf.Sin((x*2) * Mathf.Deg2Rad), 0);

        x++;

    }
}
