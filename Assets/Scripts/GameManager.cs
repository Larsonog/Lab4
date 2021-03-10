using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int maxAmmo=10;
    public int currentAmmo=10;
    public int storedAmmo = 0;

    public Image healthBar;


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
        currentAmmo = maxAmmo;
        setHealthBarValue(1);
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
    {   if (storedAmmo > 9)
        {
            currentAmmo = maxAmmo;
            storedAmmo -= maxAmmo;
        }
        else
        {
            currentAmmo += storedAmmo;
            storedAmmo = 0;
        }
    }

    public void setHealthBarValue(float value)
    {
        healthBar.fillAmount=value;
        if (healthBar.fillAmount < .25f)
        {
            healthBar.color = Color.red;
        }
        else if (healthBar.fillAmount < .5f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.green;
        }
    }

    public void addStorage()
    {
        Debug.Log(storedAmmo);
        storedAmmo++;
    }
}
