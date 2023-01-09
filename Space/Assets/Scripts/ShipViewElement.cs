using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipViewElement : MonoBehaviour
{
    // Start is called before the first frame update
    Button btnClick
    {
        get{
            return GetComponent<Button>();
        }
    }
    GameObject objActive
    {
        get{
            Debug.Log(transform.GetChild(1).gameObject.name);
            return transform.GetChild(1).gameObject;
        }
    }

    GameObject objDisAble
    {
        get{
            return transform.GetChild(3).gameObject;
        }
    }
    // Start is called before the first frame update
    public void SetUI(Ship_Data data, System.Action callbackMethod)
    {



        btnClick.onClick.AddListener(()=> callbackMethod());
    }

    public void SetActive()
    {
        objActive.SetActive(true);
    }
    
    public void SetDeActive()
    {
        objActive.SetActive(false);
    }

    public void SetEnable(bool bIsActive)
    {
        objDisAble.SetActive(!bIsActive);
    }
}
