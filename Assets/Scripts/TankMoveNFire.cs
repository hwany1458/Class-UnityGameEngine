using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TankMoveNFire : MonoBehaviour
{
    //public Transform spPoint; // SpawnPoint
    Transform spPoint;
    public Transform bullet;    // Bullet 프리팹
    public Transform explosion;     // 폭파 불꽃

    float moveSpeed = 10f;      // 이동속도
    float rotateSpeed = 60f;    // 회전속도(초속 60)

    float delayFire = 0.1f;     // 발사지연시간
    bool canFire = true;        // 총을 발사할 수 있는가

    // 사운드 처리
    AudioSource[] gunSound;       // AudioSource 변수 선언 (2개 이상이라서 배열로)

    // 충돌 처리
    Rigidbody rgBody;
    // 발사 불꽃을 처리하는 변수
    GameObject fire;

    int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 떄 SpawnPoint의 transform 읽어오기
        spPoint = GameObject.Find("SpawnPoint").transform;
        gunSound = GetComponents<AudioSource>();     // 컴포넌트 읽기
        rgBody = GetComponent<Rigidbody>();
        fire = GameObject.Find("FireEffect");
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // 현재 프레임에서 이동할 거리
        float amount = moveSpeed * Time.deltaTime;
        float amountRotate = rotateSpeed * Time.deltaTime;

        // 전후(Vertical) 좌우(Horizontal) 이동키를 받음
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // 오브젝트의 전방으로 이동 (전진)
        transform.Translate(Vector3.forward * amount * vert);

        // 좌우회전
        transform.Rotate(Vector3.up * amountRotate * horz);
        */

        // 단발사격
        if (Input.GetButtonDown("Fire1")) 
        {
            SingleShut();
            fire.SetActive(true);
        }

        // 연속 발사
        if (Input.GetButton("Fire2"))  // left alt or mouse1
        {
            //AutoFire();
        }

        // if (Input.GetButton("Fire2") && canFire)
        // 오른쪽 마우스 조작을 통해 화면을 돌리기 위해, 연속 발사에서 마우스 조작을 뺌
        if (Input.GetKey(KeyCode.LeftAlt) && canFire)
        {
            StartCoroutine(AutoFire2());
        }

        // 연속 발사 키(Left Alt 키)를 떼면 바로 사운드가 멈추도록
        // 마찬가지로, 마우스 조작을 위해 빼줌
        // if (!Input.GetButton("Fire2")) 
        if (!Input.GetKey(KeyCode.LeftAlt)) 
        {
            gunSound[1].Stop();
        }
    }
    private void FixedUpdate()
    {
        // 현재 프레임에서 이동할 거리
        float amount = moveSpeed * Time.deltaTime;
        float amountRotate = rotateSpeed * Time.deltaTime;

        // 전후(Vertical) 좌우(Horizontal) 이동키를 받음
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // 오브젝트의 전방으로 이동 (전진)
        transform.Translate(Vector3.forward * amount * vert);

        // 좌우회전
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

    // 연속 발사 코루틴
    IEnumerator AutoFire2()
    {
        gunSound[0].Play();
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        fire.SetActive(true);
        canFire = false;

        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }

    // 충돌 판정 및 처리
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            hp--;
            Debug.Log("Current HP is " + hp);
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

        // 현재 실행 중인 씬을 다시 불러온다
        // 씬의 오브젝트가 모두 초기화됨
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
