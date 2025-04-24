using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


[Serializable]
public struct correctListNum
{
    public string[] correctwords;
    public string[] badwords;
    public string[] respondCorrectWords;
}

[Serializable]
public struct SentenceWithDiagNPC
{
    public string npcDiag;
    public string sentenceToComplete;
}
public class sentencemanager : MonoBehaviour
{

    public List<SentenceWithDiagNPC> sentenceTemp =new List<SentenceWithDiagNPC>();
    public List<char[]> sentenceWithBlank = new List<char[]>();
    public List<correctListNum> correctWords = new List<correctListNum>();
    private bool isCorrect;
    public TMP_Text uncompleteSentence;
    public TMP_Text NPCDiag;
    public TMP_Text NPCReply;
    // for count index per kalimat dalam list pada tiap soal.
    private int Counter = 0;
    // for what? ya buat nge track blank spot nya di index mana aja!
    private List<int> letterPos = new List<int>();

    void OnEnable()
    {
        CodeManagerKeyboard.OnClickKeyBoard += ProcessKeyBoardFill;
        CodeManagerKeyboard.OnClickBackSpace += ProcessKeyBoardDelete;
    }
    void OnDisable()
    {
        CodeManagerKeyboard.OnClickKeyBoard -= ProcessKeyBoardFill;
        CodeManagerKeyboard.OnClickBackSpace -= ProcessKeyBoardDelete;
    }
    // Start is called before the first frame update
    void Start()
    {
        // just convert from temp memory sentence because unity cant serialize char array
        for(int i = 0; i < sentenceTemp.Count; i++)
        {
            sentenceWithBlank.Add(sentenceTemp[i].sentenceToComplete.ToCharArray());
        }

        // set init sentences word with blank to guess.
        processWord(sentenceWithBlank[Counter]);
    }


    // Update is called once per frame
    void Update()
    {
        if(isCorrect)
        {
           processWord(sentenceWithBlank[Counter]);
        }
    }

    void processWord(char[] sentence)
    {
            // load npc cases diag
            NPCDiag.text = sentenceTemp[Counter].npcDiag;
            // load do next sentence.
            uncompleteSentence.SetCharArray(sentence);
            // check blank space index.
            for(int i =0; i < sentenceWithBlank[Counter].Length; i++)
            {
                if(sentenceWithBlank[Counter][i] == '_')
                {
                    // save '_' index to int array
                    // Debug.Log(i);
                    letterPos.Add(i);
                }
            }
    }

    int counterProcess = 0;
    void ProcessKeyBoardFill(string s)
    {
        if(counterProcess < letterPos.Count){
             // replace _ with s 
            sentenceWithBlank[Counter][letterPos[counterProcess]] = s[0];
            // set to TMPTEXT TO DISPLAY
            uncompleteSentence.SetCharArray(sentenceWithBlank[Counter]);
            counterProcess++;
        }
        if(counterProcess == letterPos.Count)
        {
            // set the last only white space letterpos for s[0].
            sentenceWithBlank[Counter][letterPos[counterProcess-1]] = s[0];
            // again, we just set it to uncompletesentence with no increase counterProcess
            uncompleteSentence.SetCharArray(sentenceWithBlank[Counter]);
        }
        // Debug.Log(counterProcess);
    }
    void ProcessKeyBoardDelete()
    {
        if(counterProcess > 0)
        {
             // decrease pointer
            counterProcess = counterProcess-1;
            // set to '_' again.
            sentenceWithBlank[Counter][letterPos[counterProcess]] = '_';
            uncompleteSentence.SetCharArray(sentenceWithBlank[Counter]);
            // decrease pointer counterProcess
        }
    }

    public void verify()
    {
        // grab correctWords
        string correctAns = correctWords[Counter].respondCorrectWords[0];

        // compare two string and checking.
        isCorrect = correctWords[Counter].correctwords[0].Equals(uncompleteSentence.text.Substring(letterPos[0],letterPos.Count));
        if(isCorrect)
        {
            Debug.Log("tes");
            // Show reply NPC
            NPCReply.text = correctAns;
            // increase counter for level.
            // Counter++;
        }
        
    }
}
