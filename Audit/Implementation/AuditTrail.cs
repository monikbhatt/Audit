using System;
using System.Collections.Generic;

namespace Audit
{
    internal class AuditTrail : IAuditTrail
    {

        #region Private fields
        private readonly IAuditEvent _event;

        private readonly IAuditDataAdapter _dataAdapter;
        private readonly Func<object> _targetGetter;
        private bool _disposed;
        private bool _ended;
        #endregion
        
        /// <summary>
        /// Creates an Audit Trail object from options and intitalize the event with target entity and data adapter to use.
        /// </summary>

        #region Constructor
        internal AuditTrail(AuditOptions options)
        {
            _dataAdapter = options.DataAdapter;
            _targetGetter = options.TargetGetter;
            _event = options.AuditEvent;
            _event.TargetEntity = options.TargetEntity;
        }
        #endregion


        #region Public Properties
        /// <summary>
        /// Indicates the event type
        /// </summary>
        public string EventType
        {
            get => _event.EventType;
            set => _event.EventType = value;
        }

        /// <summary>
        /// Gets the event related to this scope.
        /// </summary>
        public IAuditEvent Event => _event;

        /// <summary>
        /// Gets the data provider for this AuditTrail instance.
        /// </summary>
        public IAuditDataAdapter DataAdapter => _dataAdapter;

        #endregion

        /// <summary>
        /// Add a textual comment to the event
        /// </summary>
        public void Comment(string text)
        {
            if (_event.Comments == null)
            {
                _event.Comments = new List<string>();
            }
            _event.Comments.Add(string.Format(text));
        }

        /// <summary>
        /// Save Event with manaual save
        /// </summary>
        public void Save()
        {
            if (_ended)
            {
                return;
            }
            EndEvent();
            SaveEvent();
        }

        /// <summary>
        /// End the Audit trail scope
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            EndEvent();
            _ended = true;
        }

        /// <summary>
        /// Serialize the changed target object to save  
        /// </summary>
        private void EndEvent()
        {
            if (_targetGetter != null)
            {
                _event.TargetEntity.New = _dataAdapter.Serialize(_targetGetter.Invoke());
            }
        }
        
        /// <summary>
        /// Saves Audit Event using Data Adapater
        /// </summary>
        private void SaveEvent()
        {
            if (_ended)
            {
                return;
            }
            _dataAdapter.InsertEvent(_event);
        }
        
    }
}
