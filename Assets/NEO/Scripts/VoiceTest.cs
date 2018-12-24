using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceTest : MonoBehaviour {

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> commands = new Dictionary<string, Action>();

    bool alreadyAsked;

    void Start()
    {
        commands.Add("how are you", hru);
        commands.Add("can you hear me", response);
        commands.Add("ignore me", Stop);

        keywordRecognizer = new KeywordRecognizer(commands.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += hasRecongnized;
        keywordRecognizer.Start();
    }

    void hasRecongnized(PhraseRecognizedEventArgs command)
    {
        Debug.Log(command.text);
        commands[command.text].Invoke();
    }

    void response()
    {
        Debug.Log("Loud and clear.");
    }

    void hru()
    {
        if (alreadyAsked)
        {
            Debug.Log("You already asked that!");
        }
        else
        {
            alreadyAsked = true;
            Debug.Log("I'm fine thank you!");
        }
    }

    void Stop()
    {
        keywordRecognizer.Stop();
    }

}
