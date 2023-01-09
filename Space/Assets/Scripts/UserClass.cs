using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClass
{
    
}

public class Room_Data
{
    public string name;
    public int id;

    public ROOM_TYPE roomType;

    public void InitData()
    {
        // 현재 활동 초기화 
    }


}

public class Crew_Data
{

}


public class Ship_Data
{
    public int id;
    public string name;
    public List<Room_Data> room_data = new List<Room_Data>();
    public List<Crew_Data> crew_data = new List<Crew_Data>();

    public int MaxRoom;

    public void InitData()
    {
        
    }
}
