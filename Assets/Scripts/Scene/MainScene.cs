using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
	/// <summary>
	/// 메인화면에서 필요한 모든 조작을 담당함
	/// </summary>

	public Text text;   // touch to start Text
	public Transform cloud;
	public Transform bgDuck;
	public Transform[] bgDucklings;

	private Transform bird;   // 오리 객체 
	private bool fade = true;   // touch to start 가 흐려지게 하건지 뚜렷해지게 할건지 여부
	private Transform maincamera;
	private Vector3 cameraPos;

	float cloudWidth, cloudPosY;
	bool isCloudUp;
	Vector3 cloudVelocity = new Vector3(-0.1f, 0);

	bool isDuckRight = true;

	private void Start()
    {
		bird = GameObject.FindGameObjectWithTag("Player").transform;
		maincamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		cameraPos = maincamera.transform.position;

		cloudWidth = cloud.GetComponent<SpriteRenderer>().size.x * cloud.transform.localScale.x;
		cloudPosY = cloud.position.y;
	}

    private void Update()
	{
		MovingCloud();
		TextFading();
		AroundCamera();
		// BGDucklings();

		// 뒤로가기 종료
		if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKey(KeyCode.Escape))
                Application.Quit();
	}

	private void FixedUpdate()
    {
		maincamera.position = Vector3.Lerp(maincamera.position, cameraPos, 0.1f);
    }

	private void MovingCloud()
    {
		// 구름 반복
		float diff = maincamera.transform.position.x - cloud.position.x;
		if (diff >= cloudWidth / 4)
			cloud.position += Vector3.right * cloudWidth / 2;
		else if (diff <= -cloudWidth / 4)
			cloud.position -= Vector3.right * cloudWidth / 2;

		// 구름 위아래
		if (cloud.position.y > cloudPosY + 0.2f) // down
			isCloudUp = false;
		else if (cloud.position.y < cloudPosY - 0.15f) // up
			isCloudUp = true;

		cloudVelocity.y = isCloudUp ? 0.05f : -0.05f;
		cloud.position += cloudVelocity * Time.deltaTime;
	}

	private void TextFading()
    {
		// touch to start가 깜박거리는 효과를 주는 코드
		if (fade)
		{
			var color = text.color;
			text.color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime * 0.8f);
			if (text.color.a <= 0.4f)
				fade = false;
		}
		else
		{
			var color = text.color;
			text.color = new Color(color.r, color.g, color.b, color.a + Time.deltaTime * 0.8f);
			if (text.color.a >= 1)
				fade = true;
		}
	}

	private void AroundCamera()
    {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");
		if (Application.platform == RuntimePlatform.Android)
        {
			dx = Input.acceleration.x;
			dy = Input.acceleration.y;
        }

		cameraPos.x = dx / 3;
		cameraPos.y = dy / 5;
	}

	private void BGDucklings()
    {
		if (bgDuck.position.x > 0) // left
			isDuckRight = false;
		else if (bgDuck.position.x < -3) // right
			isDuckRight = true;

		Vector3 velo = Vector3.right * (isDuckRight ? 0.5f : -0.5f) * Time.deltaTime;
		bgDuck.position += velo;
		bgDuck.GetComponent<SpriteRenderer>().flipX = !isDuckRight;
		for (int i = 0; i < 3; i++)
		{
			bgDucklings[i].position += velo;
			bgDucklings[i].GetComponent<SpriteRenderer>().flipX = !isDuckRight;
		}
    }

    public void TouchBtn() => StartCoroutine(TouchToStart());

	IEnumerator TouchToStart()
	{
		bird.GetComponent<SpriteRenderer>().flipX = true;
		bird.GetComponent<BirdCustomAnimation>().isWalking = true;
		while (bird.position.x < 6)
		{
			bird.position += Vector3.right * (1.5f * Time.deltaTime);

			yield return null;
		}
		// 다음 씬으로 넘어감
		FindObjectOfType<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
