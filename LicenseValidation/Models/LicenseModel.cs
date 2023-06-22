using License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseValidation.Models
{
    public class LicenseModel
    {
        public bool Status { get; set; }

        public List<KeyValuePair<string, string>>? KeyValues { get; set; }

        public bool EvaluationLock { get; set; }
        public EvaluationType EvaluationType { get; set; }
        public int EvaluationTime { get; set; }
        public int EvaluationCurrTime { get; set; }

        public bool ExpirationDateLock { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public bool NumberofUserLock { get; set; }
        public int NumberofUsers { get; set; }
        public int NumberofCurrUsers { get; set; }

        public bool NumberofInstanceLock { get; set; }
        public int NumberofInstance { get; set; }

        public bool IsHardwareLock { get; set; }
        public string? HardwareIDFile { get; set; }
        public string? HardwareIDMachine { get; set; }
        public bool IsHardwareIDMatching { get; set; }

        public LicenseModel()
        {
            Status = false;

            KeyValues = new List<KeyValuePair<string, string>>();

            EvaluationLock = false;
            EvaluationType = new EvaluationType();
            EvaluationTime = 0;
            EvaluationCurrTime = 0;

            ExpirationDateLock = false;
            ExpirationDate = new DateTime();

            NumberofUserLock = false;
            NumberofUsers = 0;
            NumberofCurrUsers = 0;

            NumberofInstanceLock = false;
            NumberofInstance = 0;

            IsHardwareLock = false;
            HardwareIDFile = string.Empty;
            HardwareIDMachine = string.Empty;
            IsHardwareIDMatching = false;
        }
    }
}
