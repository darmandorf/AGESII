using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Image black;
    public Animator anim;

    public GameObject titleMenu;
    public GameObject credits;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        StartCoroutine(Fade());     
    }
    public void ShowCredits()
    {
        titleMenu.SetActive(false);
        credits.SetActive(true);
    }
    public void BackToTitle()
    {
        titleMenu.SetActive(true);
        credits.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator Fade()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(1);
    }
}
