using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandbyScene : MonoBehaviour
{
    /// <summary>
	/// 준비 화면에서 필요한 모든 조작을 담당함
	/// </summary>

    public GameObject player;   // 오리 객체
    public GameObject _camera;
    public Image panel; // fade in
    public GameObject[] buttons;    // 버튼들 배열 저장

    private void Start()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(BirdComing());   // 오리가 걸어옴
        StartCoroutine(CameraMoving()); // 카메라 움직임
        //StartCoroutine(ButtonsIn()); -> 이거 주석 풀면 실행이 안 됨.. 왤까
    }

    IEnumerator BirdComing()
    {
        player.GetComponent<Animator>().SetBool("is_walk", true);   // 걷는 애니메이션
        player.transform.position = new Vector3(-8, player.transform.position.y, 0);
        while (player.transform.position.x < -3)
        {
            player.transform.Translate(new Vector3(1.5f, 0, 0) * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        player.GetComponent<Animator>().SetBool("is_walk", false);   // 애니메이션 멈춤
        player.transform.position = new Vector3(-3, player.transform.position.y, 0);
    }

    IEnumerator CameraMoving()
    {
        float cx = -2.5f;
        _camera.transform.position = new Vector3(cx, 0, -10);
        while (_camera.transform.position.x < -0.01)
        {
            //float r = 1f;
            //cx = Mathf.SmoothDamp(cx, 0, ref r, 100f);
            cx = Mathf.Lerp(cx, 0, 0.0025f);
            _camera.transform.position = new Vector3(cx, 0, -10);
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("카메라 움직임 끝");
        _camera.transform.position = new Vector3(-0.01f, 0, -10);
    }

    IEnumerator FadeIn()
    {
        /// 대충 FadeIn 하는 함수
        panel.color = new Color(0, 0, 0, 0.9f);
        while (panel.color.a > 0)
        {
            panel.color = new Color(0, 0, 0, panel.color.a - Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        panel.color = new Color(0, 0, 0, 0);
    }

    IEnumerator ButtonsIn()
    {
        /// 버튼들 화면 "밖에서" 안으로 들어오는 함수
        while (buttons[0].transform.position.x > -250)
        {
            foreach (GameObject btn in buttons)
            {
                btn.transform.position = new Vector3(btn.transform.position.x + Time.deltaTime, btn.transform.position.y);
            }
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator ButtonsAway()
    {
        /// 버튼들 화면 밖으로 나가는 함수
        yield return null;
    }

}
