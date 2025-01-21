using UnityEngine.SceneManagement;
using UnityEngine;

public class GeneralFunction
{
   
    public static void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}