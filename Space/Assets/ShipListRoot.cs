using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipListRoot : MonoBehaviour
{
    private int nNowIndex;
    private int nPrevIndex;
    public List<int> xPos = new List<int>();
    public GameObject objDisplayShip;

    public Button btnNext;
    public Button btnPrev;

    public float speed;

    public Vector3 vFrom;
    public Vector3 vTo;

    public bool bIsMove;

    private void Start()
    {

        btnNext.onClick.AddListener(() =>OnTouchBTNNext());
        btnPrev.onClick.AddListener(()=>OnTouchBTNPrev());

        StartView();
    }

    void OnTouchBTNNext()
    {
        if (bIsMove)
            return;

        nPrevIndex = nNowIndex;

        if(xPos.Count <= nNowIndex + 1)
        {
            nNowIndex = 0;
        }
        else
        {
            nNowIndex++;
        }

        SetDisplayShipPos();
        SetActiveElement();
    }

    public void OnTouchBTNPrev()
    {
        if (bIsMove)
            return;

        nPrevIndex = nNowIndex;
        
        if ( nNowIndex - 1< 0)
        {
            nNowIndex = xPos.Count -1;
        }
        else
        {
            nNowIndex--;
        }

        SetDisplayShipPos();
        SetActiveElement();
    }

    void SetDisplayShipPos()
    {
        vFrom = new Vector3(xPos[nPrevIndex], objDisplayShip.transform.position.y, objDisplayShip.transform.position.z);
        vTo = new Vector3(xPos[nNowIndex], objDisplayShip.transform.position.y, objDisplayShip.transform.position.z);

        Debug.Log(vFrom);
        Debug.Log(vTo);

        StartCoroutine(GoMovement());
    }

    void SetActiveElement()
    {
        for(int i=0;i<listShipViewElement.Count;i++)
        {
            if(i == nNowIndex)
            {
                listShipViewElement[i].SetActive();
            }
            else
            {
                listShipViewElement[i].SetDeActive();
            }
        }
    }

    IEnumerator GoMovement()
    {
        yield return new WaitUntil(() =>
        {
            if(Vector3.Distance(objDisplayShip.transform.position, vTo) < 0.1f)
            {
                bIsMove = false;
                return true;
            }
            else
            {
                bIsMove = true;
                objDisplayShip.transform.position = Vector3.Lerp(objDisplayShip.transform.position, vTo, speed * Time.deltaTime);
                return false;
            }
        });
    }


    public List<ShipViewElement> listShipViewElement = new List<ShipViewElement>();
    public void SetObject()
    {

    }

    public void StartView()
    {
        for(int i=0;i<ShipContainer.Ship.listShipData.Count;i++)
        {
            listShipViewElement[i].SetUI(ShipContainer.Ship.listShipData[i], UpdateShip);
            listShipViewElement[i].SetEnable(true);
        }

        for(int i=ShipContainer.Ship.listShipData.Count ;i <listShipViewElement.Count;i++)
        {
            listShipViewElement[i].SetEnable(false);
        }
    }

    void UpdateShip()
    {

    }
}
