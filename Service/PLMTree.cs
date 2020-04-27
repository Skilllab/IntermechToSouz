using System;
using Streamdivision.Framework;

namespace IntermechToSouz
{
    [Serializable]
    public sealed class PLMTree : BaseTreeModel
    {
        public PLMTree() { }

        public PLMTree(string name, string designation, ModelType type)
        {
            IsExpanded = true;
            SetDText($"Имя: {name}, Обозначение: {designation}, Тип документа {type.GetDescription()}");
        }

        public PLMTree(AppModel model)
        {
            IsExpanded = true;
            SetDText(
                $"Имя: {model.Name}, Обозначение: {model.Designation}, Тип документа {model.ModelType.GetDescription()}");
        }
    }
}