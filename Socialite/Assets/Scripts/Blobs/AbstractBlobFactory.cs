using UnityEngine;
using System.Collections;

public class AbstractBlobFactory {


	public AbstractBlob GetBlob(string name)
    {
        BlobFactory blobFactory = new BlobFactory();
        AbstractBlob blob;
        if (name.ToLower().Equals("blue"))
        {
            blob = blobFactory.MakeBlueBlob();
            blob.HateColor = Color.red;
            blob.FavoriteColor = Color.blue;
            return blob;
        }
        else if (name.ToLower().Equals("red"))
        {
            blob = blobFactory.MakeRedBlob();
            blob.HateColor = Color.green;
            blob.FavoriteColor = Color.red;
            return blob;
        }
        else if (name.ToLower().Equals("green"))
        {
            blob = blobFactory.MakeRedBlob();
            blob.HateColor = Color.blue;
            blob.FavoriteColor = Color.green;
            return blob;
        }

        return null;
    }
}
