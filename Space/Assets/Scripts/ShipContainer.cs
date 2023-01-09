using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipContainer
{
    // 1. 현재 선택한 함선이 뭔지
    // 2. 새롭게 선택한 함선이 뭔지
    // 3. 함선 선택 후 -> 게임 진입시 함선 객체 전달 및 초기화 관리

    private static ShipContainer _intance;
    public static ShipContainer Ship
    {
        get
        {
            if(_intance == null)
            {
                _intance = new ShipContainer();
            }
            return _intance;
        }
    }

    public Ship shipNowSelect;
    public List<Ship_Data> listShipData = new List<Ship_Data>();

}
