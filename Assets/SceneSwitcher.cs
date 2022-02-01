using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    SelectionScreen,
    Game
}

public class SceneSwitcher : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void GoToScene(Scenes scene)
    {
        SceneManager.LoadScene(enumToScene[scene]);
    }

    public Dictionary<Scenes, string> enumToScene = new Dictionary<Scenes, string>
    {
        { Scenes.SelectionScreen, "Scenes/SelectionScreen" },
        { Scenes.Game, "Scenes/Game" }
    };

    public void GoToSelectionScreen()
    {
        GoToScene(Scenes.SelectionScreen);
    }

    public void GoToGame()
    {
        GoToScene(Scenes.Game);
    }
}
