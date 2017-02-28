﻿using UnityEngine;
using System.Collections;

public class AbstractBlobFactory {


	public AbstractBlob GetBlob(string name)
    {
        BlobFactory blobFactory = new BlobFactory();
        if (name.ToLower().Equals("blue"))
        {
            return blobFactory.MakeBlueBlob();
        }
        else if (name.ToLower().Equals("red"))
        {
            return blobFactory.MakeRedBlob();
        }
        else if (name.ToLower().Equals("green"))
        {
            GreenBlob blob = (GreenBlob)blobFactory.MakeGreenBlob();
            CloseAura aura = GameObject.Find("Player/Close-Aura").GetComponent<CloseAura>();//to be removed
            blob.AddAuraScript(aura);

            return blob;
        }

        return null;
    }
}
