using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{
    private float speed=0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveEnemy()
    {
        if (gameObject.transform.position.y>0)
        {
            gameObject.transform.position += Vector3.down * (speed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
}
