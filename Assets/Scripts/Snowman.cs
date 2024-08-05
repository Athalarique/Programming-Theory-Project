using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    private float m_jumpForce = 10;
    public float jumpForce // ENCAPSULATION
    {
        get { return m_jumpForce; }
        set { 
            if (value < 0) { Debug.LogError("Can't be negative"); }
            else m_jumpForce = value; 
        }
    }

    public bool isOnGround = true;

    public Rigidbody playerRb;

    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            jump();
        }
    }

    public virtual void jump() // ABSTRACTION
    {
        playerRb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
