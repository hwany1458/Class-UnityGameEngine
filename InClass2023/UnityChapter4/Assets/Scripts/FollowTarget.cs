using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Header("ī�޶� ��ġ, ����, FOV--------------")]
    [SerializeField] Vector3 position = new Vector3(0, 3.6f, -7.8f);  // ī�޶� �ʱ� ��ġ
    [SerializeField] Vector3 rotation = new Vector3(14, 0, 0);   // ī�޶��� �ʱ� ȸ����
    [SerializeField] [Range(10, 100)] float fov = 30f;   // ī�޶��� Field of View

    [Header("ī�޶� �̵� �� ȸ�� �ӵ� --------------")]
    [SerializeField] float moveSpeed = 10f;  // ī�޶� �̵� �ӵ�
    [SerializeField] float turnSpeed = 10f;  // ī�޶� ȸ�� �ӵ�

    Transform target;  // �������
    Transform cam;     // ī�޶�
    Transform pivot;   // ī�޶� �̵� �� ȸ�� ��
    Transform pivotRot; // ���콺�� ȸ���� Pivot



    // Start is called before the first frame update
    void Start()
    {
        // Target ���� (ī�޶� ������ ��ǥ�� ����)
        target = GameObject.Find("TankFree_Blue").transform; 

        InitCamera();  // ī�޶� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        // ----------- ���� �ܾƿ�
        // zoomin (wheel up+) zoomout (wheel down-)
        float zoom = Input.GetAxis("Mouse ScrollWheel") * 20;
        fov = Mathf.Clamp(fov - zoom, 10, 100);
        cam.GetComponent<Camera>().fieldOfView = fov;

        //-----------------------------
        // ������ ��ư�� ������ ���� ������ ����
        if (!Input.GetMouseButton(1)) return;

        // ���콺 �̵� ����
        float x = Input.GetAxis("Mouse Y") * 2;   // ���� �̵��� x�� ȸ��
        float y = Input.GetAxis("Mouse X") * 2;   // �¿��̵��� y�� ȸ��

        // ȸ���� ���� ���
        Vector3 ang = pivotRot.localEulerAngles + new Vector3(x, y, 0);

        // x���� ȸ���� ��ȯ (0~360 --> -180~+180)  
        if (ang.x > 180)
        {
            ang.x -= 360;
        }

        // x�� ȸ�� ���� ����(���� �Ʒ��� ������ ����� �ʵ���)
        ang.x = Mathf.Clamp(ang.x, -24, 80);

        pivotRot.localEulerAngles = ang;
        // pivotRot.localRotation = Quaternion.Euler(ang);

    }

    void InitCamera()
    {
        // ī�޶� ����
        cam = Camera.main.transform;   // ����ī�޶� ������ ����
        cam.GetComponent<Camera>().fieldOfView = fov;

        // �ǹ� �����
        pivot = new GameObject("Pivot").transform;  // pivot��� �� ������Ʈ�� ����
        pivot.position = target.position;

        // ���콺 ȸ���� Pivot �����
        pivotRot = new GameObject("PivotRot").transform;
        pivotRot.position = target.position;
        pivotRot.parent = pivot;


        // ī�޶� �ǹ��� ���ϵ�� ����
        //cam.parent = pivot;
        cam.parent = pivotRot;

        cam.localPosition = position;
        // cam.localEulerAngles = rotation;
        cam.localRotation = Quaternion.Euler(rotation); 
    }

    //private void LateUpdate()
    private void FixedUpdate()
    {
        // ������
        Vector3 pos = target.position;
        Quaternion rot = target.rotation;

        // �̵�
        pivot.position = Vector3.Lerp(pivot.position, pos, moveSpeed * Time.deltaTime);
        // ȸ��
        pivot.rotation = Quaternion.Lerp(pivot.rotation, rot, turnSpeed * Time.deltaTime);

    }

}
