using UnityEngine;

public class ColorCommand : Command
{
    Square square;

    int newColor;
    int prevColor;

    public ColorCommand(Square target, int currColor, int newColor)
    {
        square = target;
        prevColor = currColor;
        this.newColor = newColor;
    }

    public override void Execute()
    {
        square.Recolor(newColor);
    }

    public override void Undo()
    {
        square.Recolor(prevColor);
    }
}
