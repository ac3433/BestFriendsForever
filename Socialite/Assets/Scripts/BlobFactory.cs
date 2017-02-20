using UnityEngine;
using System.Collections;

public class BlobFactory {

    public AbstractBlob MakeGreenBlob()
    {
        return new GreenBlob(Color.green);
    }

    public AbstractBlob MakeBlueBlob()
    {
        return new BlueBlob(Color.blue);
    }

    public AbstractBlob MakeRedBlob()
    {
        return new RedBlob(Color.red);
    }


}
