using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SHADES {
    Black0 = 0,
    Gray1 = 51,
    Gray2 = 99,
    Gray3 = 153,
    Gray4 = 204,
    White5 = 255
}

public class PaletteSwap : MonoBehaviour
{
    Texture2D mColorSwapTex;
    Color[] mSpriteColors;
    [SerializeField]
    Color target1 = Color.blue,
        target2 = Color.red,
        target3 = new Color(200, 100, 10), 
        target4 = Color.yellow;

    public void InitColorSwapTex()
    {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;
        for (int i = 0; i < colorSwapTex.width; ++i)
            colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));

        colorSwapTex.Apply();

        GetComponent<SpriteRenderer>().material.SetTexture("_SwapTex", colorSwapTex);

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }

    public void SwapColor(SHADES index, Color color)
    {
        mSpriteColors[(int)index] = color;
        mColorSwapTex.SetPixel((int)index, 0, color);
    }

    void SwapColors() {
        SwapColor(SHADES.Gray1, target1);
        SwapColor(SHADES.Gray2, target2);
        SwapColor(SHADES.Gray3, target3);
        SwapColor(SHADES.Gray4, target4);
        mColorSwapTex.Apply();
    }

    // Start is called before the first frame update
    void Awake()
    {
        InitColorSwapTex();
        
    }

    // Update is called once per frame
    void Update()
    {
        SwapColors();
    }
}
