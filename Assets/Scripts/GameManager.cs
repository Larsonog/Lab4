using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxAmmo=10;
    public int currentAmmo=10;

    public object Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanShoot()
    {
        return currentAmmo > 0;
    }
    public void RemoveAmmo()
    {
        if (CanShoot())
        {
            currentAmmo--;
        }
    }
    public void ResetAmmo()
    {
        currentAmmo = maxAmmo;
    }
}