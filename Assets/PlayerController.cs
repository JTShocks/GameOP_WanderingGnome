using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    PlayerInput input;
    public AnimationCurve curve;
    public List<Transform> playerRows;

    int currentRow;

    bool canMove = true, isMoving = false;
    // Start is called before the first frame update

    void OnEnable()
    {
        GameManager.StartGame += OnGameStart;
    }

    private void OnGameStart()
    {
        LeanTween.move(gameObject, playerRows[currentRow].position, 1f).setEase(curve);
    }

    void Start()
    {
        currentRow = 1;
        input = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            canMove = false;
            transform.position = Vector3.MoveTowards(transform.position, playerRows[currentRow].position, 1 * Time.deltaTime);
            if(Mathf.Approximately(Vector3.Distance(transform.position, playerRows[currentRow].position), 0))
            {
                transform.position = playerRows[currentRow].position;
                isMoving = false;
                canMove = true;

            }
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            int newRow = currentRow;
            Vector2 inputValue = context.ReadValue<Vector2>();
            if(canMove)
            {
                newRow -= (int)inputValue.y;
                if(newRow >= 0 && newRow <= 2 )
                {
                    currentRow = newRow;
                    isMoving = true;
                }
            }
        }



    }
}
