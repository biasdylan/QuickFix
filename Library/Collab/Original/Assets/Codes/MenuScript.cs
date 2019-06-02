﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour {

    
    int index, players;
    bool jOne, jTwo, jThree, Jfour;

    //lock levels
    [SerializeField]
    GameObject lockImage;

    //for click audio
    [SerializeField]
    AudioSource clickAudio;

    //player images
    [SerializeField]
    GameObject roseIcon, seanIcon, maeIcon, joshIcon;

	//for Menu Windows
	bool Game,Menu;
	[SerializeField]
	GameObject StartButton, NextLevelButton, PreviousLevelButton;

    //for Garage Images
    [SerializeField]
    GameObject Garage1, Garage2, Garage3, Garage4, Garage5;
    
    //hides the start button
    [SerializeField]
    Image hider;

    //to know the playeers 
    [SerializeField]
    Text[] playableUsers;

    //for Level
    [SerializeField]
    GameObject MainLevel, SubLevelMain, SubLevelSecondary, LevelSelectionESystem;
    int mainLevel, subLevelMain, subLevelSecondary;

    string[] strings;

	// Use this for initialization
	void Start () {

        strings = new string[4] { "one", "two", "three", "four" };

        players = 0;
        jOne = true;
        jTwo = true;
        jThree = true;
        Jfour = true;

        index = 0;
		startMainMenu ();

        //for Level
        mainLevel = 1;
        subLevelMain = 1;
        subLevelSecondary = 1;
        
        //to hide and lock mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

	}

    // Update is called once per frame
    void Update()
    {
        //for player ready and player checking
        if(players == 1)
        {

            roseIcon.gameObject.SetActive(true);
            if (roseIcon.transform.localScale.x < 1)
            {
                roseIcon.transform.localScale = new Vector3(roseIcon.transform.localScale.x + 0.1f, roseIcon.transform.localScale.y + 0.1f, roseIcon.transform.localScale.z);
            }

        }else if(players == 2)
        {
            seanIcon.gameObject.SetActive(true);
            if (seanIcon.transform.localScale.x < 1)
            {
                seanIcon.transform.localScale = new Vector3(seanIcon.transform.localScale.x + 0.1f, seanIcon.transform.localScale.y + 0.1f, seanIcon.transform.localScale.z);
            }
        }
        else if (players == 3)
        {
            maeIcon.gameObject.SetActive(true);
            if (maeIcon.transform.localScale.x < 1)
            {
                maeIcon.transform.localScale = new Vector3(maeIcon.transform.localScale.x + 0.1f, maeIcon.transform.localScale.y + 0.1f, maeIcon.transform.localScale.z);
            }
        }
        else if (players == 4)
        {
            joshIcon.gameObject.SetActive(true);
            if (joshIcon.transform.localScale.x < 1)
            {
                joshIcon.transform.localScale = new Vector3(joshIcon.transform.localScale.x + 0.1f, joshIcon.transform.localScale.y + 0.1f, joshIcon.transform.localScale.z);
            }
        }

        if (players >= 2)
        {
            hider.enabled = false;
            PlayerPrefs.SetInt("Active_Users", players);
        }

        if (Input.GetKey(KeyCode.Joystick1Button7) && jOne)
        {
            index = 0;
            saveIndex(strings[players], index);
            playableUsers[players].GetComponent<Text>().text = "one";
            players++;
            jOne = false;
        }
        else if (Input.GetKey(KeyCode.Joystick2Button7) && jTwo)
        {
            index = 1;
            saveIndex(strings[players], index);
            playableUsers[players].GetComponent<Text>().text = "two";
            players++;
            jTwo = false;
        }
        else if (Input.GetKey(KeyCode.Joystick3Button7) && jThree)
        {
            index = 2;
            saveIndex(strings[players], index);
            playableUsers[players].GetComponent<Text>().text = "three";
            players++;
            jThree = false;
        }
        else if (Input.GetKey(KeyCode.Joystick4Button7) && Jfour)
        {
            index = 3;
            saveIndex(strings[players], index);
            playableUsers[players].GetComponent<Text>().text = "four";
            players++;
            Jfour = false;
        }


        //for menu logics
        if (Menu)
        {

            InMainMenu();

        }
        else if (Game)
        {
            //for loading levels
            if(mainLevel == 1)
            {
                if(subLevelSecondary == 1)
                {
                    SceneManager.LoadScene("loadScene");
                }
                else if(subLevelSecondary == 2)
                {
                    SceneManager.LoadScene("level_1_2");
                }
                else if (subLevelSecondary == 3)
                {
                    SceneManager.LoadScene("level_1_3");
                }
            }
            else if (mainLevel == 2)
            {
                if (subLevelSecondary == 1)
                {
                    SceneManager.LoadScene("level_2_1");
                }
                else if (subLevelSecondary == 2)
                {

                }
                else if (subLevelSecondary == 3)
                {

                }
            }
            else if (mainLevel == 3)
            {
                if (subLevelSecondary == 1)
                {

                }
                else if (subLevelSecondary == 2)
                {

                }
                else if (subLevelSecondary == 3)
                {

                }
            }
            else if (mainLevel == 4)
            {
                if (subLevelSecondary == 1)
                {

                }
                else if (subLevelSecondary == 2)
                {

                }
                else if (subLevelSecondary == 3)
                {

                }
            }
            else if (mainLevel == 5)
            {
                if (subLevelSecondary == 1)
                {

                }
                else if (subLevelSecondary == 2)
                {

                }
                else if (subLevelSecondary == 3)
                {

                }
            }

        }

    }

    static void saveIndex( string key, int saveSlot)
    {
        PlayerPrefs.SetInt(key , saveSlot);
    }

	void InMainMenu(){

        //for click sound
        if (Input.GetButtonDown("Submit"))
        {
            clickAudio.Play();
        }

        //showing garage image
        if(mainLevel == 1)
        {
            Garage1.SetActive(true);
            Garage2.SetActive(false);
            Garage3.SetActive(false);
            Garage4.SetActive(false);
            Garage5.SetActive(false);
        }
        else if (mainLevel == 2)
        {
            Garage1.SetActive(false);
            Garage2.SetActive(true);
            Garage3.SetActive(false);
            Garage4.SetActive(false);
            Garage5.SetActive(false);
        }
        else if (mainLevel == 3)
        {
            Garage1.SetActive(false);
            Garage2.SetActive(false);
            Garage3.SetActive(true);
            Garage4.SetActive(false);
            Garage5.SetActive(false);
        }
        else if (mainLevel == 4)
        {
            Garage1.SetActive(false);
            Garage2.SetActive(false);
            Garage3.SetActive(false);
            Garage4.SetActive(true);
            Garage5.SetActive(false);
        }
        else if (mainLevel == 5)
        {
            Garage1.SetActive(false);
            Garage2.SetActive(false);
            Garage3.SetActive(false);
            Garage4.SetActive(false);
            Garage5.SetActive(true);
        }

        //checking if locked
        if (mainLevel == 1)
        {

            if (subLevelSecondary == 1)
            {
                lockImage.SetActive(false);
            }
            else if (subLevelSecondary == 2)
            {
                lockImage.SetActive(false);
            }
            else if (subLevelSecondary == 3)
            {
                lockImage.SetActive(false);
            }
        }
        else if (mainLevel == 2)
        {
            lockImage.SetActive(false);
            if (subLevelSecondary == 1)
            {

            }
            else if (subLevelSecondary == 2)
            {

            }
            else if (subLevelSecondary == 3)
            {

            }
        }
        else if (mainLevel == 3)
        {
            lockImage.SetActive(true);
            if (subLevelSecondary == 1)
            {

            }
            else if (subLevelSecondary == 2)
            {

            }
            else if (subLevelSecondary == 3)
            {

            }
        }
        else if (mainLevel == 4)
        {
            lockImage.SetActive(true);
            if (subLevelSecondary == 1)
            {

            }
            else if (subLevelSecondary == 2)
            {

            }
            else if (subLevelSecondary == 3)
            {

            }
        }
        else if (mainLevel == 5)
        {
            lockImage.SetActive(true);
            if (subLevelSecondary == 1)
            {

            }
            else if (subLevelSecondary == 2)
            {

            }
            else if (subLevelSecondary == 3)
            {

            }
        }

        //for activating start button
        if (players >= 2)
        {
            if(lockImage.activeSelf)
            {
                StartButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                StartButton.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            StartButton.GetComponent<Button>().interactable = false;
        }
        
    }
    
	public void startMainMenu(){
	
		Menu = true;
		Game = false;
	
	}

    public void nextLeveL()
    {
        if(subLevelSecondary < 3)
        {
            subLevelSecondary++;

        }
        else
        {
            subLevelSecondary = 1;
            mainLevel++;
            subLevelMain = mainLevel;
        }

        SubLevelSecondary.GetComponent<TextMeshProUGUI>().text = subLevelSecondary.ToString();
        SubLevelMain.GetComponent<TextMeshProUGUI>().text = subLevelMain.ToString();
        MainLevel.GetComponent<TextMeshProUGUI>().text = mainLevel.ToString();

        if (mainLevel == 5 && subLevelSecondary == 3)
        {
            NextLevelButton.GetComponent<Button>().interactable = false;
            LevelSelectionESystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(PreviousLevelButton);
        }
        else
        {
            NextLevelButton.GetComponent<Button>().interactable = true;
        }
        
        PreviousLevelButton.GetComponent<Button>().interactable = true;
    }

    public void previousLevel()
    {
        //for changing levels
        if (subLevelSecondary > 1)
        {
            subLevelSecondary--;
        }
        else
        {
            subLevelSecondary = 3;
            mainLevel--;
            subLevelMain = mainLevel;
        }

        SubLevelSecondary.GetComponent<TextMeshProUGUI>().text = subLevelSecondary.ToString();
        SubLevelMain.GetComponent<TextMeshProUGUI>().text = subLevelMain.ToString();
        MainLevel.GetComponent<TextMeshProUGUI>().text = mainLevel.ToString();

        //for restricting level
        if (mainLevel == 1 && subLevelSecondary == 1)
        {
            PreviousLevelButton.GetComponent<Button>().interactable = false;
            LevelSelectionESystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(NextLevelButton);
        }
        else
        {
            PreviousLevelButton.GetComponent<Button>().interactable = true;
        }

        NextLevelButton.GetComponent<Button>().interactable = true;
    }

	public void startGame(){

		Menu = false;
		Game = true;
	
	}

	public void quitGame(){
	
		Application.Quit ();
	
	}
}
