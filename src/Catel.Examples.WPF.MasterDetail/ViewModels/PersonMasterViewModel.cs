namespace Catel.Examples.WPF.MasterDetail.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Collections;
    using Data;
    using MVVM;
    using Models;

    /// <summary>
    /// PersonMaster view model.
    /// </summary>
    public class PersonMasterViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonMasterViewModel"/> class.
        /// </summary>
        public PersonMasterViewModel()
        {
            LoadPersons();
        }

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Persons"; } }

        /// <summary>
        /// Gets the list of persons.
        /// </summary>
        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            private set { SetValue(PersonsProperty, value); }
        }

        /// <summary>
        /// Register the Persons property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonsProperty = RegisterProperty("Persons", typeof(ObservableCollection<Person>));

        /// <summary>
        /// Gets or sets the selected person.
        /// </summary>
        public Person SelectedPerson
        {
            get { return GetValue<Person>(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }

        /// <summary>
        /// Register the SelectedPerson property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedPersonProperty = RegisterProperty("SelectedPerson", typeof(Person), null, 
            (sender, e) => ((PersonMasterViewModel)sender).OnSelectedPersonChanged());

        private void OnSelectedPersonChanged()
        {
            int i = 0;
        }

        /// <summary>
        /// Loads the persons.
        /// </summary>
        private void LoadPersons()
        {
            if (Persons == null)
            {
                Persons = new ObservableCollection<Person>();
            }

            // Note: normally, you would load from a service, but here we will just fill the collection manually
            var newPersons = new List<Person>();
            newPersons.Add(new Person() { FirstName = "John", LastName = "Doe", Gender = Gender.Male });
            newPersons.Add(new Person() { FirstName = "Geert", MiddleName="van", LastName = "Horrik", Gender = Gender.Male });

            Persons.ReplaceRange(newPersons);

            if (Persons.Count > 0)
            {
                SelectedPerson = Persons[0];
            }
        }
    }
}