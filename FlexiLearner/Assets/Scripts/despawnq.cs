using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnq : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Console.WriteLine("b");
        if (collision.gameObject.tag == "Finish")
            Destroy(GetComponent<GameObject>());
    }
}
