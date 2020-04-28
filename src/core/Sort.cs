using System.Runtime.Serialization;

namespace Dime.Kendo
{
    [DataContract]
    public class Sort
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Sort()
        {
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the name of the sorted field (property).
        /// </summary>
        [DataMember(Name = "field")]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the sort direction. Should be either "asc" or "desc".
        /// </summary>
        [DataMember(Name = "dir")]
        public string Dir { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Converts to form required by Dynamic Linq e.g. "Field1 desc"
        /// </summary>
        public string ToExpression() => Field + " " + Dir;

        #endregion Methods
    }
}