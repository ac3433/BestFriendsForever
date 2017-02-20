using UnityEngine;
using System.Collections;

public class AbstractBlobFactory {


	public AbstractBlob GetBlob(string name)
    {
        if (name.ToLower().Equals("blue"))
        {
            return new BlobFactory().MakeBlueBlob();
        }
        else if (name.ToLower().Equals("red"))
        {
            return new BlobFactory().MakeRedBlob();
        }
        else if (name.ToLower().Equals("green"))
        {
            return new BlobFactory().MakeGreenBlob();
        }

        return null;
    }
}
