using System.Text;
using TMPro;
using UnityEngine;

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
        // ������֖߂��i�󔒏����ρj
        var expression = SKICombinatorCalculator.TrimAllSpaces(inputTextbox.text);

        StringBuilder buf = new StringBuilder();
        buf.AppendLine(inputTextbox.text);

        if (inputTextbox.text != expression)
        {
            buf.AppendLine($@"    formatting {expression}");
        }

        Debug.Log("�v�Z�J�n");
        var text = SKICombinatorCalculator.Run(inputTextbox.text);
        buf.AppendLine($@"
--------

{text}
");
        outputTextbox.text = buf.ToString();
    }
}
