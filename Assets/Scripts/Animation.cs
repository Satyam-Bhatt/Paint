using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{   
    private float x = 0;

    // Update is called once per frame
    void Update()
    {
        if(x <= 360)
        {
            
            transform.localScale = gameObject.transform.localScale + new Vector3(Mathf.Sin(Mathf.Deg2Rad * x) * 0.01f, Mathf.Cos(Mathf.Deg2Rad * x) * 0.006f, 0);
            x = (x + 0.5f);

        }

        
        if(x > 360)
        {
            x = 0;
        }

    }
}
