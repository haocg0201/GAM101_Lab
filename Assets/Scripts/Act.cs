using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Act : MonoBehaviour
{
    public float move;
    public float speed = 5;
    public bool isFacingLeft = false;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");  //Axis thì nó có gia tốc, sẽ trượt thêm 1 tí còn AxisRaw thì sẽ dừng lại luôn
        rigidbody2D.velocity = new Vector2(speed*move,rigidbody2D.velocity.y);
        if(!isFacingLeft && move == -1){
            transform.localScale = new Vector3(-1,1,1);
            isFacingLeft = true;
        }

        if(isFacingLeft && move == 1){
            transform.localScale = new Vector3(1,1,1);
            isFacingLeft = false;
        }
        // chuyển trạng thái của actor
        animator.SetFloat("move",Mathf.Abs(move)); // move : tên biến

        if(Input.GetKey(KeyCode.Space)){
            rigidbody2D.velocity  = new Vector2(transform.localScale.x,speed);
        }





        // if(Input.GetKey(KeyCode.A))
        // {
        //     move = -1;
        // }else if(Input.GetKey(KeyCode.D))
        // {
        //     move = 1;
        // }else move = 0;
        // transform.Translate(Vector3.right*speed*move*Time.deltaTime); // * với deltaTime để nó không quá nhanh hoặc quá chậm tùy thuộc vào loại máy
    }
}
