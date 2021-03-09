using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    public float lifeTime;
    bool rolling = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        if((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) && ! rolling)
        {
            Destroy(gameObject);
        }
        else
        {
            rolling = true;
        }
    }
}
