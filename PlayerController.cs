using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Transform tr;
    CharacterController contr;
    bool isGround = true;
    private Vector3 velocity;
    public float sensitivity = 2.5f;
    public float Speed = 8f;
    public float Jump = 8f;
    public float Gravity = -9.8f;
    [SerializeField] TextMeshProUGUI ScoreText;
    static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        contr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 move = tr.right * horizontal + tr.forward * vertical;

        contr.Move(move * Speed * Time.deltaTime);

        tr.Rotate(0,mouseX,0);

        if(Input.GetKeyDown("space")&& isGround==true){
            velocity.y = Jump;
            isGround = false;
        }
        else{
            velocity.y += Gravity * Time.deltaTime;
        }
        contr.Move(velocity*Time.deltaTime);
    }
    void OnControllerColliderHit(ControllerColliderHit arg) {
        if(arg.gameObject.tag=="ground"){
            isGround = true;
        }
    }
    void OnCollisionEnter(Collision arg) {
        if(arg.gameObject.tag=="Item"){
            Destroy(arg.gameObject);
            score +=1;
            print(score);
            ScoreText.text = score+"";
        }
        if(score==9){
        }
    }
}
