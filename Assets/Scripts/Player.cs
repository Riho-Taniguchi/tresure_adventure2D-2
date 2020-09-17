using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 4.0f;
    Rigidbody2D rb;
    Camera Camera;
    public GameObject Col;
    Hud UIScript;
    Animator anim;
    int rightAnim, standRightAnim;
    AnimatorStateInfo stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Camera = GameObject.Find("Camera").GetComponent<Camera>();
        UIScript = GameObject.Find("Canvas").GetComponent<Hud>();
        rightAnim = Animator.StringToHash("Base Layer.Right");
        standRightAnim = Animator.StringToHash("Base Layer.StandRight");
    }

    // Update is called once per frame
    void Update()
    {
        // 矢印キーの入力情報を取得
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        // 移動する向きを作成する
        Vector2 direction = new Vector2(h, v).normalized;

        // 移動する向きとスピードを代入 
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        transform.position = new Vector2 (Mathf.Clamp(transform.position.x, -10.13f, 10.13f),
                Mathf.Clamp(transform.position.y, -10.0f, 10.0f));
        Camera.transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -6.0f, 6.0f),
                Mathf.Clamp(transform.position.y, -7.5f, 7.5f), -5.0f);

        if (h > 0) anim.SetBool("right", true);
        else anim.SetBool("right", false);
        
        if (h < 0) anim.SetBool("left", true);
        else anim.SetBool("left", false);
        
        if (v > 0) anim.SetBool("up", true);
        else anim.SetBool("up", false);

        if (v < 0) anim.SetBool("down", true);
        else anim.SetBool("down", false);

        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash == rightAnim || stateInfo.fullPathHash == standRightAnim)
            transform.localScale = new Vector3 (-1, 1, 1);
        else transform.localScale = new Vector3 (1, 1, 1);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            Col = other.gameObject;
            UIScript.Open.gameObject.SetActive (true);
        }
    }

    void OnCollisionExit2D (Collision2D other)
    {
        UIScript.Open.gameObject.SetActive (false);
    }
}
