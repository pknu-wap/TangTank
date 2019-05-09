using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShell : MonoBehaviour {

    public GameObject PlayerMissile;   // 복제할 미사일 오브젝트
    public Transform MissileLocation;   // 미사일이 발사될 위치
    public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;             // 미사일 발사 속도를 제어할 변수
    public float shellSpeed;
    public shotani qwpdoqwjo;
    Rigidbody rb;
    Rigidbody shellrb;

    void Start()
    {
        // 처음에 미사일을 발사할 수 있도록 제어변수를 true로 설정
        FireState = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 매 프레임마다 미사일발사 함수를 체크한다.
        playerFire();
    }

    // 미사일을 발사하는 함수
    private void playerFire()
    {
        // 제어변수가 true일때만 발동
        if (FireState)
        {
            if (Input.GetKey(KeyCode.I))
            {
                qwpdoqwjo.gameObject.SetActive(true);
                qwpdoqwjo.tankAnimation.SetTrigger("isAttack");

                // 코루틴 "FireCycleControl"이 실행되며
                StartCoroutine(FireCycleControl());

                // "PlayerMissile"을 "MissileLocation"의 위치에 "MissileLocation"의 방향으로 복제한다.
                GameObject s = Instantiate(PlayerMissile, MissileLocation.position, MissileLocation.rotation) as GameObject;
                shellrb = s.GetComponent<Rigidbody>();
                shellrb.AddForce(MissileLocation.right * shellSpeed, ForceMode.Impulse);
                GameObject.Find("BGM").GetComponent<AudioSource>().Play();
            }
        }
    }

    // 코루틴 함수
    IEnumerator FireCycleControl()
    {
        // 처음에 FireState를 false로 만들고
        FireState = false;
        yield return new WaitForSeconds(0.25f);
        qwpdoqwjo.gameObject.SetActive(false);

        // FireDelay초 후에
        yield return new WaitForSeconds(2);

        // FireState를 true로 만든다.
        FireState = true;
    }
}
