using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankMoveNFire : MonoBehaviour
{
    //public Transform spPoint; // SpawnPoint
    Transform spPoint;   // ���߷� �Ѿ� ���� ��ġ
    Transform spPoint1;  // �߷� �Ѿ� ���� ��ġ
    public Transform bullet;    // Bullet ������ (�߷��� ���� �Ѿ�) -- �Ѿ� ���� ��, �̵�
    public Transform explosion;     // ���� �Ҳ�
    public Transform bullet1;    // Bullet ������ --- �߷��� ���� �Ѿ� (�Ѿ� ���� ��, ���� ����)
    public Text stText;

    float moveSpeed = 10f;      // �̵��ӵ�
    float rotateSpeed = 60f;    // ȸ���ӵ�(�ʼ� 60)

    float delayFire = 0.1f;     // �߻������ð�
    bool canFire = true;        // ���� �߻��� �� �ִ°�

    // ���� ó��
    AudioSource[] gunSound;       // AudioSource ���� ���� (2�� �̻��̶� �迭��)

    // �浹 ó��
    Rigidbody rgBody;
    // �߻� �Ҳ��� ó���ϴ� ����
    GameObject fire;

    int hp = 10;
    int power = 1000;

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� SpawnPoint�� transform �о����
        spPoint = GameObject.Find("SpawnPoint").transform;
        spPoint1 = GameObject.Find("SpawnPoint (1)").transform;
        gunSound = GetComponents<AudioSource>();     // ������Ʈ �б�
        rgBody = GetComponent<Rigidbody>();

        stText.text = "HP = " + hp;

        fire = GameObject.Find("FireEffect");
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // ���� �����ӿ��� �̵��� �Ÿ�
        float amount = moveSpeed * Time.deltaTime;
        float amountRotate = rotateSpeed * Time.deltaTime;

        // ����(Vertical) �¿�(Horizontal) �̵�Ű�� ����
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // ������Ʈ�� �������� �̵� (����)
        transform.Translate(Vector3.forward * amount * vert);

        // �¿�ȸ��
        transform.Rotate(Vector3.up * amountRotate * horz);
        */

        // �ܹ߻��
        if (Input.GetButtonDown("Fire1")) 
        {
            SingleShut();
            fire.SetActive(true);
        }

        // ���� �߻�
        if (Input.GetButton("Fire2"))  // left alt or mouse1
        {
            //AutoFire();
        }

        // AddForce() �Լ��� ����ؼ� �ܹ߷� �߻�
        if (Input.GetButtonDown("Fire3"))
        {
            SingleShutAddForce();
        }

        // if (Input.GetButton("Fire2") && canFire)
        // ������ ���콺 ������ ���� ȭ���� ������ ����, ���� �߻翡�� ���콺 ������ ��
        if (Input.GetKey(KeyCode.LeftAlt) && canFire)
        {
            StartCoroutine(AutoFire2());
        }

        // ���� �߻� Ű(Left Alt Ű)�� ���� �ٷ� ���尡 ���ߵ���
        // ����������, ���콺 ������ ���� ����
        // if (!Input.GetButton("Fire2")) 
        if (!Input.GetKey(KeyCode.LeftAlt)) 
        {
            gunSound[1].Stop();
        }

        
    }
    private void FixedUpdate()
    {
        // ���� �����ӿ��� �̵��� �Ÿ�
        float amount = moveSpeed * Time.deltaTime;
        float amountRotate = rotateSpeed * Time.deltaTime;

        // ����(Vertical) �¿�(Horizontal) �̵�Ű�� ����
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // ������Ʈ�� �������� �̵� (����)
        transform.Translate(Vector3.forward * amount * vert);

        // �¿�ȸ��
        transform.Rotate(Vector3.up * amountRotate * horz);
    }
    void SingleShut() 
    {
        gunSound[0].Play();
        Instantiate(bullet, spPoint.position, spPoint.rotation); 
    }
    void AutoFire()
    {
        delayFire += Time.deltaTime;
        if (delayFire >= 0.1f)
        {
            delayFire = 0;
            gunSound[0].Play();
            Instantiate(bullet, spPoint.position, spPoint.rotation);
        }
    }

    // ���� �߻� �ڷ�ƾ
    IEnumerator AutoFire2()
    {
        gunSound[0].Play();
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        fire.SetActive(true);
        canFire = false;

        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }

    // �浹 ���� �� ó��
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            hp--;
            Debug.Log("Current HP is " + hp);
            stText.text = "HP = " + hp;
            if (hp < 0)
            {
                StartCoroutine(DestroySelf());
            }
        }
    }

    // Reset game
    IEnumerator DestroySelf()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);

        // ���� ���� ���� ���� �ٽ� �ҷ��´�
        // ���� ������Ʈ�� ��� �ʱ�ȭ��
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SingleShutAddForce()
    {
        gunSound[0].Play();
        Transform obj = Instantiate(bullet1, spPoint1.position, spPoint1.rotation) as Transform;
        obj.GetComponent<Rigidbody>().AddForce(spPoint1.forward * power);

        fire.SetActive(true);
    }
}