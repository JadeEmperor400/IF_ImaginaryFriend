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
    public Color target1 = Color.blue,
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

    public Color fromColor(Color c) {
        return new Color(c.r, c.g, c.b, c.a);
    }

    public Color fromShade(SHADES shade) {
        return new Color((int)shade/255.0f, (int)shade / 255.0f, (int)shade / 255.0f);
    }

    protected virtual void SwapColors() {
        Color set1 = fromColor(target1),
            set2 = fromColor(target2),
            set3 = fromColor(target3),
            set4 = fromColor(target4);

        if (GameManager.GM != null) {

            if (GameManager.GM.alignment < GameManager.GM.GRAY_THRESH && GameManager.GM.saturation == 0) {
                set1 = fromShade(SHADES.Gray1);
                set2 = fromShade(SHADES.Gray2);
                set3 = fromShade(SHADES.Gray3);
                set4 = fromShade(SHADES.Gray4);
            }

            float h, s, v;
            Color.RGBToHSV(set1, out h, out s, out v);
            if (h > 1.0f || h < 0.0f) {
                h = h % 1.0f;
            }
            set1 = Color.HSVToRGB(h + GameManager.GM.hueShift,s * GameManager.GM.saturation, v);

            Color.RGBToHSV(set2, out h, out s, out v);
            if (h > 1.0f || h < 0.0f)
            {
                h = h % 1.0f;
            }

            set2 = Color.HSVToRGB(h + GameManager.GM.hueShift, s * GameManager.GM.saturation, v);

            Color.RGBToHSV(set3, out h, out s, out v);
            if (h > 1.0f || h < 0.0f)
            {
                h = h % 1.0f;
            }
            set3 = Color.HSVToRGB(h + GameManager.GM.hueShift, s * GameManager.GM.saturation, v);

            Color.RGBToHSV(set4, out h, out s, out v);
            if (h > 1.0f || h < 0.0f)
            {
                h = h % 1.0f;
            }
            set4 = Color.HSVToRGB(h + GameManager.GM.hueShift, s * GameManager.GM.saturation, v);



        }
        
        SwapColor(SHADES.Gray1, set1);
        SwapColor(SHADES.Gray2, set2);
        SwapColor(SHADES.Gray3, set3);
        SwapColor(SHADES.Gray4, set4);
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
