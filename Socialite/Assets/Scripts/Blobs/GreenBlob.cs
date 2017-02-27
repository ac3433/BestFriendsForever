using UnityEngine;
using System.Collections;
using System;

public class GreenBlob : AbstractBlob
{
    public GreenBlob(Color blobColor) : base(blobColor)
    {
    }

    public override Vector2 MovePos(Vector2 currentPos, Vector2 targetPos, Color targetColor)
    {
        //like
        if (targetColor.Equals(Color.green))
        {
            return MoveTowards(currentPos, targetPos);
        }
        else if (targetColor.Equals(Color.red))
        {
            return MoveAway(currentPos, targetPos);
        }
        else if(targetColor.Equals(Color.blue))
        {
            //to be worked on
        }

        return currentPos;
    }
}
