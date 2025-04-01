using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{
    public GameObject baseDestroyAnim;
    private float speed=0.1f;
    public int Score;
    
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
        else
        {
            DestroyEnemy(baseDestroyAnim);
        }
    }
    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    public void DestroyEnemy(GameObject destroyAnim)
    {
        var clone = Instantiate(destroyAnim, gameObject.transform.position, Quaternion.identity);
        clone.transform.localScale = gameObject.transform.localScale;
        Destroy(clone,1);
        Destroy(gameObject);
    }
}
