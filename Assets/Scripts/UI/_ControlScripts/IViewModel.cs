using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

//Base clase to wrap common functionaity and allow for cross scene self registration

[Binding]
public class IViewModel : MonoBehaviour , INotifyPropertyChanged
{
    public virtual string GetKey()
    {
        return gameObject.name;
    }
    
    #region MVVM Property Changed
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    #endregion
}