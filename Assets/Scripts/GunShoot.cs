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
    public float bulletForce = 10f;


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
            Debug.Log(shootButton.ReadValueAsObject());
            Shoot();
        }
    }

    void Shoot()
    {
        if (GameManager.Instance.CanShoot())
        {
            Debug.Log("Shoot!");
            GetComponent<ParticleSystem>().Play(true);
            var newBullet = Instantiate(bullet, new Vector3(bullet.transform.position.x, bullet.transform.position.y, bullet.transform.position.z), Quaternion.identity);
            newBullet.SetActive(true);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
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
