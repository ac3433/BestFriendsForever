using UnityEngine;
using System.Collections;
using System;

public class GreenBlob : AbstractBlob
{
    private AcquaintanceAura close;

    private int assignedTarget = -1;
    private int knownTargets = 0;

    public GreenBlob(Color blobColor) : base(blobColor)
    {
    }

    public override Vector2 MovePos(Vector2 currentPos, Vector2 targetPos, Color targetColor)
    {
        //if(ForceAway)
        //{
        //    return MoveAway(currentPos, targetPos);
        //}
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
            if((assignedTarget < 0 || knownTargets != close.CountFilterColor(BlobColor)) && close.CountFilterColor(BlobColor) != 0)
            {
                assignedTarget = UnityEngine.Random.Range(0, close.CountFilterColor(BlobColor));
                knownTargets = close.CountFilterColor(BlobColor);
            }

            if (close.GetGameObjectsCount() != 0)
            {
                Vector2 newtargetPos = close.GetFilterObj(BlobColor, assignedTarget).transform.position;

                return MoveTowards(currentPos, newtargetPos);
            }
        }

        return currentPos;
    }

    public void AddAuraScript(AcquaintanceAura script)
    {
        close = script;
    }
}
