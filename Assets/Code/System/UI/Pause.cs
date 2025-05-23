using UnityEngine;
using UnityEngine.Animations;

public class Pause : MonoBehaviour
{
    [SerializeField] private TweenGroup tweenGroup;

    private void Start() => CursorStatus(false);
    private void OnDestroy() => CursorStatus(true);
    private void CursorStatus(bool value)
    {
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = value;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            tweenGroup.EnableTween();
            Time.timeScale = 0f;
            CursorStatus(true);
        }
    }
    public void ClosePause()
    {
        tweenGroup.DisableTween();
        Time.timeScale = 1f;
        CursorStatus(false);
    }
}