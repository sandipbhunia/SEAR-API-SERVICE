using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WFA.APPID.BookService.Interceptor.Logging
{
    [DataContract(Name = "WFFault_Type")]
    public class WFFault_Type : IExtensibleDataObject, INotifyPropertyChanged
    {
        public WFFault_Type() { }

        [DataMember(EmitDefaultValue =false, Order =7, Name ="adviceText")]
        public string AdviceText { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10, Name = "embeddedException")]
        public string EmbeddedException { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9, Name = "ExceptionInstanceId")]
        public string ExceptionInstanceId { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 5, Name = "faultActor")]
        public string FaultActor { get; set; }
        [DataMember(EmitDefaultValue = false, IsRequired = true, Name = "faultCode")]
        public string FaultCode { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = true, Name = "faultReasonText")]
        public string FaultReasonText { get; set; }

        [DataMember(EmitDefaultValue = false,  Name = "severity")]
        public FaultSeverity_Enum Severity { get; set; }

        [DataMember(EmitDefaultValue = false,Name = "stackTrace")]
        public string StackTrace { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "technicalText")]
        public string TechnicalText { get; set; }


        public ExtensionDataObject ExtensionData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class WFFaultList_Type : List<WFFault_Type>
    {
        public WFFaultList_Type() { }
    }
    [DataContract(Name = "FaultType_Enum")]
    public enum FaultType_Enum { 
        APPL=0,
        SYSTEM=1
    }

    [DataContract(Name = "FaultSeverity_Enum")]
    public enum FaultSeverity_Enum
    {
        INFORMATION = 0,
        WARNING = 1,
        ERROR = 2,
        CRITICAL_ERROR = 3
    }
}
