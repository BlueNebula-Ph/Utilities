namespace BlueNebula.Common.DTOs
{
    using System;

    /// <summary>
    /// The base class for save requests.
    /// </summary>
    public class SaveRequestBase
    {
        /// <summary>
        /// Gets or sets the id property.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created by property.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date property.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the last updated by property.
        /// </summary>
        public int LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the last updated date property.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }
    }
}
