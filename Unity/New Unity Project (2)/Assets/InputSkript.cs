using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSkript : MonoBehaviour {

    public InputField vocabField;
    public string vocab;

    public void Update()
    {
        vocab = vocabField.text;
        print(vocab);
    }
}
    
