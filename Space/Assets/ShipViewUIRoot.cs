using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipViewUIRoot : MonoBehaviour
{
    ShipListRoot shipListController;
    // Start is called before the first frame update
   private void Awake() 
   {
        for(int i=0;i<2;i++)
        {
            Ship_Data temp = new Ship_Data();

            temp.id = i;
            temp.MaxRoom = 3;
            temp.name = string.Format("Ship_{0}", i);
            

            ShipContainer.Ship.listShipData.Add(temp);
        }
    
   }
}
