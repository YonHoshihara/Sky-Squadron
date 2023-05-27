using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float swipeThreshold = 50f;
    
    [SerializeField]
    private float swipeSpeedMultiplier = 5f;

    [SerializeField]
    private float applyVelocityTime = 1f;


    [SerializeField]
    private Rigidbody playerRb;
    
    private Vector2 startSwipePos;

    private bool isSwiping = false;

    private void Update()
    {
        // Verificar se o toque na tela começou
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startSwipePos = touch.position;
                isSwiping = true;
            }
            // Verificar se o toque foi liberado
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeDelta = touch.position - startSwipePos;

                // Verificar se o movimento do swipe atingiu o limiar mínimo
                if (swipeDelta.magnitude > swipeThreshold)
                {
                    // Determinar a direção do swipe
                    Vector2 swipeDirection = swipeDelta.normalized;

                    // Mover o objeto na direção do swipe
                    MoveObject(swipeDirection);
                }

                isSwiping = false;
            }
        }

        // Verificar se o clique do mouse começou
        if (Input.GetMouseButtonDown(0))
        {
            startSwipePos = Input.mousePosition;
            isSwiping = true;
        }
        // Verificar se o clique do mouse foi solto
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 swipeDelta = (Vector2)Input.mousePosition - startSwipePos;

            // Verificar se o movimento do swipe atingiu o limiar mínimo
            if (swipeDelta.magnitude > swipeThreshold)
            {
                // Determinar a direção do swipe
                Vector2 swipeDirection = swipeDelta.normalized;

                // Mover o objeto na direção do swipe
                MoveObject(swipeDirection);
            }

            isSwiping = false;
        }
    }

    IEnumerator ResetVeclocityTimer(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        playerRb.velocity = Vector2.zero;
    }

    private void MoveObject(Vector2 direction)
    {
        // Calcular a velocidade do movimento
        Vector3 swipeVelocity = new Vector3(direction.x, 0f, 0) * swipeSpeedMultiplier;
        playerRb.velocity = swipeVelocity;
        StartCoroutine(ResetVeclocityTimer(applyVelocityTime));
    }
    
}
