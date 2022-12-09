using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChanger : MonoBehaviour
{
    public string nextScene;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(nextScene);
    }
}
