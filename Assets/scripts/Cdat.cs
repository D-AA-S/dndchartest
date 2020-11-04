using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cdat : MonoBehaviour
{
    [Serializable]
    public class Cstats
    {
        //armorprof
        public bool l_armor;
        public bool m_armor;
        public bool h_armor;
        public bool shield;

        //weaponprof
        public bool s_wep;
        public bool m_wep;
        public string[] exeption_wep;

        //skillsaveprof
        public bool strsav;
        public bool dexsav;
        public bool consav;
        public bool intsav;
        public bool wissav;
        public bool chasav;

        public string classname;

        public bool spellcheck;
        public List<string> spells;
    }

    public static Cdat instance;
    public Cstats Cl;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            Cl = new Cstats();
        }
    }
}
