using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreScheduler.Api;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server.Database
{
    public class JobEvent : IGuidId
    {
        public JobEvent()
        {
            Timestamp = DateTime.Now;
            Id = Guid.NewGuid();
            Children = new List<JobEvent>();
        }

        public int RunOrder { get; set; }
        
        /// <summary>
        /// Unique ID of this JobEvent
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Shared ID of all events that happened on this particular run of the job
        /// </summary>
        public Guid RunId { get; set; }
        
        /// <summary>
        /// ID of Job that this run was based on
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        /// Level of severity
        /// </summary>
        public EventLevel EventLevel { get; set; }
   
        /// <summary>
        /// Header message to accompany the event
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// When the event was logged
        /// </summary>
        public DateTime Timestamp { get; set; }

        public Guid? ParentId { get; set; }

        [NotMapped]
        public JobEvent Parent { get; set; }

        [NotMapped]
        public IList<JobEvent> Children { get; set; }

    }
}
