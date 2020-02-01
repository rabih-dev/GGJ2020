using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangingWithFade : MonoBehaviour
{
    public float defaultDelay;
    public float customDelay;
    public bool useCustomDelay;
    private string sceneName;

    public Animator fadeAnim;
    public Animator vaseAnim;


    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine(ShowingVase());
    }

    public void ChangeScene(string name)
    {
        sceneName = name;
        StartCoroutine(FadingToNextScene());
    }

    IEnumerator ShowingVase()
    {

        //vaseAnim.SetInteger("state", PlayerPrefs.GetInt("shardAmount"));
        yield return new WaitForSeconds(6f);
        vaseAnim.SetTrigger("vanish");
        fadeAnim.SetTrigger("fadeOut");

    }

    IEnumerator FadingToNextScene()
    {
        fadeAnim.SetTrigger("fadeIn");
        if (!useCustomDelay)
        {
            yield return new WaitForSeconds(defaultDelay);
        }
        else
        {
            yield return new WaitForSeconds(customDelay);
        }
        SceneManager.LoadScene(sceneName);
    }
}

