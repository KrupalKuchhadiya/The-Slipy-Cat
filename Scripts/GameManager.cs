using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    //Hexagon Generator Variables
    [Header("Hexagon Generator Variables")]
    [SerializeField]
    GameObject Hexagon, parent, LosePanel, PlayerWinPanel, SettingPanel, MainPanel;
    [SerializeField]
    List<GameObject> AllGeneratedHexagon;
    bool flag;
    int no = 0;

    // Odd-Even Hexagon List
    [Header("Odd-Even Hexagon List")]
    [SerializeField]
    List<GameObject> EvenHexagon, OddHexagon;

    //Player And Bot Move Variables
    [Header("Player And Bot Move Variables")]
    [SerializeField]
    List<GameObject> ClickedObj, PossibleToWalk;
    public int MidPoint;

    //Public Script
    [Header("Public Script")]
    public static GameManager instance;
    bool Lose;

    //Cat Image Setter
    [Header("Cat Image Setter")]
    [SerializeField]
    Sprite Cat, HexaGon;
    [SerializeField]
    Button MusicBtn, SoundBtn;
    [SerializeField]
    Sprite musicON, musicOFF, soundON, soundOFF;
    [SerializeField]
    AudioSource musicSource, soundSource, CatWinSoundSource, CatLoseSoundSource;



    //Void Start Generated Hexagon
    public void Start()
    {
        int RandomBlock;

        MidPoint = 61;
        instance = this;
        for (int i = 1; i <= 11; i++)
        {
            for (int j = 1; j <= 11; j++)
            {
                GameObject Temp = Instantiate(Hexagon, parent.transform);
                AllGeneratedHexagon.Add(Temp);
                Temp.name = no.ToString();
                no++;
                if (!flag)
                {
                    Hexagon.transform.position = new Vector3(j * 0.9f, i * 0.9f, 0);
                    EvenHexagon.Add(Temp);
                }
                else
                {
                    Hexagon.transform.position = new Vector3(0.5f + (j * 0.9f), i * 0.9f, 0);
                    OddHexagon.Add(Temp);
                }
                //if (i == 1 || i == 11 || j == 1 || j == 11)
                //{
                //    Temp.tag = "Border";
                //    //Hexagon.tag = "Border";
                //}

            }
            flag = !flag;
        }
        parent.transform.position = new Vector3(-5.4f, -5.5f, 0);
        MidPointMethod();
        int RandomTaken;
        RandomTaken = Random.Range(3, 10);
        for (int k = 0; k < RandomTaken; k++)
        {
            RandomBlock = Random.Range(0, AllGeneratedHexagon.Count);
            Debug.Log(RandomBlock);
            AllGeneratedHexagon[RandomBlock].tag = "Random";
            if (AllGeneratedHexagon[RandomBlock].CompareTag("Random"))
            {
                AllGeneratedHexagon[RandomBlock].GetComponent<PolygonCollider2D>().enabled = false;
                AllGeneratedHexagon[RandomBlock].GetComponent<SpriteRenderer>().color = Color.cyan;
                ClickedObj.Add(AllGeneratedHexagon[RandomBlock]);
            }
        }


        AllGeneratedHexagon[MidPoint].gameObject.GetComponent<SpriteRenderer>().sprite = Cat;
        BORDER();

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
    public void CatWinSound()
    {
        CatWinSoundSource.Play();
    }
    public void CatLoseSound()
    {
        CatLoseSoundSource.Play();
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
    //Void Update
    private void Update()
    {
        PlayerWin();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (SettingPanel.activeInHierarchy)
            {
                SettingPanel.SetActive(false);
                MainPanel.SetActive(true);
                parent.SetActive(true);
            }
            else if (PlayerWinPanel.activeInHierarchy)
            {
                SceneManager.LoadScene(1);
            }
            else if (LosePanel.activeInHierarchy)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    //Middle Point Method(Middle Point Generator And Setter)
    public void MidPointMethod()
    {
        AllGeneratedHexagon[MidPoint].gameObject.GetComponent<SpriteRenderer>().sprite = Cat;
        AllGeneratedHexagon[MidPoint].gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        PossibleToWalk.Clear();
        if (OddHexagon.Contains(AllGeneratedHexagon[MidPoint]))
        {
            //AllGeneratedHexagon[MidPoint + 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint - 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint + 12].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint + 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint - 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint - 10].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            /*====================================================================================================*/

            //if(!AllGeneratedHexagon[MidPoint - 1])
            //{
            //PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 1]);
            //}
            //if(!AllGeneratedHexagon[MidPoint + 12])
            //{
            //PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 12]);
            //}
            //if(!AllGeneratedHexagon[MidPoint + 11])
            //{
            //PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 11]);
            //}
            //if(!AllGeneratedHexagon[MidPoint - 11])
            //{
            //PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 11]);
            //}
            //if(!AllGeneratedHexagon[MidPoint - 10])
            //{
            //PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 10]);
            //}

            /*====================================================================================================*/


            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 1]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 12]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 11]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 11]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 10]);
        }
        else
        {
            //AllGeneratedHexagon[MidPoint + 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint - 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint + 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint + 10].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint - 12].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //AllGeneratedHexagon[MidPoint - 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            /*====================================================================================================*/

            //if (!AllGeneratedHexagon[MidPoint - 1])
            //{
            //    PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 1]);
            //}
            //if (!AllGeneratedHexagon[MidPoint - 12])
            //{
            //    PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 12]);
            //}
            //if (!AllGeneratedHexagon[MidPoint + 11])
            //{
            //    PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 11]);
            //}
            //if (!AllGeneratedHexagon[MidPoint - 11])
            //{
            //    PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 11]);
            //}
            //if (!AllGeneratedHexagon[MidPoint + 10])
            //{
            //    PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 10]);
            //}

            /*====================================================================================================*/

            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 1]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 1]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 11]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint + 10]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 12]);
            PossibleToWalk.Add(AllGeneratedHexagon[MidPoint - 11]);
        }
    }
    //Check Possibility To Walk For Cat
    public void PossibleToWalkMethod()
    {
        for (int i = 0; i < PossibleToWalk.Count; i++)
        {
            if (ClickedObj.Contains(PossibleToWalk[i]))
            {
                ClickedObj.Add(PossibleToWalk[i]);

            }
        }

        foreach (GameObject Rand in ClickedObj)
        {
            PossibleToWalk.Remove(Rand);
        }
    }
    //Clicked Object Disable
    public void ClickedObjMethod(GameObject clickedObj)
    {
        SoundClick();
        ClickedObj.Add(clickedObj);
        clickedObj.GetComponent<PolygonCollider2D>().enabled = false;
        clickedObj.GetComponent<SpriteRenderer>().color = Color.cyan;

        PossibleToWalkMethod();
        MoveMethod();
    }
    //Move Method And Win Method For Cat
    public void MoveMethod()
    {

        if (Lose)
        {
            CatWinSound();
            LosePanel.SetActive(true);
            parent.SetActive(false);
        }
        else
        {
            //AllGeneratedHexagon[MidPoint].gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            AllGeneratedHexagon[MidPoint].gameObject.GetComponent<SpriteRenderer>().sprite = HexaGon;
            AllGeneratedHexagon[MidPoint].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            int val = Random.Range(0, PossibleToWalk.Count);
            MidPoint = int.Parse(PossibleToWalk[val].gameObject.name);
            Debug.Log("Middle point is = " + MidPoint);
        }
        if (AllGeneratedHexagon[MidPoint].CompareTag("Border"))
        {
            Debug.Log("IF CALLED");
            Lose = true;
            AllGeneratedHexagon[MidPoint].gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        }
        else
        {
            MidPointMethod();
            AllGeneratedHexagon[MidPoint].gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        }
    }
    //PlayerWin Method
    public void PlayerWin()
    {
        if (PossibleToWalk.Count == 0)
        {
            CatLoseSound();
            PlayerWinPanel.SetActive(true);
            parent.SetActive(false);
        }
        else
        {
            MidPointMethod();
        }
    }
    // Border Give Method
    public void BORDER()
    {
        AllGeneratedHexagon[1].tag = "Border";
        AllGeneratedHexagon[2].tag = "Border";
        AllGeneratedHexagon[3].tag = "Border";
        AllGeneratedHexagon[4].tag = "Border";
        AllGeneratedHexagon[5].tag = "Border";
        AllGeneratedHexagon[6].tag = "Border";
        AllGeneratedHexagon[7].tag = "Border";
        AllGeneratedHexagon[8].tag = "Border";
        AllGeneratedHexagon[9].tag = "Border";
        AllGeneratedHexagon[10].tag = "Border";
        AllGeneratedHexagon[11].tag = "Border";
        AllGeneratedHexagon[22].tag = "Border";
        AllGeneratedHexagon[33].tag = "Border";
        AllGeneratedHexagon[44].tag = "Border";
        AllGeneratedHexagon[55].tag = "Border";
        AllGeneratedHexagon[66].tag = "Border";
        AllGeneratedHexagon[77].tag = "Border";
        AllGeneratedHexagon[88].tag = "Border";
        AllGeneratedHexagon[99].tag = "Border";
        AllGeneratedHexagon[110].tag = "Border";
        AllGeneratedHexagon[111].tag = "Border";
        AllGeneratedHexagon[112].tag = "Border";
        AllGeneratedHexagon[113].tag = "Border";
        AllGeneratedHexagon[114].tag = "Border";
        AllGeneratedHexagon[115].tag = "Border";
        AllGeneratedHexagon[116].tag = "Border";
        AllGeneratedHexagon[117].tag = "Border";
        AllGeneratedHexagon[118].tag = "Border";
        AllGeneratedHexagon[119].tag = "Border";
        AllGeneratedHexagon[120].tag = "Border";
        AllGeneratedHexagon[0].tag = "Border";
        AllGeneratedHexagon[12].tag = "Border";
        AllGeneratedHexagon[23].tag = "Border";
        AllGeneratedHexagon[34].tag = "Border";
        AllGeneratedHexagon[45].tag = "Border";
        AllGeneratedHexagon[56].tag = "Border";
        AllGeneratedHexagon[67].tag = "Border";
        AllGeneratedHexagon[78].tag = "Border";
        AllGeneratedHexagon[89].tag = "Border";
        AllGeneratedHexagon[100].tag = "Border";
    }
    //Retry Button
    public void Retry()
    {
        SoundClick();
        SceneManager.LoadScene(0);
    }

    public void SettingPanelOpen()
    {
        SoundClick();
        SettingPanel.SetActive(true);
        MainPanel.SetActive(false);
        parent.SetActive(false);
    }

    public void SettingPanelClose()
    {
        SoundClick();
        SettingPanel.SetActive(false);
        MainPanel.SetActive(true);
        parent.SetActive(true);
    }

    public void GameStop()
    {
        SoundClick();
        SceneManager.LoadScene(0);
    }
}