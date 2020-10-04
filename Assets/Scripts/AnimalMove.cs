using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    Vector3 originalPosition;
    public float moveRadius = 0.5f;
    public bool faceLeft = false;
    Vector3 moveDirection;
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        SetMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, originalPosition) >= moveRadius){
            SetMoveDirection();
        }
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void SetMoveDirection(){
        moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        while(moveDirection.magnitude < 0.1f || Vector3.Distance(transform.position + moveDirection * 0.1f, originalPosition) >= moveRadius){
            moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        }
        if(moveDirection.x >= 0){
            if(faceLeft){
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else{
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else{
            if(faceLeft){
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else{
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
