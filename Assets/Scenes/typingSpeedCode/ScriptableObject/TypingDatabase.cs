using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


[Serializable]
public struct DBWord
{
    public string[] good;
    public string[] bad;
}


[CreateAssetMenu(menuName = "TypingDB", fileName = "TypingDatabaseWord")]
public class TypingDatabase : ScriptableObject
{
    [SerializeField]
    public List<DBWord> dBWords = new List<DBWord>();
    public int level;
}

