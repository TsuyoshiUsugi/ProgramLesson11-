using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float horizontal, float vertical)
    {
        transform.position += _speed * Time.deltaTime * new Vector3(horizontal, vertical, 0);
        Turn(horizontal);
    }

    private void Turn(float horizontal)
    {
        if (horizontal > 0) transform.localScale = 
                new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (horizontal < 0) transform.localScale = 
                new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
