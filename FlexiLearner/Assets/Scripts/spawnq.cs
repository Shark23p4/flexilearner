using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class spawnq : MonoBehaviour
{
    int i = 0;
    public GameObject q;
    public GameObject spawn;
    float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown < 0 && i<70)
        {
            i += 1;
            cooldown = Random.Range(2f,10);
            int offset = Random.Range(-5, 5);
            float movespeed = Random.Range(2, 5);
            GameObject question = Instantiate(q, new Vector3(spawn.transform.position.x, offset, 800), Quaternion.identity, spawn.transform);
            question.GetComponent<Rigidbody2D>().velocity = Vector3.right * movespeed;
        }
    }
}
