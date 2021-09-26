using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE {
    Beast = 0,
    Plant = 1,
    Dragon = 2
}

public enum PALLET {
    Red = 0,
    Green = 1,
    Blue = 2
}

public enum FLAG {
    None,
    Floof,
    Quit,
    Party,
    Work,
    BeastHead,
    PlantHead,
    DragonHead,
    BeastBod,
    PlantBod,
    DragonBod,
    Red,
    Green,
    Blue,
    Park,
    Home,
    FadeIn
}

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public int GRAY_THRESH = -3;
    public int COLOR_THRESH = 3;

    public float hueShift = 0.0f;
    public float saturation = 1.0f;
    public float shiftSpeed = 1.0f;
    public float hueLimit = 0.15f;

    //No Karens Allowed
    [SerializeField]
    public int alignment = 0;

    [SerializeField]
    public bool floofPic = false;
    [SerializeField]
    public bool quit = false;
    [SerializeField]
    public bool party = false;
    [SerializeField]
    public bool goToWork = false;

    [SerializeField]
    public TYPE head  = 0;
    [SerializeField]
    public TYPE body = 0;
    [SerializeField]
    public PALLET f_color = PALLET.Red;

    [SerializeField]
    public int progress = 0;

    [SerializeField]
    public Color blue1 = Color.blue,
        blue2 = Color.red,
        blue3 = new Color(200, 100, 10),
        blue4 = Color.yellow;

    public Color red1 = Color.blue,
        red2 = Color.red,
        red3 = new Color(200, 100, 10),
        red4 = Color.yellow;

    public Color green1 = Color.blue,
        green2 = Color.red,
        green3 = new Color(200, 100, 10),
        green4 = Color.yellow;


    public void StartGame() {
        alignment = 0;
        floofPic = false;
        quit = false;
        party = false;
        head = 0;
        body = 0;
        f_color = 0;
        progress = 0;
    }

    public void LoadGame(int align, bool hasPic, bool quitJob, bool goToParty, TYPE headType, TYPE bodyType, PALLET pallet, int progress) {
        alignment = 0;
        floofPic = false;
        quit = false;
        party = false;
        head = 0;
        body = 0;
        f_color = 0;
        progress = 0;
    }

    private void Update()
    {
        shiftSpeed = Mathf.Abs(shiftSpeed);

        //Alter global Saturation
        if (alignment < GRAY_THRESH)
        {
            if (saturation > 0.0f)
            {
                saturation -= Time.deltaTime * shiftSpeed;
                if (saturation < 0.0f)
                {
                    saturation = 0.0f;
                }
            }
        }
        else {
            if (saturation < 1.0f)
            {
                float SetSaturation = saturation + Time.deltaTime * shiftSpeed;
                if (SetSaturation >= 1.0f)
                {
                    saturation = 1.0f;
                }
                else {
                    saturation = SetSaturation;
                }
            }
        }

        //Alter Global Hues
        if (alignment > COLOR_THRESH)
        {
            if (hueShift < hueLimit) {
                hueShift += Time.deltaTime * shiftSpeed ;
                if (hueShift > hueLimit) {
                    hueShift = hueLimit;
                }
            }
        }
        else
        {
            if (hueShift > 0.0f) {
                hueShift -= Time.deltaTime * shiftSpeed ;
                if (hueShift < 0.0f) {
                    hueShift = 0.0f;
                }
            }
        }
    }

    private void Awake()
    {
        //Set Singleton
        if (GM == null)
        {
            GM = this;
            Object.DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
    }

    public void TriggerFlag(FLAG flag) {
        switch (flag) {
            case FLAG.Floof:
                if (!floofPic)
                {
                    floofPic = true;
                }
                else {
                    floofPic = false;
                }
                break;
            case FLAG.Party:
                if (!party)
                {
                    party = true;
                }
                else
                {
                    party = false;
                }
                break;
            case FLAG.Quit:
                if (!quit)
                {
                    quit = true;
                }
                else
                {
                    quit = false;
                }
                break;
            case FLAG.Work:
                if (!goToWork)
                {
                    goToWork = true;
                }
                else
                {
                    goToWork = false;
                }
                break;
            case FLAG.BeastBod:
                body = TYPE.Beast;
                break;
            case FLAG.DragonBod:
                body = TYPE.Dragon;
                break;
            case FLAG.PlantBod:
                body = TYPE.Plant;
                break;
            case FLAG.BeastHead:
                head = TYPE.Beast;
                break;
            case FLAG.DragonHead:
                head = TYPE.Dragon;
                break;
            case FLAG.PlantHead:
                head = TYPE.Plant;
                break;
            case FLAG.Red:
                f_color = PALLET.Red;
                break;
            case FLAG.Blue:
                f_color = PALLET.Blue;
                break;
            case FLAG.Green:
                f_color = PALLET.Green;
                break;
            case FLAG.FadeIn:
                FindObjectOfType<ImaginaryFriend>()?.StartFadeIn() ;
                break;
        }
    }
}
