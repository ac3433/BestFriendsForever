﻿using UnityEngine;
using System.Collections;

public abstract class AbstractBlob {

    private Color blobColor;
    private Color favoriteColor;
    private Color neutralColor;
    private Color hateColor;
    private float speed;
    private float life;

    public Color BlobColor { get { return blobColor; } set { blobColor = value; } }
    public Color FavoriteColor { get { return favoriteColor; } set { favoriteColor = value; } }
    public Color NeutralColor { get { return neutralColor; } set { neutralColor = value; } }
    public Color HateColor { get { return hateColor; } set { hateColor = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public float Life { get { return life; } set { life = value; } }

    public AbstractBlob(Color blobColor)
    {
        this.blobColor = blobColor;
    }

    public virtual Vector2 MovePos(Vector2 currentPos, Vector2 targetPos, Color targetColor)
    {
        if (favoriteColor.Equals(targetColor))
        {
            return Vector2.MoveTowards(currentPos, targetPos, speed * Time.fixedDeltaTime);
        }
        else if (hateColor.Equals(targetColor))
        {
            Vector2 direction = targetPos - currentPos;
            Vector2 pointMove = currentPos - direction;

            return Vector2.MoveTowards(currentPos, pointMove, speed * Time.fixedDeltaTime);
        }
        else
            return currentPos;
    }

    public bool MovingForward(Color targetColor)
    {
        if (favoriteColor.Equals(targetColor))
        {
            return true;
        }
        else
            return false;
    }

}