using UnityEngine;
using System.Collections;
using System;

public class GreenBlob : AbstractBlob
{
    private CloseAura close;

    private int assignedTarget = -1;
    private int knownTargets = 0;

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
            if(assignedTarget < 0 || knownTargets != close.GetGameObjectsCount())
            {
                assignedTarget = UnityEngine.Random.Range(0, close.GetGameObjectsCount());
                knownTargets = close.GetGameObjectsCount();
            }

            Vector2 newtargetPos = close.GetGameObjectInCircle(assignedTarget).transform.position;

            return MoveTowards(currentPos, newtargetPos);
        }

        return currentPos;
    }

    public void AddAuraScript(CloseAura script)
    {
        close = script;
    }
}
