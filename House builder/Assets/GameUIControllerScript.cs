using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIControllerScript : MonoBehaviour
{
    [Header("Kintamieji")]

    public AudioSource GameMusic;
    public AudioSource Click;
    public AudioSource Deleting;

    public bool soundIsMuted = false;
    public bool deletingModeOn = false;

    public GameObject deletingUI;

    public Button MuteButton;

    public Sprite Muted;
    public Sprite Unmuted;

    [Space]

    public GameObject SelectBath;
    public GameObject SelectKitchen;
    public GameObject SelectLiving;
    public GameObject SelectSleeping;
    public GameObject SelectStorage;
    public GameObject SelectGarage;

    [Space]

    public GameObject BathObjArray;
    public GameObject KitchenObjArray;
    public GameObject LivingObjArray;
    public GameObject SleeppingObjArray;
    public GameObject StorageObjArray;
    public GameObject GarageObjArray;

    [Space]

    public GameObject DeleteWindow;
    public bool deleteModeOn = false;

    [Space]

    public GameObject InfoWindow;
    public GameObject infoImage;
    public Text safetyInfo;
    public Text qualityInfo;

    [Space]

    public bool gameIsPaused = false;
    public bool gameStarted = false;
    public bool gameFinished = false;

    // use inspector to change time
    public float timeLeft = 60.0f;

    public float infoTimer = 5.0f;

    [Space]

    public GameObject PauseMenu;
    public GameObject ClientMission;
    public GameObject EndScreen;

    [Space]

    public Text EndText;

    public Text Timer;
    public Text Money;

    //--------------------------------------------------------------------------------------------------------------------------------
    //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //--------------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        // Set all level values time, money, needs

        GameMusic.Play();
        ClientMission.SetActive(true);

        UnPauseGame();
        EndScreen.SetActive(false);
    }

    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        if (gameStarted == true && !gameIsPaused && !gameFinished)
        {

            timeLeft -= Time.deltaTime;

            Timer.text = timeLeft.ToString("0.00");

            if (timeLeft < 0)
            {
                EndGame("time");
            }

            if (infoTimer > 0)
            {
                infoTimer -= Time.deltaTime;

                if (infoTimer < 0)
                {
                    InfoWindow.SetActive(false);
                }
            }
        }
    }

    //--------------------------------------

    public void CheckInput()
    {
        // Start game button SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartLevel();
        }

        // Muting sounds button M
        if (Input.GetKeyDown(KeyCode.M))
        {
            MuteMusic();
        }

        if (gameStarted)
        {
            // Pause game button ESCAPE
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    UnPauseGame();
                }
                else
                {
                    PauseGame();
                }
            }

            if (!gameIsPaused && !gameFinished)
            {
                // Changing button <-- , -->
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    
                }
            }
        }
    }

//--------------------------------------

    public void StartLevel()
    {
        Click.Play();
        ClientMission.SetActive(false);

        gameStarted = true;
    }

    public void EndGame(string end)
    {
        EndScreen.SetActive(true);
        gameFinished = true;

        if (end == "time")
        {
            EndText.text = "Time's up!";
        }
    }

    //---------------------------- 

    public void Construction()
    {
        if (deleteModeOn)
        {
            deleteModeOn = false;
            DeleteWindow.SetActive(false);
        }
        else
        {
            deleteModeOn = true;
            DeleteWindow.SetActive(true);
        }
    }

    //----------------------------    

    public void ChooseCategory(string category)
    {
        if (category == "Bathroom")
        {
            SelectBath.SetActive(true);

            SelectKitchen.SetActive(false);
            SelectLiving.SetActive(false);
            SelectSleeping.SetActive(false);
            SelectStorage.SetActive(false);
            SelectGarage.SetActive(false);

            BathObjArray.SetActive(true);

            KitchenObjArray.SetActive(false);
            LivingObjArray.SetActive(false);
            SleeppingObjArray.SetActive(false);
            StorageObjArray.SetActive(false);
            GarageObjArray.SetActive(false);
        }
        else if (category == "Kitchen")
        {
            SelectKitchen.SetActive(true);

            SelectBath.SetActive(false);
            SelectLiving.SetActive(false);
            SelectSleeping.SetActive(false);
            SelectStorage.SetActive(false);
            SelectGarage.SetActive(false);

            KitchenObjArray.SetActive(true);

            BathObjArray.SetActive(false);
            LivingObjArray.SetActive(false);
            SleeppingObjArray.SetActive(false);
            StorageObjArray.SetActive(false);
            GarageObjArray.SetActive(false);
        }
        else if (category == "Livingroom")
        {
            SelectLiving.SetActive(true);

            SelectBath.SetActive(false);
            SelectKitchen.SetActive(false);
            SelectSleeping.SetActive(false);
            SelectStorage.SetActive(false);
            SelectGarage.SetActive(false);

            LivingObjArray.SetActive(true);
            
            BathObjArray.SetActive(false);
            KitchenObjArray.SetActive(false);
            SleeppingObjArray.SetActive(false);
            StorageObjArray.SetActive(false);
            GarageObjArray.SetActive(false);
        }
        else if (category == "Sleepingroom")
        {
            SelectSleeping.SetActive(true);

            SelectLiving.SetActive(false);
            SelectBath.SetActive(false);
            SelectKitchen.SetActive(false);
            SelectStorage.SetActive(false);
            SelectGarage.SetActive(false);

            SleeppingObjArray.SetActive(true);

            BathObjArray.SetActive(false);
            KitchenObjArray.SetActive(false);
            LivingObjArray.SetActive(false);
            StorageObjArray.SetActive(false);
            GarageObjArray.SetActive(false);
        }
        else if (category == "Storage")
        {
            SelectStorage.SetActive(true);

            SelectBath.SetActive(false);
            SelectLiving.SetActive(false);
            SelectKitchen.SetActive(false);
            SelectSleeping.SetActive(false);
            SelectGarage.SetActive(false);

            StorageObjArray.SetActive(true);

            BathObjArray.SetActive(false);
            KitchenObjArray.SetActive(false);
            LivingObjArray.SetActive(false);
            SleeppingObjArray.SetActive(false);
            GarageObjArray.SetActive(false);
        }
        else if (category == "Garage")
        {
            SelectGarage.SetActive(true);

            SelectBath.SetActive(false);
            SelectLiving.SetActive(false);
            SelectKitchen.SetActive(false);
            SelectSleeping.SetActive(false);
            SelectStorage.SetActive(false);

            GarageObjArray.SetActive(true);

            BathObjArray.SetActive(false);
            KitchenObjArray.SetActive(false);
            LivingObjArray.SetActive(false);
            SleeppingObjArray.SetActive(false);
            StorageObjArray.SetActive(false);
        }
    }

    public void OpenInfo()
    {
        InfoWindow.SetActive(true);
        infoTimer = 10.0f;

        // change all values
    }

//--------------------------------------------------------------------------------------------
// Pause menu functions

    public void PauseGame()
    {
        gameIsPaused = true;
        PauseMenu.SetActive(true);
        Click.Play();
    }

    public void UnPauseGame()
    {
        gameIsPaused = false;
        PauseMenu.SetActive(false);
        Click.Play();
    }

    //---------------------------

    public void GoToMainMenu()
    {
        Application.LoadLevel("Start scene");
        Click.Play();
    }

    public void RetryLevel()
    {
        Application.LoadLevel("Game scene");
        Click.Play();
    }

    //---------------------------

    public void MuteMusic()
    {
        if (soundIsMuted)
        {
            GameMusic.UnPause();
            Click.Play();
            Click.mute = false;
            soundIsMuted = false;

            MuteButton.image.sprite = Unmuted;
        }
        else
        {
            GameMusic.Pause();
            Click.mute = true;
            soundIsMuted = true;

            MuteButton.image.sprite = Muted;
        }
    }
}
