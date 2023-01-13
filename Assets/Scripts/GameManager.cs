using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.SKICombinatorCalculus.Tree;

public class GameManager : MonoBehaviour
{
    private TMP_InputField inputTextbox;
    private TMP_InputField outputTextbox;

    // Start is called before the first frame update
    void Start()
    {
        inputTextbox = GameObject.Find("Input Textbox").GetComponent<TMP_InputField>();
        outputTextbox = GameObject.Find("Output Textbox").GetComponent<TMP_InputField>();

        // ���{��Ή��͑�ςȂ̂� ASCII �ɂ���
        inputTextbox.text = "S(K(SI))K x y";
        outputTextbox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        Debug.Log("�e�X�g�J�n");
        var workingTree = new WorkingTree(inputTextbox.text);
        Debug.Log($"�e�X�g�I��: {workingTree.ToString()}");

        Debug.Log("�v�Z�J�n");
        outputTextbox.text = SKICombinatorCalculator.Run(inputTextbox.text);
    }
}
