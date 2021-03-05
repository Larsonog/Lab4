using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (float).03);
        }
        transform.LookAt(player.transform);
    }
}
