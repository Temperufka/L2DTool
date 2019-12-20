namespace Core.Gameplay.UI
{
    using UnityEngine;
    using UnityWeld.Binding;
    using Core.Gameplay.Info;

    [Binding]
    public class WardrobeChangeElementButtonViewModel : IViewModel
    {
        [SerializeField]
        private ClothingType m_cubismPartType = ClothingType.Undefined;
        private L2DModelsData m_currentAvatarPart = null;

        private WardrobePanelViewModel m_wardrobePanelView = null;

        private void Awake()
        {
            m_wardrobePanelView = GetComponentInParent<WardrobePanelViewModel>();
        }

        private void OnEnable()
        {
            ResetParts();
        }

        [Binding]
        public void OnClick_NextElement()
        {
            m_currentAvatarPart = m_wardrobePanelView.GetNextElement(m_cubismPartType, m_currentAvatarPart);
        }

        [Binding]
        public void OnClick_PrevElement()
        {
            m_currentAvatarPart = m_wardrobePanelView.GetPreviousElement(m_cubismPartType, m_currentAvatarPart);
        }

        [Binding]

        public void ResetParts()
        {
            m_currentAvatarPart = null;
            m_wardrobePanelView.ResetParts(m_cubismPartType);
        }

    }
}