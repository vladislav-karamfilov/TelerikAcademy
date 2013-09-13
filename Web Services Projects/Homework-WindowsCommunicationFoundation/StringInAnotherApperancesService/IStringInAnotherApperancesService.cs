namespace StringInAnotherApperancesService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringInAnotherApperancesService
    {
        [OperationContract]
        int GetStringAppearancesInAnotherString(string originString, string testString);
    }
}
