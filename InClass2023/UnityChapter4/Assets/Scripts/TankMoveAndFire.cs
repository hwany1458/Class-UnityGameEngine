using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;  // �� ��ȯ�� ���ؼ� �ʿ���
using UnityEngine.UI;  // (Legacy)Text�� ���� �ʿ���
//using TMPro;   // TextMeshPro�� ���� �ʿ���

public class TankMoveAndFire : MonoBehaviour
{
    float moveSpeed = 10f; // ��ü �̵� �ӵ�
    float rotateSpeed = 60f; // ��ü ȸ�� �ӵ�

    public Transform spPoint; // ��ź ���� ��ġ�� �����Ǵ� ��������Ʈ
    public Transform bullet; // Bullet(��ź) ������

    //float delayTime = 0.1f;  // �߻������ð�
    bool canFire = true; // �߻�����ó���� ���� �ο� ���� (��ź�� �߻��� �� �ִ°�?)

    AudioSource[] gunSound;   // ������ҽ� ���� (�迭�κ���)

    Rigidbody rgBody;

    GameObject fire;  // ��ź�߻� �ÿ� ȿ���̹���(����)

    int hp = 10;
    //int score = 0;

    public GameObject explosion;  // ��ũ(�Ʊ�) ���Ľ��� ��ƼŬ
    public Text countText;
    //public TMP_Text hpText;  //hpText��� �̸����� TMP_Text ����ŸŸ���� ������ ����

    //public int a;  //a��� �̸����� ������ ������ ���� (���ٱ��� ��ο���)

    public Transform rigidbodyBulletG;
    public Transform rigidbodySpawnPointG;
    int powerBulletG = 500;

    // ������� ���� ���� (���Ĵ� �Լ�) 
    //---------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //gunSound = GetComponent<AudioSource>();  // �ܼ��϶� (1���� ����)
        gunSound = GetComponents<AudioSource>();   // �迭�� ����

        rgBody = GetComponent<Rigidbody>();

        // ��ź �߻�ÿ� �������� ȿ���̹����� (ó�� ������ ��) ��Ȱ��ȭ ��Ŵ
        fire = GameObject.Find("FireEffect");
        fire.SetActive(false);
        //hp = 10;
        countText.text = "HP : " + hp.ToString();
        //hpText.text = "HP : " + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // �߻�(Fire) ó���κ� --------------

        // �ܹ� ���
        if (Input.GetButtonDown("Fire1")) { SingleShot(); }
        //if (Input.GetButton("Fire2")) { AutoFire(); }

        // ���� ���

        // ���� ��ݿ��� ������ ������(����)�� �ֱ� ����
        //if (Input.GetButton("Fire2") && canFire) { StartCoroutine(AutoFire()); }

        // *** ���ӹ߻� ����ȿ���� (��ư�� ������) ���尡 �����ϵ���  (���� 159������ ����)
        //if (!Input.GetButton("Fire2")) { gunSound[1].Stop(); }

        // ������ ���콺 Ŭ���� (Ű����) ���� ����Ʈ�� ����
        if (Input.GetKey(KeyCode.LeftShift) && canFire) { StartCoroutine(AutoFire()); }
        if (!Input.GetKey(KeyCode.LeftShift)) { gunSound[1].Stop(); }

        // (������ٵ� �ִ� ��ź) �߻�
        //if (Input.GetKey(KeyCode.A)) { SingleShotG(); }
        if (Input.GetButtonDown("Jump")) { SingleShotG(); }
    }

    private void FixedUpdate()
    {
        // �̵� & ȸ���ϴ� �κ� --------------
        // ���� �����ӿ��� �̵��� �Ÿ� ���
        float moveAmount = moveSpeed * Time.deltaTime; // ��ü �̵� �Ÿ�
        float rotateAmount = rotateSpeed * Time.deltaTime; // ��ü ȸ�� �Ÿ�(?)

        // Input Manager�� ���ǵ� �ڵ尪�� �޾ƿ�
        // ����(Vertical) �¿�(Horizontal) ���� ȭ��ǥŰ (�Ǵ� WASD)�� ����
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        //
        // *** Left Shift ���� ���¿��� �̵�, ȸ�� �������� ...
        //

        // �����̴� x-z������ Ȯ���ϱ� ����
        // 3���� �������� X��(�¿�), Y��(���Ʒ�), Z��(�յ�)
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // ���Ʒ�ȭ��ǥ�� ��ü �̵�
        // ��ü�� �������� �̵�(����)
        transform.Translate(Vector3.forward * moveAmount * vert);
        // �¿�ȭ��ǥ�� ��ü ȸ��
        transform.Rotate(Vector3.up * rotateAmount * hori);

        // �̳��ϰ� ���� ���ϰ� ���̸� üũ�غ��ô�
        //rgBody.MovePosition(rgBody.position + transform.forward * moveAmount);
        //rgBody.MoveRotation(rgBody.rotation * Quaternion.Euler(Vector3.up * rotateAmount));

    }

    void SingleShot()
    {
        Debug.Log("SingleShot() function is called ..");
        // ��ź ����
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        
        // ����Ʈ
        fire.SetActive(true);

        // ����
        //gunSound.Play();   // AudioSource�� �ϳ��� ����
        gunSound[0].Play();   // �迭�� ����
    }

    // ���� �߻� Coroutine
    //void AutoFire()
    IEnumerator AutoFire()
    {
        /*
         *  �߻簣���� �ð����� ���� (���� 153������ ����)
        delayTime += Time.deltaTime;
        if (delayTime >= 0.1f) { 
            Debug.Log("AutoFire() function is called ..");
            Instantiate(bullet, spPoint.position, spPoint.rotation);
            delayTime = 0;
        }
        */

        // Coroutine�� Ȱ���Ͽ� �߻� ������ �����ϵ��� ���� (���� 154������ ����)
        // ��ź ����
        Instantiate(bullet, spPoint.position, spPoint.rotation);

        // *** �˾Ƽ� (ã�Ƽ�) ���ӹ߻� ���� ����ȿ���� �ݿ��ϼ���
        // ����
        gunSound[1].Play();

        // *** ã�Ƽ� ���ӹ߻� ���� ȿ���̹����� �ݿ��ϼ���
        fire.SetActive(true);

        canFire = false;

        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("��ũ -- OnTriggerEnter() �Լ� �߻� " + other.tag);

        if (other.tag == "Pickupitem20")  // ��ũ�� �����۰� �ε����� ��
        {
            // ���� �۾�?
            // ���� �� (score +20)
            // GameManager ������Ʈ�� �˻�.GetComponent<GameManager>().score
            // ������ ������Ʈ ȭ�鿡�� ����
            other.gameObject.SetActive(false);
            // ���� (����ȿ��)
            // ��ƼŬ (�ð�ȿ��)
        }

        if (other.tag == "Bullet") // ��ũ�� ��ź�� �¾��� ��
        { 
            hp--;
            countText.text = "HP : " + hp.ToString();
            //hpText.text = "HP : " + hp.ToString();
            if (hp < 0)
            {
                Debug.Log("You died, Game Over..");
                // ���ӿ��� �� ȣ��
                StartCoroutine(DestroySelf());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter() �Լ� �߻� " + collision.gameObject.tag);

        // PickupItem �浹�߻� ...
        // (1) score +10, +20
        // (2) item ������Ʈ ���� 
        // (3) ��ƼŬ �߰�
        // (4) ���� �÷���
    }

    IEnumerator DestroySelf()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        // �������� ����
        yield return new WaitForSeconds(2f);

        // �� re-load (���� �������� ���� �ٽ� �ҷ���)
        // �� ��ȯ�ϱ� ���ؼ��� ������Ʈ �������� ���� ��Ͻ������ ��
        //SceneManager.LoadScene("WorkingScene");  // ���� ���ڿ��� �� �̸��� �ټ��ְ�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ������ٵ� �ִ� ��ź �߻�
    void SingleShotG()
    {
        // ��ź ����
        Transform initBulletG = Instantiate(
            rigidbodyBulletG, rigidbodySpawnPointG.position, rigidbodySpawnPointG.rotation) as Transform;
        initBulletG.GetComponent<Rigidbody>().AddForce(rigidbodySpawnPointG.forward * powerBulletG);

        // ����(����ȿ��)
        // ��ƼŬ(�ð�ȿ��)
    }
}
