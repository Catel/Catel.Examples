namespace Catel.Examples.WPF.MasterDetail.ViewModels
{
    using Data;
    using MVVM;
    using Models;

    /// <summary>
    ///   PersonDetail view model.
    /// </summary>
    public class PersonDetailViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDetailViewModel"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        public PersonDetailViewModel(Person person)
        {
            Person = person;
        }

        /// <summary>
        ///   Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Person"; }
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        [Model]
        [Expose("Gender")]
        [Expose("FirstName")]
        [Expose("MiddleName")]
        [Expose("LastName")]
        private Person Person
        {
            get { return GetValue<Person>(PersonProperty); }
            set { SetValue(PersonProperty, value); }
        }

        /// <summary>
        /// Register the Person property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonProperty = RegisterProperty("Person", typeof(Person));
    }
}