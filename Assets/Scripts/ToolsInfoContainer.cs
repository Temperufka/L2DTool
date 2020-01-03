namespace Core.Gameplay.Info
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Live2D.Cubism.Core;
    using Sirenix.OdinInspector;
    using UnityEngine;


    public enum PartsType
    {
        Undefined = -1,
        Hair = 0,
        Clohtes = 1,
        Skin = 2,
        Eyes = 3,
        Eyebrow = 4
    }

    public enum ClothingType
    {
        Undefined,
        Top,
        Bottom,
        Bra,
        Panties,
        Accessory,
        Dress,
        Underwear
    }
    [Serializable]
    public class ToolsInfoContainer : SerializableContainer
    {
        [SerializeField] private L2DModelsTester m_data;

        public L2DModelsTester Data
        {
            get => m_data;
            set => m_data = value;
        }

        private void OnEnable()
        {
            Instance.Add(nameof(ToolsInfoContainer), this);
        }

        public override object GetData()
        {
            throw new NotImplementedException();
        }

        public override void LoadConfig(string config)
        {
            throw new NotImplementedException();
        }


     

        [Button]
        public void LoadCharacters(string json)
        {
            var data = DeserializeConfig(json, Data);
            Data = data;

        }

    }

    [Serializable]
    public class L2DModelsTester
    {
        [SerializeField] private List<L2DModelsData> m_clothes;
        public List<L2DModelsData> Clothes {
            get => m_clothes;
            set => m_clothes = value;
        }


        public L2DModelsData GetPrevClothesData(ClothingType clothingType, L2DModelsData currModelsData)
        {
            var clothes = GetClothesParts(clothingType);

            if (currModelsData == null)
            {
                return clothes[0];
            }

            var currIndex = clothes.IndexOf(currModelsData);
            var prevIndex = currIndex == 0 ? clothes.Count - 1 : currIndex - 1;

            return clothes[prevIndex];
        }

        public L2DModelsData GetNextClothesData(ClothingType clothingType, L2DModelsData currModelsData)
        {

            var clothes = GetClothesParts(clothingType);

            if (currModelsData == null)
            {
                return clothes[0];
            }

            var currIndex = clothes.IndexOf(currModelsData);
            var nextIndex = currIndex < clothes.Count - 1 ? currIndex + 1 : 0;

            return clothes[nextIndex];
        }

        
        public List<L2DModelsData> GetClothesParts(ClothingType clothingType)
        {
            var clothes = Clothes.Where(x => x.Type == clothingType).OrderBy(z=>z.Id).ToList();
            return clothes;

        }

        public List<L2DModelsData> GetSexyParts()
        {
            var clothes = Clothes.Where(x => x.SexyPartsId.Contains("sexy")).ToList();
            return clothes;
        }

        public List<L2DModelsData> GetFrontParts()
        {
            var clothes = Clothes.Where(x => x.SexyPartsId.Contains("front")).ToList();
            return clothes;
        }
    }

    [Serializable]
    public class L2DModelsData
    {
        [SerializeField] private ClothingType m_type;
        [SerializeField] private int m_id;
        [SerializeField] string m_frontPartsId = string.Empty;
        [SerializeField] string m_sexyPartsId = string.Empty;

        public ClothingType Type
        {
            get => m_type;
            set => m_type = value;
        }


        public int Id
        {
            get => m_id;
            set => m_id = value;
        }

        public string FrontPartsId
        {
            get => m_frontPartsId;
            set => m_frontPartsId = value;
        }

        public string SexyPartsId
        {
            get => m_sexyPartsId;
            set => m_sexyPartsId = value;
        }
      
    }

    [Serializable]
    public class CubismPartsId : ChibiGeneratorInfo
    {
        [SerializeField] private string m_partsIds;
        public string PartsIds {
            get => m_partsIds;
        }
    }

    [Serializable]
    public class ChibiTextures : ChibiGeneratorInfo
    {
        [SerializeField] private Texture2D m_skinTexture;

        public Texture2D SkinTexture {
            get => m_skinTexture;
        }

       
    }
    public class ChibiGeneratorInfo
    {
        [SerializeField] private int m_id;
        [SerializeField] private string m_name;

        public string Name {
            get => m_name;
        }
        public int Id {
            get => m_id;
        }
     
    }

   
}