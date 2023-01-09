using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipViewRoomElement : MonoBehaviour
{
    Button btnClick;
    // Start is called before the first frame update
    public void SetUI(Ship_Data data, System.Action callbackMethod)
    {



        btnClick.onClick.AddListener(()=> callbackMethod());
    }
}
