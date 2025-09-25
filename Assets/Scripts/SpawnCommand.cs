using UnityEngine;

public class SpawnCommand : Command
{
    SpawnItem spawnItem;

    public override void Execute()
    {
        spawnItem.Place();
    }

    public override void Undo()
    {
        spawnItem.Delete();
    }
}
