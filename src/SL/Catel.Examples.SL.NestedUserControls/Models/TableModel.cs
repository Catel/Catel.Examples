namespace Catel.Examples.SL.NestedUserControls.Models
{
    using Data;

    /// <summary>
    /// TableModel Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
#if !SILVERLIGHT
[Serializable]
#endif
    public class TableModel : ModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TableModel"/> class.
        /// </summary>
        public TableModel()
        {

        }

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        /// <param name="name">The name.</param>
        public TableModel(string name)
            : this()
        {
            Name = name;
        }

#if !SILVERLIGHT	
    /// <summary>
    /// Initializes a new object based on <see cref="SerializationInfo"/>.
    /// </summary>
    /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
    /// <param name="context"><see cref="StreamingContext"/>.</param>
    protected TableModel(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
#endif
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string), string.Empty);
        #endregion

        #region Methods
        #endregion
    }
}
