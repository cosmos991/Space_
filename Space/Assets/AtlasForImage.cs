using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class AtlasForImage : MonoBehaviour
{
    [SerializeField] SpriteAtlas atlas;
    [SerializeField] string spriteName;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = atlas.GetSprite(GetComponent<Image>().sprite.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
