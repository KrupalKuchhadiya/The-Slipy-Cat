using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HomeManager : MonoBehaviour
{
    [SerializeField]
    GameObject HomePanel, SettingPanel, ExitPanel, LoadingPanel;
    [SerializeField]
    Image LoadingSlider;
    [SerializeField]
    float Speed;
    bool Red;
    [SerializeField]
    TextMeshProUGUI LoadingText;
    [SerializeField]
    Button MusicBtn, SoundBtn;
    [SerializeField]
    Sprite musicON, musicOFF, soundON, soundOFF;
    [SerializeField]
    AudioSource musicSource, soundSource;

    void Start()
    {

        if (AudioManager.instance.music)
        {

            MusicBtn.GetComponent<Image>().sprite = musicON;
            musicSource.mute = false;
            AudioManager.instance.music = true;
        }
        else
        {

            MusicBtn.GetComponent<Image>().sprite = musicOFF;
            musicSource.mute = true;
            AudioManager.instance.music = false;
        }




        if (AudioManager.instance.sound)
        {

            SoundBtn.GetComponent<Image>().sprite = soundON;
            soundSource.mute = false;
            AudioManager.instance.sound = true;
        }
        else
        {

            SoundBtn.GetComponent<Image>().sprite = soundOFF;
            soundSource.mute = true;
            AudioManager.instance.sound = false;
        }
    }

    public void SoundClick()
    {
        soundSource.Play();
    }

    public void SoundManagement()
    {
        SoundClick();
        if (AudioManager.instance.sound)
        {
            SoundBtn.GetComponent<Image>().sprite = soundOFF;
            soundSource.mute = true;
            AudioManager.instance.sound = false;
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = soundON;
            soundSource.mute = false;
            AudioManager.instance.sound = true;
        }
    }


    public void MusicManagement()
    {
        SoundClick();
        if (AudioManager.instance.music)
        {
            MusicBtn.GetComponent<Image>().sprite = musicOFF;
            musicSource.mute = true;
            AudioManager.instance.music = false;
        }
        else
        {
            MusicBtn.GetComponent<Image>().sprite = musicON;
            musicSource.mute = false;
            AudioManager.instance.music = true;
        }
    }

    private void Update()
    {

        if(Red)
        {
            if(LoadingSlider.fillAmount < 1)
            {
                LoadingSlider.fillAmount += Speed*Time.deltaTime;
                if(LoadingSlider.fillAmount < 0.33f)
                {
                    LoadingText.text = "Loading.";
                    LoadingText.GetComponent<RectTransform>().sizeDelta = new Vector2(270.9715f, 68.5878f);
                }
                else if(LoadingSlider.fillAmount < 0.66f)
                {
                    LoadingText.text = "Loading..";
                }
                else
                {
                    LoadingText.text = "Loading...";
                }
            }
            else
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        /////////////////
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(SettingPanel.activeInHierarchy)
            {
                SettingPanel.SetActive(false);
                HomePanel.SetActive(true);
            }
            else if(ExitPanel.activeInHierarchy)
            {
                ExitPanel.SetActive(false);
                HomePanel.SetActive(true) ;
            }
            else
            {
                HomePanel.SetActive(false);
                ExitPanel.SetActive(true);
            }
        }
    }
    public void LoadingPanelOpen()
    {
        Red = true;
        LoadingPanel.SetActive(true);
        HomePanel.SetActive(false);
    }
    public void SettingPanelOpen()
    {
        HomePanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void SettingPanelClose()
    {
        HomePanel.SetActive(true);
        SettingPanel.SetActive(false);
    }

    public void ExitPanelOpen()
    {
        HomePanel.SetActive(false);
        ExitPanel.SetActive(true);
    }

    public void ExitPanelClose()
    {
        HomePanel.SetActive(true);
        ExitPanel.SetActive(false);
    }

    public void ExitPanelYes()
    {
        Application.Quit();
    }
}
