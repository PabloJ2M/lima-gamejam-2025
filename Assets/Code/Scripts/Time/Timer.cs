using Player.Controller;
using UnityEngine;
using TMPro; //libreria para poder usar los TextMeshPro

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer; //para el ui

    [SerializeField] private Movement movement; //agarramos el script Movement del jugador para ver si se movio o no
    private float elapsedTime = 0f;
    [SerializeField] private bool isCounting = false;

    private void Update()
    {
        if (!isCounting && movement.HasStartedMoving)
        {
            isCounting = true;
        }

        if (isCounting)
        {
            elapsedTime += Time.deltaTime;

            changeTimer();
        }
    }

    private void changeTimer() //funcion que ve lo el tiempo
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);
        timer.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }


}
