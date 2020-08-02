using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StandbyScene : MonoBehaviour
{
    /// <summary>
	/// 준비 화면에서 필요한 모든 조작을 담당함
	/// </summary>

    public GameObject player;   // 오리 객체
    public GameObject _camera;
    public GameObject buttons;    // 버튼들 배열 저장

    private bool _isButtonsComing;
    private RectTransform _buttonsRect;
    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = player.GetComponent<Animator>();
        _buttonsRect = buttons.GetComponent<RectTransform>();
        _isButtonsComing = true;
        StartCoroutine(BirdComing());   // 오리가 걸어옴
        StartCoroutine(CameraMoving()); // 카메라 움직임
        StartCoroutine(ButtonsIn());
    }


    IEnumerator BirdComing()
    {
        _playerAnimator.SetBool("is_walk", true);   // 걷는 애니메이션
        player.transform.position = new Vector3(-8, player.transform.position.y, 0);
        while (player.transform.position.x < -3)
        {
            player.transform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        _playerAnimator.SetBool("is_walk", false);   // 애니메이션 멈춤
        player.transform.position = new Vector3(-3, player.transform.position.y, 0);
    }

    IEnumerator CameraMoving()
    {
        float cx = -2.5f;
        _camera.transform.position = new Vector3(cx, 0, -10);
        while (_camera.transform.position.x < 0)
        {
            //float r = 1f;
            //cx = Mathf.SmoothDamp(cx, 0, ref r, 100f);
            cx = Mathf.Lerp(cx, 0.1f, 0.0025f);
            _camera.transform.position = new Vector3(cx, 0, -10);
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("카메라 움직임 끝");
        _camera.transform.position = new Vector3(0f, 0, -10);
    }

    IEnumerator ButtonsIn()
    {
        // 버튼들 화면 "밖에서" 안으로 들어오는 함수
        _buttonsRect.anchoredPosition = new Vector3(350f, _buttonsRect.anchoredPosition.y);
        

        while (_buttonsRect.anchoredPosition.x > -380)
        {
            _buttonsRect.anchoredPosition = new Vector3(_buttonsRect.anchoredPosition.x - 200 * Time.deltaTime, _buttonsRect.anchoredPosition.y);
            
            if (_isButtonsComing == false)
                break;

			yield return new WaitForEndOfFrame();
        }

        _isButtonsComing = false;
    }

    IEnumerator ButtonsAway(String flag)
    {
        // 버튼들 화면 밖으로 나가는 함수
        float awaySpeed = 600;
        _isButtonsComing = false;
        while (_buttonsRect.anchoredPosition.x < 350)
        {
            _buttonsRect.anchoredPosition = new Vector3(_buttonsRect.anchoredPosition.x + awaySpeed * Time.deltaTime, _buttonsRect.anchoredPosition.y);
            
            yield return new WaitForEndOfFrame();
        }

        if (flag == "Play") // flag가 Play면 RunningScene으로 넘어감
            SceneManager.LoadScene("RunningScene");
    }

    public void Clicked_PlayBtn()   // 플레이 버튼 누름
    {
        StartCoroutine(ButtonsAway("Play"));
    }
}
