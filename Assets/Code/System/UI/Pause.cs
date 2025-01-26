using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Pause : MonoBehaviour
{
    [SerializeField] private TweenGroup tweenGroup;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            tweenGroup.EnableTween();
            Time.timeScale = 0f;
        }
    }

    public void ClosePause()
    {
        tweenGroup.DisableTween();
        Time.timeScale = 1f;
    }
}
