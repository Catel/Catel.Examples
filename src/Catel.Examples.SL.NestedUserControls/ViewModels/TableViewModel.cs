namespace Catel.Examples.SL4.NestedUserControls.ViewModels
{
    using Data;
    using MVVM;
    using Models;

    /// <summary>
    /// GrandParent view model.
    /// </summary>
    public class TableViewModel : ViewModelBase
    {
        #region Constructor & destructor
        public TableViewModel()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableViewModel"/> class.
        /// </summary>
        public TableViewModel(TableModel table)
        {
            Argument.IsNotNull("table", table);

            Table = table;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return Name; } }

        #region Models
        /// <summary>
        /// Gets the table.
        /// </summary>
        [Model]
        public TableModel Table
        {
            get { return GetValue<TableModel>(TableProperty); }
            set { SetValue(TableProperty, value); }
        }

        /// <summary>
        /// Register the Table property so it is known in the class.
        /// </summary>
        public static readonly PropertyData TableProperty = RegisterProperty("Table", typeof(TableModel));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ViewModelToModel("Table")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string));
        #endregion
        #endregion

        #region Commands
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        #endregion

        #region Methods
        #endregion
    }
}
