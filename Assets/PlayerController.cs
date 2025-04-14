using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    PlayerInput input;
    public AnimationCurve curve;
    public List<Transform> playerRows;

    Vector3 startingPosition;

    int currentRow;

    bool canMove = true, isMoving = false;
    // Start is called before the first frame update
    Action ResetPlayer;

    void OnEnable()
    {
        GameManager.StartGame += OnGameStart;
        GameManager.GameOver += OnDeath;
        ResetPlayer += ResetPlayerPosition;
    }
    void OnDisable()
    {
        GameManager.StartGame -= OnGameStart;
        GameManager.GameOver -= OnDeath;
        ResetPlayer -= ResetPlayerPosition;
    }

    private void OnGameStart()
    {
        //startingPosition = transform.position;
        LeanTween.move(gameObject, playerRows[currentRow].position, 1f).setDelay(1f).setEase(curve);
    }


    public void OnDeath()
    {
        LeanTween.move(gameObject, transform.position + (Vector3.down * 10), 2f).setEaseOutBounce().setOnComplete(ResetPlayerPosition);

    }
    void ResetPlayerPosition()
    {
        transform.position = startingPosition;
    }

    void Start()
    {
        startingPosition = transform.position;
        currentRow = 1;
        input = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {

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
                    canMove = false;
                    LeanTween.move(gameObject, playerRows[currentRow].position, 1).setOnComplete(CompleteMove);
                }
            }
        }
    }

    void CompleteMove()
    {
        canMove = true;
    }

}
