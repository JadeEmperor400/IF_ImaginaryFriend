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
    Work
}

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

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
        }
    }
}
