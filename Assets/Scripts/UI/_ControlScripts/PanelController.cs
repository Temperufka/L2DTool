namespace Core.Gameplay.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;
    using UnityWeld.Binding;
    using Sirenix.OdinInspector;

    using ReadOnly = Sirenix.OdinInspector.ReadOnlyAttribute;

    [Binding]
    public class PanelController : IViewModelRegistered
    {

        private string m_panelTitle = string.Empty;

        [SerializeField] [ReadOnly] private string PanelTitleKey;

     

        private bool m_wasInitialized = false;

      


        [Binding]
        public string PanelTitle
        {
            get => m_panelTitle;
            set
            {
                if (m_panelTitle == value)
                {
                    return;
                }

                m_panelTitle = value;

                OnPropertyChanged(nameof(PanelTitle));
            }
        }

        // public PopupId PopupId
        // {
        //     get => PopupID;
        // }

        [Binding]
        public void ClosePopup()
        {
            ClosePanel();
        }

        [Binding]
        public void ClosePanel()
        {
            if (!m_wasInitialized)
            {
                InitializePanelViewModel();
            }

        }


        [Binding]
        public void ShowPopup()
        {
            ShowPanel();
        }

        [Binding]
        public void ShowPanel()
        {
            if (!m_wasInitialized)
            {
                InitializePanelViewModel();
            }
            gameObject.SetActive(true);

        }


        // Start is called before the first frame update
        public virtual void InitializePanelViewModel()
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
            // return PanelTitleKey;
            return string.Empty;
        }
    }
}
