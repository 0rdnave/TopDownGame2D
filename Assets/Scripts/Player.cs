using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed = 8f;


    private Event e;


    private Rigidbody2D rig;

    private float inicialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        inicialSpeed = speed;
    }


    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();

        OnGUI();

    }

    void OnGUI()
    {
        e = Event.current;
        if (e.isKey || e.isMouse)
        {
            if (e.isKey)
            {
                Debug.Log("Detected key code: " + e.keyCode);
            }

            if (e.button == 0 && e.isMouse)
            {
                Debug.Log("Left Click");
            }
            else if (e.button == 1)
            {
                Debug.Log("Right Click");
            }
            else if (e.button == 2)
            {
                Debug.Log("Middle Click");
            }
            else if (e.button > 2)
            {
                Debug.Log("Another button in the mouse clicked");
            }
        }
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = inicialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            _isRolling = true;

        }
        if (Input.GetMouseButtonUp(1))
        {
            speed = inicialSpeed;
            _isRolling = false;
        }
    }

    #endregion
}
