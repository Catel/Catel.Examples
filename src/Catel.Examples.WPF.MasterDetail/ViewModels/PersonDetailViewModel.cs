namespace Catel.Examples.MasterDetail.ViewModels
{
    using System;
    using Data;
    using Models;
    using MVVM;

    public class PersonDetailViewModel : ViewModelBase
    {
        #region Constructors
        public PersonDetailViewModel(Person person)
        {
            ArgumentNullException.ThrowIfNull(person);

            Person = person;

            Title = "Person";
        }
        #endregion

        #region Properties
        [Model]
        [Fody.Expose("Gender")]
        [Fody.Expose("FirstName")]
        [Fody.Expose("MiddleName")]
        [Fody.Expose("LastName")]
        private Person Person { get; set; }
        #endregion
    }
}
