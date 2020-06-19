using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public List<Texture2D> textures;

    GameSetting gameSetting;
    Material bubbleMaterial;

    void Start()
    {
        gameSetting = FindObjectOfType<GameSetting>();
        bubbleMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        int status = Mathf.Clamp(gameSetting.status, 0, textures.Count-1);
        Texture2D currentTexture = textures[status];

        bubbleMaterial.SetTexture("_MainTex", currentTexture);
    }
}
