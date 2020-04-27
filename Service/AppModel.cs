using System.Collections.Generic;
using Streamdivision.Framework;

namespace IntermechToSouz
{
    public class AppModel
    {
        public AppModel(List<Formattribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                switch (attribute.Name.ToLower())
                {
                    case "обозначение":
                        Designation = attribute.Value;
                        break;
                    case "наименование":
                        Name = attribute.Value;
                        break;
                    case "код типа объекта":
                        ModelType = int.TryParse(attribute.Value, out var x) ? (ModelType) x : ModelType.Unknown;
                        break;
                    case "!parent":
                        Parent = attribute.Value;
                        break;
                }
            }
        }

        public string Designation { get; }
        public ModelType ModelType { get; }
        public string Name { get; }
        public string Parent { get; }

        public override string ToString() =>
            $"Имя: {Name}, Обозначение: {Designation}, Тип: {ModelType.GetDescription()}, Родитель: {Parent}";
    }
}