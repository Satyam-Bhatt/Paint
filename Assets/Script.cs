using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    private GameObject meshes;

    private void Awake()
    {
        meshes = GameObject.Find("Meshes");
    }

    // Start is called before the first frame update
    void Start()
    {
       
        transform.SetParent(meshes.transform);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
