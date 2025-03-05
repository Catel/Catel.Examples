namespace Catel.Examples.MasterDetail.ViewModels
{
    using System;
    using Models;
    using MVVM;

    public class PersonDetailViewModel : ViewModelBase
    {
        public PersonDetailViewModel(Person person)
        {
            ArgumentNullException.ThrowIfNull(person);

            Person = person;

            Title = "Person";
        }

        [Model]
        [Fody.Expose("Gender")]
        [Fody.Expose("FirstName")]
        [Fody.Expose("MiddleName")]
        [Fody.Expose("LastName")]
        private Person Person { get; set; }
    }
}
