using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Header("ī�޶� ��ġ, ����, FOV--------------")]
    [SerializeField] Vector3 position = new Vector3(0, 3.6f, -7.8f);    // ī�޶� �ʱ� ��ġ
    [SerializeField] Vector3 rotation = new Vector3(14, 0, 0);          // ī�޶��� �ʱ� ȸ����
    [SerializeField] [Range(10, 100)] float fov = 30f;                 // ī�޶��� Field of View

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
        // target ����
        target = GameObject.Find("Tank").transform; // Target ���� (ī�޶� ������ ��ǥ�� ����)
        if (target != null)
        { 
            Debug.Log("Target Object is found --" + target.name);
            InitCamera();  // ī�޶� �ʱ�ȭ
        }
        else
        {
            Debug.LogWarning("Target Object is NOT found ..");
        }
    }

    // Update is called once per frame
    void Update() 
    {
        // ���콺���� ���� ����/�ܾƿ�
        // zoomin (wheel up+) zoomout (wheel down-)
        float zoom = Input.GetAxis("Mouse ScrollWheel") * 20;
        fov = Mathf.Clamp(fov - zoom, 10, 100);
        cam.GetComponent<Camera>().fieldOfView = fov;

        // ������ ���콺�� Ŭ���ϰ� ������ ȭ�� ȸ��
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

    //void LateUpdate()
    void FixedUpdate()
    {
        // ��ǥ��
        Vector3 pos = target.position;
        Quaternion rot = target.rotation;

        // �̵�
        pivot.position = Vector3.Lerp(pivot.position, pos, moveSpeed * Time.deltaTime);

        // ȸ��
        pivot.rotation = Quaternion.Lerp(pivot.rotation, rot, turnSpeed * Time.deltaTime);
    }


    void InitCamera()
    {
        // ī�޶� ����
        cam = Camera.main.transform;   // ����ī�޶� ������ ����
        cam.GetComponent<Camera>().fieldOfView = fov;

        // Pivot �����
        pivot = new GameObject("Pivot").transform;  // Pivot��� �� ������Ʈ�� ����
        pivot.position = target.position;

        // ���콺 ȸ���� Pivot �����
        pivotRot = new GameObject("PivotRot").transform;
        pivotRot.position = target.position;
        pivotRot.parent = pivot;

        // ī�޶� �ǹ��� child�� ����
        // remarked by hwany - ���콺 �ǹ��� ����� ����, camera�� �θ� �缳��
        //cam.parent = pivot;
        cam.parent = pivotRot;
        cam.localPosition = position;
        cam.localEulerAngles = rotation;
        cam.localRotation = Quaternion.Euler(rotation); 
    }
}
