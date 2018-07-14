using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abschlussspiel : MonoBehaviour {
    public GameObject falsch;
    public GameObject richtig;
    public InputField input1;
    public InputField input2;
    public InputField input3;
    public InputField input4;
    public InputField input5;
    public InputField input6;
    public InputField input7;
    public InputField input8;
    public InputField input9;
    public InputField input10;
    public InputField input11;
    public InputField input12;
    public List<string> essen;
    public List<string> haus;
    public List<string> kleidung;
    public List<string> tiere;
    public List<InputField> inputList;
    public List<bool> aL, bL, cL, dL;
    public bool a, b, c, d;

    // Use this for initialization
    void Start()
    {
        falsch.GetComponent<Renderer>().enabled = false;
        richtig.GetComponent<Renderer>().enabled = false;
        essen = new List<string>(new string[]{ "grapes", "carrot", "onion", "lemon", "orange", "strawberry", "tomato", "cucumber", "pepper", "lettuce", "noodles", "rice", "salt", "sugar", "cake", "flour", "butter", "milk", "bread", "sausage", "cheese", "juice", "pineapple", "fruit", "food", "oil", "vinegar", "sauce", "potato", "banana", "apple", "melon", "cherry" });
         haus = new List<string>(new string[] { "kitchen", "bathroom", "living room", "cupboard", "chair", "bed", "couch", "blanket", "pillow", "bed sheet", "bedroom", "window", "door", "floor", "basement", "toilette", "sink", "lamp", "carpet", "bathtub", "shelf", "mirror" });
         kleidung = new List<string>(new string[] { "skirt", "trousers", "shoes", "socks", "underwear", "jacket", "hat", "scarf", "dress", "pullover", "coat" });
        tiere = new List<string>(new string[] { "monkey", "fish", "elephant", "dog", "cat", "horse", "bear", "giraffe", "panda", "crocodile", "hippo", "bird", "turtle", "pig", "chicken", "turkey", "spider", "fly", "guinea pig", "rabbit", "lion", "donkey", "jellyfish", "shark", "whale", "crab", "eagle", "tiger", "dolphin", "penguin", "mouse", "cow", "sheep", "duck" });
        inputList = new List<InputField>(new InputField[] { input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, input11, input12 });
        aL = new List<bool>(new bool[] { false, false, false });
        bL = new List<bool>(new bool[] { false, false, false });
        cL = new List<bool>(new bool[] { false, false, false });
        dL = new List<bool>(new bool[] { false, false, false });
}
   
    public void onClick()
    {
        for(int i = 0; i< 3;i++)
        {
            aL[i] = false;
        }
        for (int i = 0; i < 3; i++)
        {
            bL[i] = false;
        }
        for (int i = 0; i < 3; i++)
        {
            cL[i] = false;
        }
        for (int i = 0; i < 3; i++)
        {
            dL[i] = false;
        }

        a = true;
        b = true;
        c = true;
        d = true;

        for (int i = 0; i < 12; i++)
        {
            if (i < 3)
            {
                foreach (string e in essen)
                {
                    if (inputList[i].GetComponent<InputField>().text == e 
                        &&!(inputList[i].GetComponent<InputField>().text == inputList[i+1].GetComponent<InputField>().text) 
                        &&!(inputList[i].GetComponent<InputField>().text == inputList[i+2].GetComponent<InputField>().text)
                        &&!(inputList[i+1].GetComponent<InputField>().text == inputList[i+2].GetComponent<InputField>().text))
                    {
                        inputList[i].GetComponent<Image>().color = Color.green;
                        aL[i] = true;
                        break;
                    }
                    else
                    {
                        inputList[i].GetComponent<Image>().color = Color.red;
                        Debug.Log("ERROR a");
                    }           
                }
            }

            if (i >= 3 && i < 6)
            {
                foreach (string t in tiere)
                {
                    if (inputList[i].GetComponent<InputField>().text == t
                        && !(inputList[i].GetComponent<InputField>().text == inputList[i + 1].GetComponent<InputField>().text)
                        && !(inputList[i].GetComponent<InputField>().text == inputList[i + 2].GetComponent<InputField>().text)
                        && !(inputList[i + 1].GetComponent<InputField>().text == inputList[i + 2].GetComponent<InputField>().text)
                    )
                    {
                        inputList[i].GetComponent<Image>().color = Color.green;
                        bL[i-3] = true;
                        break;
                    }
                    else
                    {
                        inputList[i].GetComponent<Image>().color = Color.red;
                        Debug.Log("ERROR b");
                    }
                }              
            }
            if (i >= 6 && i < 9)
            {
                foreach (string k in kleidung)
                {
                    if (inputList[i].GetComponent<InputField>().text == k
                        && !(inputList[i].GetComponent<InputField>().text == inputList[i + 1].GetComponent<InputField>().text)
                        && !(inputList[i].GetComponent<InputField>().text == inputList[i + 2].GetComponent<InputField>().text)
                        && !(inputList[i + 1].GetComponent<InputField>().text == inputList[i + 2].GetComponent<InputField>().text)
                    )
                    {
                        inputList[i].GetComponent<Image>().color = Color.green;
                        cL[i - 6] = true;
                        break;
                    }
                    else
                    {
                        inputList[i].GetComponent<Image>().color = Color.red;
                    }
                }
            }
            if (i >= 9 && i < 12)
            {
                foreach (string h in haus)
                {
                    if (inputList[i].GetComponent<InputField>().text == h
                        && !(inputList[9].GetComponent<InputField>().text == inputList[10].GetComponent<InputField>().text)
                        && !(inputList[9].GetComponent<InputField>().text == inputList[11].GetComponent<InputField>().text)
                        && !(inputList[10].GetComponent<InputField>().text == inputList[11].GetComponent<InputField>().text)
                    )
                    {
                        dL[i - 9] = true;
                        inputList[i].GetComponent<Image>().color = Color.green;
                        break;
                    }
                    else
                    {
                        inputList[i].GetComponent<Image>().color = Color.red;
                    }
                }
            }
     
        }
        foreach(bool ax in aL)
        {
            if(ax == false)
            {
                a = false;
            }
        }
        foreach (bool bx in bL)
        {
            if (bx == false)
            {
                b = false;
            }
        }
        foreach (bool cx in cL)
        {
            if (cx == false)
            {
                c = false;
            }
        }
        foreach (bool dx in dL)
        {
            if (dx == false)
            {
                d = false;
            }
        }
        if (a == true && b == true && c == true && d == true)
        {
            falsch.GetComponent<Renderer>().enabled = false;
            richtig.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            falsch.GetComponent<Renderer>().enabled = true;
            richtig.GetComponent<Renderer>().enabled = false;
        }
    }
    
}
