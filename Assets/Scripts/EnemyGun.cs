using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public GameObject marble;
    public GameObject player;
    private int ammo = 6;
    private int count = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count % 300 == 0)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 15)
            {
                if (ammo > 0)
                {
                    var newBullet = Instantiate(marble, new Vector3(marble.transform.position.x, marble.transform.position.y, marble.transform.position.z), Quaternion.identity);
                    newBullet.SetActive(true);
                    newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 600f);
                    ammo--;
                }
                else
                {
                    ammo = 6;
                }
            }
        }
        count++;
    }
}
