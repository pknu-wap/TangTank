﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotani : MonoBehaviour
{
    public GameObject gqwpkdq;
    public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;             // 미사일 발사 속도를 제어할 변수
    public Animator tankAnimation;

    void Start()
    {
        gqwpkdq.SetActive(false);
        // 처음에 미사일을 발사할 수 있도록 제어변수를 true로 설정
        FireState = true;
        tankAnimation = GetComponent<Animator>();
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
                // 코루틴 "FireCycleControl"이 실행되며
                StartCoroutine(FireCycleControl());

            }
        }
    }

    // 코루틴 함수
    IEnumerator FireCycleControl()
    {
        // 처음에 FireState를 false로 만들고
        FireState = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(FireDelay);
        // FireState를 true로 만든다.
        FireState = true;
    }
}
