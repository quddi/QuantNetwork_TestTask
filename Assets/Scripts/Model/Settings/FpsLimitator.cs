using UnityEngine;

public class FpsLimitator : MonoBehaviour
{
    [Range(30, 60)]
    [SerializeField] private int _maxFps;
    
    private void Start()
    {
        Application.targetFrameRate = _maxFps;
    }
}
