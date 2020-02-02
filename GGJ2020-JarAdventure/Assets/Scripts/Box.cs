using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    SceneChangingWithFade sceneChanger;
    public string destinationScene;

    public GameObject hammer;
    public GameObject shard;

    public AudioSource hammerSound;
    public AudioSource shardSound;

    void Start()
    {
        sceneChanger = GameObject.Find("Fade Canvas").GetComponent<SceneChangingWithFade>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            // 0 == shard // 1 == hammer // 2 == nothing
            switch(Random.Range(0,2))//(PlayerPrefs.GetInt("NextBox"))
            {
                case 0:
                    //toca somzinha e soma uma shard
                    print("plim plim");
                    StartCoroutine(ShowShard());
                    PlayerPrefs.SetInt("shardAmount", PlayerPrefs.GetInt("shardAmount") + 1);
                    break;
                case 1:
                    //martelada na casa
                    print("CATIIAAAU");
                    StartCoroutine(ShowHammer());
                    break;
                case 2:
                    //nada acontece feijoada
                    print("nada nada naaaada nada");
                    break;
            }
            sceneChanger.ChangeScene(destinationScene);
        }
    }

    IEnumerator ShowShard()
    {
        yield return new WaitForSeconds(2f);
        shard.SetActive(true);
        shardSound.Play();
    }

    IEnumerator ShowHammer()
    {
        yield return new WaitForSeconds(2f);
        hammer.SetActive(true);
        hammerSound.Play();
    }

}