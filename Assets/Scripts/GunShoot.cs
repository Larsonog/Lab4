using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    public InputAction shootButton;
    public InputAction reloadButton;



    // Start is called before the first frame update
    void Start()
    {
   
    }
    private void OnEnable()
    {
        shootButton.Enable();
        reloadButton.Enable();
    }
    private void OnDisable()
    {
        shootButton.Disable();
        reloadButton.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadButton.triggered)
        {
            Reload();
        }
        if (shootButton.ReadValueAsObject() != null)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot!");
    }

    void Reload()
    {
        Debug.Log("Reloading!");
    }
}
