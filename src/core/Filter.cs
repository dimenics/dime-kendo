using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Dime.Kendo
{
    /// <summary>
    /// Represents a filter expression of Kendo DataSource.
    /// </summary>
    [DataContract]
    public class Filter
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Filter()
        {
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the name of the sorted field (property). Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        [DataMember(Name = "field")]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the filtering operator. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        [DataMember(Name = "operator")]
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the filtering value. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        [DataMember(Name = "value")]
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the filtering logic. Can be set to "or" or "and". Set to <c>null</c> unless <c>Filters</c> is set.
        /// </summary>
        [DataMember(Name = "logic")]
        public string Logic { get; set; }

        /// <summary>
        /// Gets or sets the child filter expressions. Set to <c>null</c> if there are no child expressions.
        /// </summary>
        [DataMember(Name = "filters")]
        public IEnumerable<Filter> Filters { get; set; }

        /// <summary>
        /// Mapping of Kendo DataSource filtering operators to Dynamic Linq
        /// </summary>
        private static readonly IDictionary<string, string> operators = new Dictionary<string, string>
        {
            { "eq", "="},
            { "neq", "!="},
            { "lt", "<"},
            { "lte", "<="},
            { "gt", ">"},
            { "gte", ">="},
            { "startswith", "StartsWith"},
            { "endswith", "EndsWith"},
            { "contains", "Contains"}
        };

        #endregion Properties

        #region Methods

        /// <summary>
        /// Get a flattened list of all child filter expressions.
        /// </summary>
        public IList<Filter> All()
        {
            List<Filter> filters = new List<Filter>();
            this.Collect(filters);

            return filters;
        }

        /// <summary>
        /// Converts the filter expression to a predicate suitable for Dynamic Linq e.g. "Field1 = @1 and Field2.Contains(@2)"
        /// </summary>
        /// <param name="filters">A list of flattened filters.</param>
        public string ToExpression(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                return "(" + String.Join(" " + Logic + " ", Filters.Select(filter => filter.ToExpression(filters)).ToArray()) + ")";
            }

            int index = filters.IndexOf(this);

            string comparison = operators[Operator];

            if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
            {
                return String.Format("{0}.{1}(@{2})", Field, comparison, index);
            }

            return String.Format("{0} {1} @{2}", Field, comparison, index);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// [HB] 03/11/2016 - Refactor into filter class
        /// </history>
        public IDictionary<int, string> GetFields(string property)
        {
            int c = 1;
            Dictionary<int, string> properties = new Dictionary<int, string>();
            property.Split('.').ToList().ForEach(x =>
            {
                properties.Add(c, x);
                c++;
            });

            return properties;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filters"></param>
        private void Collect(IList<Filter> filters)
        {
            if (this.Filters != null && this.Filters.Any())
            {
                foreach (Filter filter in this.Filters)
                {
                    filters.Add(filter);
                    filter.Collect(filters);
                }
            }
            else
            {
                filters.Add(this);
            }
        }

        #endregion Methods
    }
}