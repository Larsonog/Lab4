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
            if (collider.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 5f)
            {
                health -= (int)collider.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
                if (tag.Equals("Player"))
                {
                    GameManager.Instance.setHealthBarValue((float)health / (float)100);
                }
            }
            else
            {
                if (tag.Equals("Player")){
                    GameManager.Instance.addStorage();
                }
            }
            Destroy(collider.gameObject);

            if (health <= 0)
            {
                if (tag.Equals("Enemy"))
                {
                    Destroy(gameObject);
                }
            }
        }
        if (collider.gameObject.CompareTag("Triggerdoor"))
        {
            GameObject.Find("TrapTriggerWalls").SetActive(false);
        }
    }
}
