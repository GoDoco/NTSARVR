using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{
    public GameObject baseDestroyAnim;
    private float speed=0.1f;
    public int Score;
    private ApplictionManager appMan;
    private KillingCam _killingCam;
    
    // Start is called before the first frame update
    void Start()
    {
        appMan=GameObject.Find("XR Origin").GetComponent<ApplictionManager>();
        _killingCam = GameObject.Find("Main Camera").GetComponent<KillingCam>();
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

    public void DestroyEnemy(GameObject destroyAnim, bool naturalDestruction=true)
    {
        var clone = Instantiate(destroyAnim, gameObject.transform.position, Quaternion.identity);
        clone.transform.localScale = gameObject.transform.localScale;
        Destroy(clone,1);
        Destroy(gameObject);
        if (naturalDestruction)
        {
            if (Score > 0)
            {
                _killingCam.score -= Score;
            }
        }
        else
        {
            _killingCam.score += Score;
        }

        if (_killingCam.score<=0)
        {
            SceneManager.LoadScene("Game Over");
        }
        appMan.SpawnEnemy();
    }
}
