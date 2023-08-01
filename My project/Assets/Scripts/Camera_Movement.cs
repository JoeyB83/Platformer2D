using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField] Transform playerFollow;
    [SerializeField] Vector2 horizontal;
    [SerializeField] float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 finalPos = playerFollow.position;
        finalPos.x = Mathf.Clamp(finalPos.x, horizontal.x, horizontal.y);
        finalPos.y = transform.position.y;
        finalPos.z = transform.position.z;
        
        transform.position = Vector3.MoveTowards(transform.position, finalPos, followSpeed * Time.deltaTime);
        
    }
}
