using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MemeGenerator : MonoBehaviour
{
    public TextAsset Text;
    private string[] SliceText;
    private WordArray wordArray;
    void Start()
    {
        wordArray = new WordArray();
        string [] Str;
        SliceText = Text.text.Split('\n');
        for (int i = 0; i < SliceText.Length; i++)
        {
            Str = SliceText[i].Split(",");
            wordArray.AddWord(Str[1], Str[0]);
        }
        //Debug.Log(wordArray.GetLeghtWords("Кто"));
        string A;
        int V;
        for (int i = 0;i < 10; i++)
        {
            V = UnityEngine.Random.Range(0, wordArray.GetLeghtWords("Кто") - 1);
            A = wordArray.GetWord("Кто", V) + " ";
            V = UnityEngine.Random.Range(0, wordArray.GetLeghtWords("ЧтоДелает") - 1);
            A += wordArray.GetWord("ЧтоДелает", V) + " ";
            V = UnityEngine.Random.Range(0, wordArray.GetLeghtWords("ЧтоДелая") - 1);
            A += wordArray.GetWord("ЧтоДелая", V) + " ";
            V = UnityEngine.Random.Range(0, wordArray.GetLeghtWords("Где") - 1);
            A += wordArray.GetWord("Где", V) + " ";

            Debug.Log(A);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private class WordArray {
        private List<List<string>> words;
        private List<string> types;
        public WordArray()
        {
            words = new List<List<string>>();
            types = new List<string>();
        }
        public void AddWord(string word, string type)
        {
            bool A = true;
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i] == type)
                {
                    A = false;
                    break;
                }
            }
            if (A)
            {
                types.Add(type);
                words.Add(new List<string>());
            }
            words[types.IndexOf(type)].Add(word);
        }
        public int GetLeghtWords( string Type ) { 
            bool A = true;
            for (int i = 0; i < types.Count; i++)
            {
                if (Type == types[i])
                {

                }
            }
            return words[types.IndexOf(Type)].Count; 
        }
        public int GetLegthTyps() { return types.Count; }
        public string GetWord(string Type, int Index ) { if (words[types.IndexOf(Type)].Count > Index) { return words[types.IndexOf(Type)][Index]; } Debug.Log("ERROR"); return null; }

    }


}
