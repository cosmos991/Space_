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
    }

    public void OnTouchBTNPrev()
    {
        Debug.Log("?");
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
    }

    void SetDisplayShipPos()
    {
        vFrom = new Vector3(xPos[nPrevIndex], objDisplayShip.transform.position.y, objDisplayShip.transform.position.z);
        vTo = new Vector3(xPos[nNowIndex], objDisplayShip.transform.position.y, objDisplayShip.transform.position.z);

        Debug.Log(vFrom);
        Debug.Log(vTo);

        StartCoroutine(GoMovement());
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


}
