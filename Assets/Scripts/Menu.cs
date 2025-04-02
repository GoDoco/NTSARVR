using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static int difficulty;
    public void Difficulty()
    {
        SceneManager.LoadScene("Difficulty");
        
    }
    public void Diff1()
    {
        SceneManager.LoadScene("AR Scene 1");
        difficulty = 1;
    }
    public void Diff2()
    {
        SceneManager.LoadScene("AR Scene 1");
        difficulty = 2;
    }
    public void Diff3()
    {
        SceneManager.LoadScene("AR Scene 1");
        difficulty = 3;
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
