namespace Core.Gameplay.UI
{
    using Core.Gameplay.Info;
    using System.ComponentModel;
    using UnityEngine;
    using UnityWeld.Binding;
    using Zenject;
    using Live2D.Cubism.Core;
    using Intermarum.Tools.ChibiGenerator;

    [Binding]
    public class WardrobePanelViewModel : IViewModel, INotifyPropertyChanged
    {

        [Inject]
        private readonly ICubismPartsController m_cubismPartsController = null;

        private PanelController m_panelController = null;

        private string m_currentTopId = string.Empty;
        private string m_currentBraId = string.Empty;
        private string m_currentPantiesId = string.Empty;
        private string m_currentAccessoryId = string.Empty;
        private string m_currentDressId = string.Empty;
        private string m_currentUnderWearId = string.Empty;
        private string m_currentBottomId = string.Empty;
        private CubismModel m_cubismModel = null;

        private ToolsInfoContainer m_toolsInfoContainer = null;

        [Binding]
        public string CurrentTopId {
            get => m_currentTopId;
            set
            {
                m_currentTopId = value;
                OnPropertyChanged(nameof(CurrentTopId));
            }
        }

        [Binding]
        public string CurrentBraId
        {
            get => m_currentBraId;
            set
            {
                m_currentBraId = value;
                OnPropertyChanged(nameof(CurrentBraId));
            }
        }

        [Binding]
        public string CurrentPantiesId
        {
            get => m_currentPantiesId;
            set
            {
                m_currentPantiesId = value;
                OnPropertyChanged(nameof(CurrentPantiesId));
            }
        }

        [Binding]
        public string CurrentAccessoryId
        {
            get => m_currentAccessoryId;
            set
            {
                m_currentAccessoryId = value;
                OnPropertyChanged(nameof(CurrentAccessoryId));
            }
        }

        [Binding]
        public string CurrentUnderwearId {
            get => m_currentUnderWearId;
            set
            {
                m_currentUnderWearId = value;
                OnPropertyChanged(nameof(CurrentUnderwearId));
            }
        }

        [Binding]
        public string CurrentDressId {
            get => m_currentDressId;
            set
            {
                m_currentDressId = value;
                OnPropertyChanged(nameof(CurrentDressId));
            }
        }

        [Binding]
        public string CurrentBottomId {
            get => m_currentBottomId;
            set
            {
                m_currentBottomId = value;
                OnPropertyChanged(nameof(CurrentBottomId));
            }
        }

        public ToolsInfoContainer ToolsInfoContainer {
            get
            {
                if (m_toolsInfoContainer == null)
                {
                    GenericContainer.Instance.TryGetValue(nameof(ToolsInfoContainer), out var container);
                    m_toolsInfoContainer = container as ToolsInfoContainer;
                }

                return m_toolsInfoContainer;
            }
        }

        private void Awake()
        {
            m_panelController = GetComponent<PanelController>();
        }

        private void Start()
        {
            m_cubismModel = FindObjectOfType<CubismModel>();
        }


   

        public L2DModelsData GetPreviousElement(ClothingType partType, L2DModelsData currentAvatarPart)
        {   
            var prevPart = ToolsInfoContainer.Data.GetPrevClothesData(partType, currentAvatarPart);
            currentAvatarPart = prevPart;
            LoadElement(prevPart, partType);

            return currentAvatarPart;
        }


        public L2DModelsData GetNextElement(ClothingType partType, L2DModelsData currentAvatarPart)
        {        
            var nextPart = ToolsInfoContainer.Data.GetNextClothesData(partType, currentAvatarPart);
            currentAvatarPart = nextPart;
            LoadElement(nextPart, partType);
            return currentAvatarPart;
        }

        public void ResetParts( ClothingType partType)
        {
            foreach (var item in ToolsInfoContainer.Data.GetClothesParts(partType))
            {
                m_cubismPartsController.DisablePartOpacity(m_cubismModel, item.SexyPartsId);
                m_cubismPartsController.DisablePartOpacity(m_cubismModel, item.FrontPartsId);
            }

            SetupParametersIdView(string.Empty, partType);
        }
        
        private void LoadElement(L2DModelsData avatarParts, ClothingType partType)
        {
            foreach (var item in ToolsInfoContainer.Data.GetClothesParts(partType))
            {
                m_cubismPartsController.DisablePartOpacity(m_cubismModel, item.SexyPartsId);
                m_cubismPartsController.DisablePartOpacity(m_cubismModel, item.FrontPartsId);
            }

            SetupParametersIdView(avatarParts.Id.ToString(), partType);

            m_cubismPartsController.EnablePartOpacity(m_cubismModel, avatarParts?.FrontPartsId);
            m_cubismPartsController.EnablePartOpacity(m_cubismModel, avatarParts?.SexyPartsId);

        }


        private void SetupParametersIdView(string id, ClothingType partType)
        {
            switch (partType)
            {

                case ClothingType.Top:
                    CurrentTopId = id;
                    break;
                case ClothingType.Bottom:
                    CurrentBottomId = id;

                    break;
                case ClothingType.Bra:
                    CurrentBraId = id;

                    break;
                case ClothingType.Panties:
                    CurrentPantiesId = id;

                    break;
                case ClothingType.Accessory:
                    CurrentAccessoryId = id;

                    break;
                case ClothingType.Dress:
                    CurrentDressId = id;

                    break;
                case ClothingType.Underwear:
                    CurrentUnderwearId = id;

                    break;

            }
        }
    }
}