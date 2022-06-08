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
        // �񵿱������� ���� ������ ���� Coroutine() ���
        StartCoroutine(LoadAsyncScene());
    }

    public void LoadNextScene(string str)
    {
        // �񵿱������� ���� ������ ���� Coroutine() ���
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        // AsyncOperation�� ���� SceneLoad()
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene3");

        // Scene�� �ҷ����� ���� �Ϸ�Ǹ�, AsyncOperation�� isDone ���°� ��
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadAsyncScene(string str)
    {
        // AsyncOperation�� ���� SceneLoad()
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(str);

        // Scene�� �ҷ����� ���� �Ϸ�Ǹ�, AsyncOperation�� isDone ���°� ��
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
