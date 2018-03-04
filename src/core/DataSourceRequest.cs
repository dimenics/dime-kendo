using System.Collections.Generic;

namespace Dime.Kendo
{
    public class DataSourceRequest
    {
        #region Constructor

        /// <summary>
        ///
        /// </summary>
        public DataSourceRequest()
        {
            this.Sort = new HashSet<Sort>();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// The amount of items to take
        /// </summary>
        public virtual int Take { get; set; }

        /// <summary>
        /// The amount of items to skip
        /// </summary>
        public virtual int Skip { get; set; }

        /// <summary>
        /// The page number
        /// </summary>
        public virtual int Page { get; set; }

        /// <summary>
        /// The amount of records per page
        /// </summary>
        public virtual int PageSize { get; set; }

        /// <summary>
        /// The sorting to apply to the collection
        /// </summary>
        public virtual IEnumerable<Sort> Sort { get; set; }

        /// <summary>
        /// The filter to apply to the collection
        /// </summary>
        public virtual Filter Filter { get; set; }

        #endregion Properties
    }
}