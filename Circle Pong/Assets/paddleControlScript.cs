using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float RotateSpeed = 5f;
    private float Radius = 5f;

    private Vector2 _centre;
    private float _angle = 0;
    public float startAngle;

    public KeyCode upKey;
    public KeyCode downKey;
    private void Start()
    {
        _angle = startAngle;
        _centre = new Vector2(0, 0);
    }

    private void Update()
    {

        if (Input.GetKey(upKey))
        {
            _angle += RotateSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(downKey))
        {
            _angle -= RotateSpeed * Time.deltaTime;
        }
        else
        {
            _angle = _angle;
        }

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
        transform.right = new Vector3(0, 0,0) - transform.position;
    }
}
