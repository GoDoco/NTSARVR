using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KillingCam : MonoBehaviour
{
    public GameObject ParticleEffect;
    private Vector2 touchPos;
    private RaycastHit hit;
    private Camera cam;
    public PlayerInput playerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;
    public int EnemyDestroyed = 0;
    private ApplictionManager appMan;
    // Start is called before the first frame update
    void Start()
    {
        appMan=GameObject.Find("XR Origin").GetComponent<ApplictionManager>();
        cam = GetComponent<Camera>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPosAction = playerInput.actions["TouchPos"];
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!touchPressAction.WasPerformedThisFrame())
        {
            
            return;
        }
        touchPos = touchPosAction.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(touchPos);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.tag == "Enemy")
            {
                var clone = Instantiate(ParticleEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(hitObj);
                EnemyDestroyed += 1;
                appMan.SpawnEnemy();
                //appeler AplicationManager.SpawnEnemy à chaque fois qu'un bloc est détruit
            }
        }
        
    }
}
