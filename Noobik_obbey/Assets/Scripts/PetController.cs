using UnityEngine;

public class PetController : MonoBehaviour
{
    public Transform playerHead; // Ссылка на голову персонажа
    public Transform petHolder; // Ссылка на PetHolder
    public Transform cameraTransform; // Ссылка на камеру

    void Update()
    {
        if (playerHead != null && petHolder != null && cameraTransform != null)
        {
            // Позиционируем PetHolder рядом с головой персонажа
            //petHolder.position = playerHead.position + playerHead.up * 0.5f; // Настрой высоту по своему усмотрению

            // Вращаем PetHolder так, чтобы он смотрел в сторону камеры
            //petHolder.rotation = Quaternion.LookRotation(cameraTransform.forward, Vector3.up);
        }
    }
}
