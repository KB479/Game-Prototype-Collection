using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasHealthBar
{
    // Bu eventin imzasýný taþýnlar, eventle argümanlarýný buradan taþýyýp HealthBarUI prefabýna iletecek. 

    public event EventHandler<OnHealthChangedEventArgs> OnHealthChanged;
    public class OnHealthChangedEventArgs : EventArgs
    {
        public float healthNormalized;
    }


}
