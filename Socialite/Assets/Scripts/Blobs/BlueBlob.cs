using UnityEngine;
using System.Collections;

public class BlueBlob : AbstractBlob
{
    public BlueBlob(Color blobColor) : base(blobColor)
    {

    }

    public override Vector2 MovePos(Vector2 currentPos, Vector2 targetPos, Color targetColor)
    {
        //like
        if(targetColor.Equals(Color.blue))
        {
            return MoveTowards(currentPos, targetPos);
        }
        //scared
        else if (targetColor.Equals(Color.red))
        {
            return MoveAway(currentPos, targetPos);
        }
        //green and any other colors just don't care
        return currentPos;
    }
}
