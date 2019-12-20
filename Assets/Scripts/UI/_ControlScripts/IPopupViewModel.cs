namespace Core.Gameplay.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;
    using UnityWeld.Binding;
    using Sirenix.OdinInspector;
    using ReadOnly = Sirenix.OdinInspector.ReadOnlyAttribute;

        //Base clase to wrap common functionaity and allow for cross scene self registration
    [Binding]
    public class IPopupViewModel : IViewModelRegistered
    {

        private string m_popupTitle = string.Empty;

        [SerializeField] [ReadOnly] private string PopupTitleKey;


        private bool m_wasInitialized = false;

        


        [Binding]
        public string PopupTitle
        {
            get => m_popupTitle;
            set
            {
                if (m_popupTitle == value)
                {
                    return;
                }

                m_popupTitle = value;

                OnPropertyChanged(nameof(PopupTitle));
            }
        }



        [Binding]
        public void ClosePopup()
        {
            if (!m_wasInitialized)
            {
                InitializePopupViewModel();
            }

        }


        [Binding]
        public void ShowPopup()
        {

            if (!m_wasInitialized)
            {
                InitializePopupViewModel();
            }
            gameObject.SetActive(true);

        }

        // Start is called before the first frame update
        public virtual void InitializePopupViewModel()
        {
          

            m_wasInitialized = true;

            // PopupTitle = DependencyManager.Instance.Resolve<ILocalizationService>().GetLocalization(PopupTitleKey);
        }

        public virtual void Reset()
        {
            m_wasInitialized = false;
        }

        public override string GetKey()
        {
            // No 2 popups with the same ID should ever exist on the scene. Maybe some safeguard should be added here later on...
            return string.Empty;
        }
    }
}
