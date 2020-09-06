using UnityEngine;

[CreateAssetMenu(menuName = "CameraValue")]
public class CameraValue : ScriptableObject
{
    public Vector3 cameraTarget;
    public const float SmoothSpeed = 0.025f;
}
