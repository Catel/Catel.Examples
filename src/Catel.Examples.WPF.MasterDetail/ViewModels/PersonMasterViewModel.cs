namespace Catel.Examples.MasterDetail.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Collections;
    using Models;
    using MVVM;

    public class PersonMasterViewModel : ViewModelBase
    {
        public PersonMasterViewModel()
        {
            Title = "Persons";
        }

        public ObservableCollection<Person> Persons { get; private set; }

        public Person SelectedPerson { get; set; }


        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            LoadPersons();
        }

        private void OnSelectedPersonChanged()
        {
            //int i = 0;
        }

        private void LoadPersons()
        {
            if (Persons is null)
            {
                Persons = new ObservableCollection<Person>();
            }

            // Note: normally, you would load from a service, but here we will just fill the collection manually
            var newPersons = new List<Person>();
            newPersons.Add(new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = Gender.Male
            });
            newPersons.Add(new Person()
            {
                FirstName = "Geert",
                MiddleName = "van",
                LastName = "Horrik",
                Gender = Gender.Male
            });

            Persons.ReplaceRange(newPersons);

            if (Persons.Count > 0)
            {
                SelectedPerson = Persons[0];
            }
        }
    }
}
