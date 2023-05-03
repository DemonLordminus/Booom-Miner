using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// A Manager to handle UI interact of main menu. Including Start/Help/Setting/Exit/etc
/// </summary>
public class TitleManager : Singleton<TitleManager>
{
    [SerializeField] private Animator animatorHelpMenu;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private List<GameObject> listBtns; // 0: start 1:help 2:setting 3:exit
    private bool helpMenuIsOpen;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SwitchHelp()
    {
        helpMenuIsOpen = !helpMenuIsOpen;
        animatorHelpMenu.SetBool("isOpen", helpMenuIsOpen);
        //if (helpMenuIsOpen)
        //    eventSystem.sendNavigationEvents = false;
        //else
        //    eventSystem.sendNavigationEvents = true;
    }

    public void SwitchSetting()
    {

    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        UnityEngine.Application.Quit();
    #endif
    }

    // Start is called before the first frame update
    void Start()
    {
        if(eventSystem is null)
        {
            eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        }
        if(animatorHelpMenu is null)
        {
            animatorHelpMenu = this.GetComponentInChildren<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (helpMenuIsOpen)
        {
            eventSystem.SetSelectedGameObject(listBtns[1]);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (eventSystem.currentSelectedGameObject is null)
                eventSystem.SetSelectedGameObject(listBtns[0]);
        }
    }
}
