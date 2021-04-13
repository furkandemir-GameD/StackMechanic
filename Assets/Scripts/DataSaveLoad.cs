using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataSaveLoad
{
    private static int topLevel;

    public static int TopLevel
    {
        get
        {
            try
            {
                return PlayerPrefs.GetInt("topLevel", 0);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        set
        {
            try
            {
                PlayerPrefs.SetInt("topLevel", value);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    private static int initialLevel;

    public static int InitialLevel
    {
        get
        {
            try
            {
                while (PlayerPrefs.GetInt("initialLevel", 0) > 6)
                {
                    int bufLevel = PlayerPrefs.GetInt("initialLevel", 0);
                    bufLevel = bufLevel - 7;
                    PlayerPrefs.SetInt("initialLevel", bufLevel);
                }

                return PlayerPrefs.GetInt("initialLevel", 0);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        set
        {
            try
            {
                PlayerPrefs.SetInt("initialLevel", value);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }



}
