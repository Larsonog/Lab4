using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject ammoBox;
    public GameObject crossHair;

    public GameObject backgroundCanvas;




    public TextMeshProUGUI titleText;
    public GameObject startButton;
    public GameObject creditsButton;
    public GameObject creditsText;
    public GameObject creditsBackButton;
    private bool shouldLockCamera = false;
    public GameObject howtoplayButton;
    public GameObject playText;
    public GameObject playBackButton;

    public GameObject winText;
    public GameObject winBackButton;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(backgroundCanvas);
            DontDestroyOnLoad(events);
        }
        else
        {
            Destroy(gameObject);
            Destroy(canvas);
            Destroy(events);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        storedAmmo = 18;
        setHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        ammoBox.GetComponent<TextMeshProUGUI>().text = currentAmmo + "/6\n"+ storedAmmo;
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
        if (value <= 0)
        {
            UnlockCamera();
            disableGunUI();
            enableStartUI();
            setHealthBarValue(1);
            currentAmmo = 6;
            storedAmmo = 18;
            StartCoroutine(LoadYourAsyncScene("MainMenu"));
        }
    }

    public void addStorage()
    {
        Debug.Log(storedAmmo);
        storedAmmo++;
    }

    private void enableGunUI()
    {
        crossHair.SetActive(true);
        ammoBox.SetActive(true);
        healthBar.gameObject.SetActive(true);

    }
    private void disableGunUI()
    {
        crossHair.SetActive(false);
        ammoBox.SetActive(false);
        healthBar.gameObject.SetActive(false);
    }

    private void disableStartUI()
    {
        titleText.gameObject.SetActive(false);
        startButton.SetActive(false);
        creditsButton.SetActive(false);
        howtoplayButton.SetActive(false);

    }
    private void enableStartUI()
    {
        titleText.gameObject.SetActive(true);
        startButton.SetActive(true);
        creditsButton.SetActive(true);
        howtoplayButton.SetActive(true);
        backgroundCanvas.SetActive(true);

    }
    IEnumerator LoadYourAsyncScene(string scene)
    {

        Debug.Log("Loading " + scene);
        if (scene == "MainMenu")
        {
            Start();
            
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }
    public void StartButton()
    {
        disableStartUI();
        enableGunUI();
        backgroundCanvas.SetActive(false);
        shouldLockCamera = true;
        StartCoroutine(LoadYourAsyncScene("Level"));


    }

    public void CreditsButton()
    {
        disableStartUI();
        creditsText.SetActive(true);
        creditsBackButton.SetActive(true);
    }
    public void HowToPlayButton()
    {
        disableStartUI();
        playText.SetActive(true);
        playBackButton.SetActive(true);
    }
    public void exitCredits()
    {
        creditsText.SetActive(false);
        creditsBackButton.SetActive(false);
        enableStartUI();
    }
    public void exithowto()
    {
        playText.SetActive(false);
        playBackButton.SetActive(false);
        enableStartUI();

    }
    public bool ShouldLockCamera()
    {
        return shouldLockCamera;
    }
    public void UnlockCamera()
    {
        shouldLockCamera = false;
        Cursor.lockState = CursorLockMode.None;

    }
    public void WinGame()
    {
        Debug.Log("Destorying!");
        disableGunUI();
        UnlockCamera();
        backgroundCanvas.SetActive(true);
        winText.SetActive(true);
        winBackButton.SetActive(true);

    }
    public void WinBackButton()
    {
        winText.SetActive(false);
        winBackButton.SetActive(false);
        enableStartUI();
        StartCoroutine(LoadYourAsyncScene("MainMenu"));


    }
}
