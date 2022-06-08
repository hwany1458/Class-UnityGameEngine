using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionController4 : MonoBehaviour
{
    public Text userName;
    public Text userHP;

    GameObject paramObj = null;

    // Start is called before the first frame update
    void Start()
    {
        paramObj = GameObject.Find("SceneTransition");
        if (paramObj != null)
        {
            Debug.Log("�Ű������� �� �Ѿ�Խ��ϴ� ...");
            string name = paramObj.GetComponent<SceneTransitionController>().userName;
            int hp = paramObj.GetComponent<SceneTransitionController>().userHP;

            userName.text = name;
            userHP.text = hp.ToString();
        }
        else
        {
            Debug.Log("�Ű������� �Ѿ�� ������Ʈ�� �����ϴ� ...");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickGoBackToOne()
    {
        SceneManager.LoadScene("Scene1");
    }

}
