using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    public InputAction shootButton;
    public InputAction reloadButton;
    public GameObject bullet;
    public float shootDelay = 4.0f;



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
        if (shootButton.triggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (GameManager.Instance.CanShoot())
        {
            Debug.Log("Shoot!");
            var newBullet = Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            newBullet.SetActive(true);
            GameManager.Instance.RemoveAmmo();
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }

    void Reload()
    {
        Debug.Log("Reloading!");
        GameManager.Instance.ResetAmmo();
    }
}
