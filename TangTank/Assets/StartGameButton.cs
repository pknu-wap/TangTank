using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("1_Game");
    }

}