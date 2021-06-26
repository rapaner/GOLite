using System;
using System.Collections.Generic;
using System.Linq;

namespace GOLite.Common
{
    public abstract class BaseValidation : BaseNotification
    {
        protected List<EntityErrorInfo> ErrorsInfo = new List<EntityErrorInfo>();
        private bool _IsValid;

        /// <summary>
        /// Indicates if a consumer input data is completely valid
        /// </summary>
        public bool IsValid
        {
            get
            {
                ClearErrors();
                OnValidate();

                _IsValid = !ErrorsInfo.Any();
                return _IsValid;
            }
            private set
            {
                _IsValid = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }

        /// <summary>
        /// Returns a model error list
        /// </summary>
        public IEnumerable<EntityErrorInfo> GetErrorList()
        {
            return ErrorsInfo;
        }

        /// <summary>
        /// Returns a model error list in one interpolated string
        /// </summary>
        public string GetErrorListInterpolation()
        {
            return string.Join(Environment.NewLine, ErrorsInfo.Select(i => i.ErrorProperty).ToArray());
        }

        /// <summary>
        /// Clears all errors
        /// </summary>
        public void ClearErrors()
        {
            ErrorsInfo.Clear();
        }

        /// <summary>
        /// Adds error into the error list
        /// </summary>
        public void AddError(string errorValue)
        {
            ErrorsInfo.Add(new EntityErrorInfo(errorValue));
        }

        public abstract void OnValidate();

        protected bool SetProperty<T>(ref T storage, T value, string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }

    public class EntityErrorInfo
    {
        public EntityErrorInfo(string errorProperty)
        {
            ErrorProperty = errorProperty;
        }

        public string ErrorProperty { get; private set; }
    }
}