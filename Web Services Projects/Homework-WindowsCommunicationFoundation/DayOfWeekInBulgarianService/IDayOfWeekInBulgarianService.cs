namespace DayOfWeekInBulgarianService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeekInBulgarianService
    {
        [OperationContract]
        string GetDayOfWeekInBulgarian(DateTime date);
    }
}