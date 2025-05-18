using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speedMove;   // швидкість вперед
    [SerializeField] private float speedSide;   // швидкість вліво/вправо
    [SerializeField] private float gravity;   // гравітація 
    [SerializeField] private int lineToMove = 1;   // лінія по якій рухаємося
    [SerializeField] private float lineDistance;   // дистанція між лініями
    private CharacterController controller;   // контролер персонажа

    private void Start()
    {
        controller = GetComponent<CharacterController>();   // отримуємо контролер
    }

    private void Update()
    {
        Vector3 speed = new Vector3(0, gravity, speedMove);
        controller.Move(speed * Time.deltaTime);

        Vector3 targetPosition = new Vector3();
        targetPosition.z = transform.position.z;
        targetPosition.y = transform.position.y;
        targetPosition.x = 0;

        //   0    1    2
        // -lineD 0 +lineD
        if (lineToMove == 0)
        {
            targetPosition.x = -lineDistance;
        }
        else if (lineToMove == 2)
        {
            targetPosition.x = lineDistance;
        }

        transform.position = targetPosition;
    }


    public void MovementSide(bool isRight)
    {
        if (isRight && lineToMove < 2)
        {
            lineToMove += 1;
        }
        if (!isRight && lineToMove > 0)
        {
            lineToMove -= 1;
        }
    }

}
