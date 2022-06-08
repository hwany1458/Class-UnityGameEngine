using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    [System.NonSerialized]
    public string userName;
    [System.NonSerialized]
    public int userHP;

    // Start is called before the first frame update
    void Start()
    {
        userName = "YongHwan";
        userHP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    public void ClickGotoTwo()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void ClickGoBackToOne()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadNextScene()
    {
        // 비동기적으로 씬을 블러오기 위해 Coroutine() 사용
        StartCoroutine(LoadAsyncScene());
    }

    public void LoadNextScene(string str)
    {
        // 비동기적으로 씬을 블러오기 위해 Coroutine() 사용
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        // AsyncOperation을 통해 SceneLoad()
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene3");

        // Scene를 불러오는 것이 완료되면, AsyncOperation은 isDone 상태가 됨
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadAsyncScene(string str)
    {
        // AsyncOperation을 통해 SceneLoad()
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(str);

        // Scene를 불러오는 것이 완료되면, AsyncOperation은 isDone 상태가 됨
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void ClickGotoFour()
    {
        //SceneManager.LoadScene("Scene4");
        LoadNextScene("Scene4");
    }
}
