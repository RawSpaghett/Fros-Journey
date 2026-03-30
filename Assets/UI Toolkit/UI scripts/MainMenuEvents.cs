using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

//need to implement fade effects, can make it pretty later


//reference
//https://www.youtube.com/watch?v=_jtj73lu2Ko
public partial class MainMenuEvents : MonoBehaviour
{
    public int GameSceneIndex = 1; //change to proper scene index!
    private AsyncOperation load;
    private Button UIButton;
    private List<Button> MainButtons = new List<Button>(); // holds a list of button objects
    [SerializeField] private UIDocument UIDocLanding; //takes in landing document
    [SerializeField] private UIDocument UIDocMain; // references our main menu doc
    public AudioSource UniversalClickAudio;

    void Awake()
    {
        Debug.Log("MainMenuEvents Awake!");
        StartCoroutine(PreLoad(GameSceneIndex));
        UIDocMain = GameObject.Find("MainMenu").GetComponent<UIDocument>(); //grab UIDocument
        UIDocLanding = GameObject.Find("MainMenuLanding").GetComponent<UIDocument>(); //grab landing UIdoc

        UIDocLanding.rootVisualElement.RegisterCallback<ClickEvent>(OnLandingClick); //handles UIlanding click

        //searches for specific button
        UIButton = UIDocMain.rootVisualElement.Q("Start") as Button;//searches the UI docs main root (highest in the hierarchy) for a visual element in q (query)and cast it as a button
        UIButton.RegisterCallback<ClickEvent>(OnStartClick);

         //grabs every button and turns it to list, for audio
        MainButtons = UIDocMain.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < MainButtons.Count; i++)
        {
            MainButtons[i].RegisterCallback<ClickEvent>(OnClickAll);
        }
    }

    private void OnStartClick(ClickEvent evt)
    {
        if (load != null) 
    {
        load.allowSceneActivation = true;
        Debug.Log("Start is a go");
    }
    else 
    {
        Debug.LogWarning("Still preloading!");
    }
    }
    
    private void OnDisable() //deregisters, good habit
    {
        //FILL OUT!!!
    }

    private void OnClickAll(ClickEvent evt) //can be used for audio and other universal click effects in the main menu
    {
        UniversalClickAudio.Play();
        Debug.Log("OnClickAll is a go");
    }

    private void OnLandingClick(ClickEvent evt)
    {
       UIDocLanding.rootVisualElement.style.display = DisplayStyle.None; //off
       UIDocMain.rootVisualElement.style.display = DisplayStyle.Flex; //on
       Debug.Log("Landing is a go");
    }

       IEnumerator PreLoad(int sceneIndex) //load the game before the player does anything, because its a vertical slice this wont impact performance
    {
        yield return null; //padding
        Debug.Log("Preload Started");

        load = SceneManager.LoadSceneAsync(sceneIndex); //gives the percent of how finished it is
        load.allowSceneActivation = false; //pauses at 90%

        while(load.progress < 0.9f) //stops at 90%, in a different case we would use !load.isDone;
        {
            yield return null;
        }

        Debug.Log("Preload Complete"); 
    }
}

