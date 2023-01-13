using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.SKICombinatorCalculus.Tree;
using System.Text;

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
        // �؍\���֕ϊ�
        var workingTree = new WorkingTree(inputTextbox.text);

        // ������֖߂��i�󔒏����ρj
        var expression = workingTree.ToString();

        StringBuilder buf = new StringBuilder();
        buf.AppendLine(inputTextbox.text);

        if (inputTextbox.text != expression)
        {
            buf.AppendLine($@"    formatting {expression}");
        }

        Debug.Log("�،v�Z�J�n");
        var text = SKICombinatorCalculator.Run(workingTree);
        buf.AppendLine($@"
{text}
");
        outputTextbox.text = buf.ToString();
    }
}
