using UnityEngine;
using System.Collections;

public class RedBlob : AbstractBlob
{
    public RedBlob(Color blobColor) : base(blobColor)
    {
    }

    public override Vector2 MovePos(Vector2 currentPos, Vector2 targetPos, Color targetColor)
    {
        //red will always chase after you
        return MoveTowards(currentPos, targetPos);
    }
}
