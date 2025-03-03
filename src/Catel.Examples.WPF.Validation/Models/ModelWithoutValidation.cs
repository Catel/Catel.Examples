namespace Catel.Examples.Validation.Models
{
    using System;
    using System.Runtime.Serialization;
    using Data;

    [Serializable]
    public class ModelWithoutValidation : ModelBase
    {
        #region Constructors
        public ModelWithoutValidation()
        {
        }

        protected ModelWithoutValidation(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion

        #region Properties
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        #endregion
    }
}