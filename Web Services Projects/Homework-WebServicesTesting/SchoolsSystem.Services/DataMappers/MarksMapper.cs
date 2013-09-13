namespace SchoolsSystem.Services.DataMappers
{
    using SchoolsSystem.DataTransferObjects;
    using SchoolsSystem.Models;
    using SchoolsSystem.Repositories;

    public static class MarksMapper
    {
        public static Mark ToMarkEntity(MarkModel markModel)
        {
            Mark mark = new Mark()
                {
                    Subject = markModel.Subject,
                    Value = markModel.Value
                };

            return mark;
        }

        public static MarkModel ToMarkModel(Mark markEntity)
        {
            MarkModel mark = new MarkModel()
                {
                    Subject = markEntity.Subject,
                    Value = markEntity.Value
                };

            return mark;
        }
    }
}