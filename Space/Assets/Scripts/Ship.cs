using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int id;
    public string name;
    public List<Crew> listActiveCrew = new List<Crew>();
    public List<Room> listActiveRoom = new List<Room>();

    public GameObject objShipRoot;

    public int MaxRoom;

    public List<Room_Data> room_data = new List<Room_Data>();

    private void Start()
    {
        //RoomInit
        TestData();
        InitRoom();
    }

    void TestData()
    {
        if(id == 0)
        {
            MaxRoom = 3;

            Room_Data temp = new Room_Data();

            temp.id = 0;
            temp.name= "weapon_room";
            temp.roomType = ROOM_TYPE.WEAPON_ROOM;

            room_data.Add(temp);

            Room_Data temp_1 = new Room_Data();

            temp.id = 1;
            temp.name= "weapon_room";
            temp.roomType = ROOM_TYPE.WEAPON_ROOM;

            room_data.Add(temp_1);

            Room_Data temp_2 = new Room_Data();

            temp.id = 3;
            temp.name= "medical_room";
            temp.roomType = ROOM_TYPE.MEDICAL_ROOM;

            room_data.Add(temp_2);
        }
    }

    void InitRoom()
    {
        for(int i=0;i<room_data.Count;i++)
        {
            room_data[i].InitData();
        }
    }

    public void SetData(Ship_Data data)
    {

    }
}
