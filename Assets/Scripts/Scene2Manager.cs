using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Scene2Manager : MonoBehaviour
{
    public List<Material> Materials;
    private List<GameObject> instantiatedCubes;
    public PlayerInput PlayerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;
    public ARRaycastManager RaycastManager;
    public TrackableType TypeToTrack = TrackableType.PlaneWithinBounds;
    public GameObject PrefabToInstantiate;
    // Start is called before the first frame update
    
    private void OnTouch()
    {
        var touchPos = touchPosAction.ReadValue<Vector2>();
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(touchPos, hits, TypeToTrack);
        if (hits.Count > 0)
        {
            ARRaycastHit firstHit = hits[0];
            GameObject cube = Instantiate(PrefabToInstantiate, firstHit.pose.position, firstHit.pose.rotation);
            instantiatedCubes.Add(cube);
        }
        
    }
    void Start()
    {
        touchPressAction = PlayerInput.actions["TouchPress"];
        touchPosAction = PlayerInput.actions["TouchPos"];
        instantiatedCubes = new List<GameObject>();
        
    }

    public void ChangeColor()
    {
        foreach (GameObject cube in instantiatedCubes)
        {
            int randomIndex = Random.Range(0, Materials.Count);
            Material randomMaterial = Materials[randomIndex];
            cube.GetComponent<MeshRenderer>().material = randomMaterial;
        }

        // Update is called once per frame
        void Update()
        {
            if (touchPressAction.WasPerformedThisFrame())
            {
                OnTouch();
            }
        }
    }
}
