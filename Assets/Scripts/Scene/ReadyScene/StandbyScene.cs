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
    public GameObject levelLoader;

    public bool isCamMoving;

    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = player.GetComponent<Animator>();
        StartCoroutine(BirdComing());   // 오리가 걸어옴
        StartCoroutine(CameraMoving()); // 카메라 움직임
    }


    IEnumerator BirdComing()
    {
        _playerAnimator.SetBool("is_walk", true);   // 걷는 애니메이션
        player.transform.position = new Vector3(-8, player.transform.position.y, 0);
        while (player.transform.position.x < -3)
        {
            player.transform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime);
            yield return null;
        }
        _playerAnimator.SetBool("is_walk", false);   // 애니메이션 멈춤
        player.transform.position = new Vector3(-3, player.transform.position.y, 0);
    }

    IEnumerator CameraMoving()
    {
        isCamMoving = true;
        float cameraFirstPos = -2.5f, cameraLerpSpeed = 0.4f;
        float cameraPos = -2.5f;
        
        _camera.transform.position = new Vector3(cameraFirstPos, 0, -10);
        
        while (_camera.transform.position.x < -0.03f && isCamMoving)
        {
            cameraPos = Mathf.Lerp(cameraPos, 0.05f, Time.deltaTime * cameraLerpSpeed);
            _camera.transform.position = new Vector3(cameraPos, 0, -10);
            yield return null;
        }
        // Debug.Log("카메라 움직임 끝");
        // _camera.transform.position = new Vector3(0f, 0, -10);
    }

    public void StartGame(String flag)
    {
        if (flag == "offline")
        {
            // flag가 Play면 RunningScene으로 넘어감
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }

        StartCoroutine(gameObject.GetComponent<UIMovementManager>().ButtonsAway());
    }

    
}
