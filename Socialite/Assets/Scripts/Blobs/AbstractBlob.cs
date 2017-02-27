using UnityEngine;
using System.Collections;

public abstract class AbstractBlob {

    private Color blobColor;
    private float speed;

    public Color BlobColor { get { return blobColor; } set { blobColor = value; } }
    public float Speed { get { return speed; } set { speed = value; } }

    public AbstractBlob(Color blobColor)
    {
        this.blobColor = blobColor;
    }

    public virtual Vector2 MovePos(Vector2 currentPos, Vector2 targetPos, Color targetColor)
    {
        return currentPos;
    }

    public bool MovingForward(Color targetColor)
    {
        if (blobColor.Equals(targetColor))
        {
            return true;
        }
        else
            return false;
    }

    protected Vector2 MoveTowards(Vector2 currentPos, Vector2 targetPos)
    {
        return Vector2.MoveTowards(currentPos, targetPos, speed * Time.fixedDeltaTime);
    }

    protected Vector2 MoveAway(Vector2 currentPos, Vector2 targetPos)
    {
        Vector2 direction = targetPos - currentPos;
        Vector2 pointMove = currentPos - direction;

        return Vector2.MoveTowards(currentPos, pointMove, speed * Time.fixedDeltaTime);
    }

}
