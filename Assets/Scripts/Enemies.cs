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
    public float speed=0.1f;
    public int Score;
    private ApplictionManager appMan;
    private KillingCam _killingCam;
    [SerializeField] private AudioClip damageSoundClip;
    [SerializeField] private AudioClip fallSoundClip;

    
    // Start is called before the first frame update
    void Start()
    {
        appMan=GameObject.Find("XR Origin").GetComponent<ApplictionManager>();
        _killingCam = GameObject.Find("Main Camera").GetComponent<KillingCam>();
        speed*=Menu.difficulty;
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
        _killingCam.EnemyDestroyed += 1;
        appMan.EnemyNumber -= 1;
        if (naturalDestruction)
        {
            if (Score > 0)
            {
                _killingCam.score -= Score;
            }
        }
        else
        {
            SoundFXManager.instance.PlaySoundFXClip(damageSoundClip,transform,1f);
            _killingCam.score += Score;
            
        }

        if (_killingCam.score<=0)
        {
            SceneManager.LoadScene("Game Over");
        }
        else if (_killingCam.score >= 50)
        {
            SceneManager.LoadScene("Win Screen");
        }
        appMan.SpawnEnemy();
    }
}
