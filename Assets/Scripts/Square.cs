using UnityEngine;
using TMPro;
using System.IO;

public class Square : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLine;
    string path = "Assets/File/name.txt";
    string sqName = "Greg";
    string color = "white";
    int newColor = 0;
    int oldColor = 0;
    int currColor = 0;
    bool hover = false;

    SpriteRenderer spriteRenderer;
    CommandInvoker cmdI;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;

        cmdI = new CommandInvoker();

        Rename();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && hover)
        {
            Recolor(currColor);

            Command colorCmd = new ColorCommand(this, oldColor, newColor);
            cmdI.ExecuteCommand(colorCmd);
        }
    }

    public void Rename()
    {
        sqName = new StreamReader(path).ReadToEnd();

        textLine.text = "This is " + sqName + ". " + sqName + " is " + color + ".";
    }

    public void SwapColorNum(int num)
    {
        currColor = num;
    }

    public void Recolor(int num)
    {
        currColor = num;
        oldColor = newColor;
        newColor = currColor;

        switch (num)
        {
            case 0:
                color = "white";
                spriteRenderer.color = Color.white;
                break;
            case 1:
                color = "red";
                spriteRenderer.color = Color.red;
                break;
            case 2:
                color = "blue";
                spriteRenderer.color = Color.blue;
                break;
            case 3:
                color = "yellow";
                spriteRenderer.color = Color.yellow;
                break;
            case 4:
                color = "green";
                spriteRenderer.color = Color.green;
                break;
            case 5:
                color = "magenta";
                spriteRenderer.color = Color.magenta;
                break;
            case 6:
                color = "cyan";
                spriteRenderer.color = Color.cyan;
                break;
            case 7:
                color = "black";
                spriteRenderer.color = Color.black;
                break;
            default:
                color = "white";
                spriteRenderer.color = Color.white;
                break;
        }

        Rename();
    }

    public void InvokeUndo()
    {
        cmdI.UndoCommand();
    }

    public void InvokeRedo()
    {
        cmdI.RedoCommand();
    }

    public void InvokeClear()
    {
        cmdI.ClearCommand();
    }

    private void OnMouseEnter()
    {
        hover = true;
    }

    private void OnMouseExit()
    {
        hover = false;
    }
}
