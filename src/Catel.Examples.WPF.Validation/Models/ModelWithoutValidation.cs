namespace Catel.Examples.Validation.Models
{
    using Data;

    public class ModelWithoutValidation : ModelBase
    {
        public ModelWithoutValidation()
        {
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
