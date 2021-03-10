using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int maxAmmo;
    public int currentAmmo;
    public int storedAmmo;

    public Image healthBar;
    public GameObject canvas;
    public GameObject events;
    public GameObject textbox;


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
        textbox.GetComponent<TextMeshProUGUI>().text = currentAmmo + "/6\n"+ storedAmmo;
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
        if (currentAmmo < maxAmmo)
        {
            if (storedAmmo >= maxAmmo)
            {
                storedAmmo -= maxAmmo - currentAmmo;
                currentAmmo = maxAmmo;
            }
            else
            {
                currentAmmo += storedAmmo;
                storedAmmo = 0;
            }
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
