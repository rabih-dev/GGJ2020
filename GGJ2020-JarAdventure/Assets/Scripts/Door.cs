using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    SceneChangingWithFade sceneChanger;
    public string destinationScene;
    
    void Start()
    {
        sceneChanger = GameObject.Find("Fade Canvas").GetComponent<SceneChangingWithFade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            sceneChanger.ChangeScene(destinationScene);
        }
    }
}
