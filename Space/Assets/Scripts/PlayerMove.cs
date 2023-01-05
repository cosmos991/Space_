using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Player ActionPlayer = null;
    public GameObject objPlayerRoot;
    public Vector2 v2InputVector;
    public float fSpeed = 0.1f;
    public float fDamp = 1f;
    public bool bIsPress = false;
    // Start is called before the first frame update
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (ActionPlayer == null)
            ActionPlayer = new Player();

        ActionPlayer.Player_Action.Move.performed += OnMove;
        ActionPlayer.Player_Action.Move.canceled += OnCancel;
        ActionPlayer.Enable();
    }

    private void OnDisable()
    {
        ActionPlayer.Player_Action.Move.performed -= OnMove;
        ActionPlayer.Player_Action.Move.canceled -= OnCancel;
        ActionPlayer.Disable();
    }

    private void FixedUpdate()
    {
        objPlayerRoot.transform.position = new Vector3(objPlayerRoot.transform.position.x + (fDamp * fSpeed * v2InputVector.x), 0, objPlayerRoot.transform.position.z + (fDamp * fSpeed * v2InputVector.y));

        if(bIsPress)
        {
           
        }
        else
        {
            if (fDamp > 0)
            {
                fDamp -= Time.deltaTime * 2.9f;
            }
            else
            {
                fDamp = 0;
            }
        }
       
    }

    void OnMove(InputAction.CallbackContext context)
    {
        v2InputVector = context.ReadValue<Vector2>();
        Debug.Log(v2InputVector);
        fDamp = 1f;
        bIsPress = true;
    }

    void OnCancel(InputAction.CallbackContext context)
    {
        Debug.Log("end");
        bIsPress = false;
    }


}
