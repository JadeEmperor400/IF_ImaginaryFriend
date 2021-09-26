using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImaginaryFriend : MonoBehaviour
{
    public SpriteRenderer headSprite;
    public SpriteRenderer bodySprite;
    public Animator headAnimator;
    public Animator bodyAnimator;
    public PaletteSwap paletteSwap1;
    public PaletteSwap paletteSwap2;

    public void setBuddy() {
        switch (GameManager.GM.f_color)
        {
            case PALLET.Green:
                paletteSwap1.target1 = GameManager.GM.green1;
                paletteSwap1.target2 = GameManager.GM.green2;
                paletteSwap1.target3 = GameManager.GM.green3;
                paletteSwap1.target4 = GameManager.GM.green4;
                paletteSwap2.target1 = GameManager.GM.green1;
                paletteSwap2.target2 = GameManager.GM.green2;
                paletteSwap2.target3 = GameManager.GM.green3;
                paletteSwap2.target4 = GameManager.GM.green4;
                break;
            case PALLET.Blue:
                paletteSwap1.target1 = GameManager.GM.blue1;
                paletteSwap1.target2 = GameManager.GM.blue2;
                paletteSwap1.target3 = GameManager.GM.blue3;
                paletteSwap1.target4 = GameManager.GM.blue4;
                paletteSwap2.target1 = GameManager.GM.blue1;
                paletteSwap2.target2 = GameManager.GM.blue2;
                paletteSwap2.target3 = GameManager.GM.blue3;
                paletteSwap2.target4 = GameManager.GM.blue4;
                break;
            default:
                paletteSwap1.target1 = GameManager.GM.red1;
                paletteSwap1.target2 = GameManager.GM.red2;
                paletteSwap1.target3 = GameManager.GM.red3;
                paletteSwap1.target4 = GameManager.GM.red4;
                paletteSwap2.target1 = GameManager.GM.red1;
                paletteSwap2.target2 = GameManager.GM.red2;
                paletteSwap2.target3 = GameManager.GM.red3;
                paletteSwap2.target4 = GameManager.GM.red4;
                break;
        }

        switch (GameManager.GM.body) {
            case TYPE.Plant:
                bodyAnimator.Play("PlantBody");
                break;
            case TYPE.Dragon:
                bodyAnimator.Play("DragonBody");
                break;
            default:
                bodyAnimator.Play("BeastBody");
                break;
        }

        switch (GameManager.GM.head)
        {
            case TYPE.Plant:
                headAnimator.Play("PlantHead");
                break;
            case TYPE.Dragon:
                headAnimator.Play("DragonHead");
                break;
            default:
                headAnimator.Play("BeastHead");
                break;
        }
    }

    void Awake()
    {
       // headSprite.color = Color.clear;
        //bodySprite.color = Color.clear;
    }

    // Start is called before the first frame update
    void Start()
    {
        


        
    }

    // Update is called once per frame
    void Update()
    {
        setBuddy();
    }

    public IEnumerator FadeIn() {

        yield break;
    }
}
