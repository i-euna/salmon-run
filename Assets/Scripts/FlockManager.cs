using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 myPosition;
    int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        //float angle = Random.Range(0, 2 * Mathf.PI);
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = getPosition();
        myPosition = transform.position;
        float angle = Mathf.Atan2(myPosition.y - mousePos.y, myPosition.x - mousePos.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    Vector2 getPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
