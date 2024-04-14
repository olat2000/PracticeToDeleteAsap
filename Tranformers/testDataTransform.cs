using LivingDoc.Dtos;
using PracticeToDeleteAsap.Modules;
using TechTalk.SpecFlow.Assist;

namespace PracticeToDeleteAsap.Tranformers
{
    [Binding]
    public class testDataTransform
    {
        [StepArgumentTransformation]
        public LoginCredentials withCredentials(Table table)
        {
            return table.CreateInstance<LoginCredentials>();
        }

        [StepArgumentTransformation]
        public Library withLibrary(Table table)
        {
            return table.CreateInstance<Library>();
        }
    }
}
