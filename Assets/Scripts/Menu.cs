using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("AR Scene 1");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MENU");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
