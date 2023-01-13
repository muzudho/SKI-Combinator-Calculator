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

        // 日本語対応は大変なので ASCII にする
        inputTextbox.text = "S(K(SI))K x y";
        outputTextbox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        Debug.Log("テスト開始");
        var workingTree = new WorkingTree(inputTextbox.text);
        Debug.Log($"テスト終了: {workingTree.ToString()}");

        Debug.Log("計算開始");
        outputTextbox.text = SKICombinatorCalculator.Run(inputTextbox.text);
    }
}
