using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //to add pause menu
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level One");
    }

    public void Gamequit()
    {
        Application.Quit();
    }


}
