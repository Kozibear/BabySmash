using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour
{

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode screamKey;
    private SpriteRenderer sr;
    private Animator Anim;
    private bool isJumping;
    private bool isStunned;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int key1 = 0;
        int key2 = 0;
        isJumping = GetComponentInParent<Player>().isJumping;
        isStunned = GetComponentInParent<Player>().isStunned;

        if (!isStunned)
        {
            if (Input.GetKey(leftKey))
            {
                sr.flipX = true;
            }
            if (Input.GetKey(rightKey))
            {
                sr.flipX = false;
            }
        }


        if (Input.GetKeyDown(screamKey))
        {
            Anim.SetBool("isScreaming", true);
        }

        if (Input.GetKeyUp(screamKey))
        {
            Anim.SetBool("isScreaming", false);
        }

        if (isJumping)
        {
            Anim.SetBool("isJumping", true);
        }
        else if (!isJumping)
        {
            Anim.SetBool("isJumping", false);
        }

        if (isStunned)
        {
            Anim.SetBool("isStunned", true);
        }
        else if (!isStunned)
        {
            Anim.SetBool("isStunned", false);
        }

        //if (Anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "P1ScreamAnim"|| Anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "P2ScreamAnim")
        //{
        //    transform.position = transform.position + new Vector3(0, -1, 0);
        //}

    }
}
