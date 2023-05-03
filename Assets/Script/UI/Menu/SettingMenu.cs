using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] private List<GameObject> listBtns;
    [SerializeField] private GameObject returnNavi;
    bool isEnable = false;
    int idxCurrentSelect = 0;

    float audioValue;
    [SerializeField] float audioValue_step;
    int idxResolution; // 0:1080p 1:2K 2:720p
    List<(int, int)> listResolution;
    bool isFullscreen;

    // tmp UI control
    [SerializeField] Text txtAudio;
    [SerializeField] Text txtResolution;
    [SerializeField] Text txtFullscreen;

    private enum SettingMenuState
    {
        audio = 0,
        resolution = 1,
        fullscreen = 2
    }

    private enum ResolutionMode
    {
        r_1080p = 0,
        r_2K = 1,
        r_720p = 2
    }

    public void SwitchEnable()
    {
        isEnable = !isEnable;
        if (isEnable)
        {
            eventSystem.SetSelectedGameObject(listBtns[0]);
            idxCurrentSelect = 0;
        }
        else
        {
            eventSystem.SetSelectedGameObject(returnNavi);
        }
        this.gameObject.SetActive(isEnable);
    }

    public void AdjustAudioValue(float value)
    {
        audioValue = audioValue + value;
        audioValue = Mathf.Clamp01(audioValue);
        SaveAudioValue();
    }
    public void AdjustResolution(int value)
    {
        idxResolution = (listResolution.Count + idxResolution + value) % listResolution.Count;
        RefreshScreen();
    }

    public void AdjustFullscreen()
    {
        isFullscreen = !isFullscreen;
        RefreshScreen();
    }

    public void RefreshScreen(bool save=true)
    {
        int height = listResolution[idxResolution].Item2;
        int width = listResolution[idxResolution].Item1;
        Screen.SetResolution(width, height, isFullscreen);
        if (save)
        {
            PlayerPrefs.SetInt("resolutionMode", idxResolution);
            PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
        }
    }

    private void SaveAudioValue()
    {
        PlayerPrefs.SetFloat("audioValue", audioValue);
    }

    private void Awake()
    {
        listResolution = new List<(int, int)>();
        listResolution.Add((1920, 1080));
        listResolution.Add((3840, 2160));
        listResolution.Add((1280, 720));
    }

    private void UpdateUI()
    {
        txtAudio.text = ((int)(audioValue * 10+0.5)*10).ToString();
        int height = listResolution[idxResolution].Item2;
        int width = listResolution[idxResolution].Item1;
        txtResolution.text = width.ToString() + " * " + height.ToString();
        txtFullscreen.text = isFullscreen ? "Fullscreen" : "Window";
    }
    // Start is called before the first frame update
    void Start()
    {
        audioValue = PlayerPrefs.GetFloat("audioValue", 1.0f);
        idxResolution = PlayerPrefs.GetInt("resolutionMode", 0);
        isFullscreen = PlayerPrefs.GetInt("fullscreen", 0) > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnable)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SwitchEnable();
            else
            {
                GameObject curSelected = eventSystem.currentSelectedGameObject;
                for (int i = 0; i < listBtns.Count; i++)
                {
                    if (curSelected == listBtns[i])
                    {
                        idxCurrentSelect = i;
                        break;
                    }
                    if (i == listBtns.Count - 1)
                    {
                        idxCurrentSelect = 0;
                        eventSystem.SetSelectedGameObject(listBtns[idxCurrentSelect]);
                    }
                }
                switch (idxCurrentSelect)
                {
                    case (int)SettingMenuState.audio:
                        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                            AdjustAudioValue(audioValue_step);
                        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                            AdjustAudioValue(-audioValue_step);
                        break;
                    case (int)SettingMenuState.resolution:
                        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                            AdjustResolution(1);
                        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                            AdjustResolution(-1);
                        break;
                    case (int)SettingMenuState.fullscreen:
                        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                            AdjustFullscreen();
                        break;
                    default:
                        break;
                }
                UpdateUI();
            }
        }
        
    }
}
