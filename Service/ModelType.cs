using System.ComponentModel;

namespace IntermechToSouz
{
    public enum ModelType
    {
        [Description("Документация")] Doc = 1,


        [Description("Сборочные единицы")] Assembly = 3,

        [Description("Детали")] Part = 4,

        [Description("Стандартные изделия")] SI = 5,


        [Description("Прочие изделия")] Other = 6,

        [Description("Материалы")] Materials = 7,

        [Description("Комплексы")] Complex = 2,

        [Description("Комплекты")] Complect = 8,

        [Description("Не определено")] Unknown = 2002
    }
}