using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Marble"))
        {
            if (collider.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1f)
            {
                health -= (int)collider.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
                if (tag.Equals("Player"))
                {
                    GameManager.Instance.setHealthBarValue((float)health / (float)100);
                }
            }
        }
    }
}
