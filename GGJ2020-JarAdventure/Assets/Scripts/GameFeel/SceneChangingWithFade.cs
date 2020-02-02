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

    public Animator vaseBtn;
    public Rigidbody flowerBtn;
    private AudioSource vaseCracking;
    public Animator cameraAnim;


    private PlayerController player;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            PlayerPrefs.SetInt("shardAmount", 1);
            vaseCracking = GetComponent<AudioSource>();
            StartCoroutine(MenuFadeOut());
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            StartCoroutine(ShowingVase());
        }
    }


    public void ChangeScene(string name)
    {
        sceneName = name;
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            cameraAnim.SetTrigger("camerashake");
            StartCoroutine(MenuTransition());
        }
        else
        {
            StartCoroutine(FadingToNextScene());
        }
    }

    IEnumerator MenuFadeOut()
    {
        yield return new WaitForSeconds(3f);
        fadeAnim.SetTrigger("fadeOut");
    }

    IEnumerator MenuTransition()
    {
        vaseBtn.SetTrigger("crack");
        
        vaseCracking.Play();
        flowerBtn.isKinematic = false;
        flowerBtn.AddForce(new Vector2(2000,2500));
        yield return new WaitForSeconds(1f);
        flowerBtn.AddForce(new Vector2(0, -10000));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadingToNextScene());

    }

    IEnumerator ShowingVase()
    {

        vaseAnim.SetInteger("shardAmount", PlayerPrefs.GetInt("shardAmount"));
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

