using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionWorld2 : MonoBehaviour
{
     public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
