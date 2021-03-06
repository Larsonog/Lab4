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
        transform.LookAt(player.transform);
        if (count > 150)  
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 15)
            {
                if (ammo > 0)
                {
                    GetComponent<ParticleSystem>().Play(true);
                    var newBullet = Instantiate(marble, new Vector3(marble.transform.position.x, marble.transform.position.y, marble.transform.position.z), Quaternion.identity);
                    newBullet.SetActive(true);
                    newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 600f);
                    ammo--;
                    count = 0;
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
