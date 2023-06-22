using License;
using LicenseValidation.Models;
using LicenseValidation.Services;

namespace LicenseValidation
{
    public class LicenseValidationServices
    {
        public static LicenseModel getLicenseInformation()
        {
            LicenseModel license = new LicenseModel();

            license.Status = LicenseServices.IsValidLicenseAvailable();

            license.KeyValues = LicenseServices.ReadAdditonalLicenseInformation();

            EvaluationType evaluationType = new EvaluationType();
            int evaluationTime = 0;
            int currentTime = 0;
            license.EvaluationLock = LicenseServices.CheckEvaluationLock(out evaluationType, out evaluationTime, out currentTime);
            license.EvaluationType = evaluationType;
            license.EvaluationTime = evaluationTime;
            license.EvaluationCurrTime = currentTime;

            DateTime lockTime = DateTime.Now;
            license.ExpirationDateLock = LicenseServices.CheckExpirationDateLock(out lockTime);
            license.ExpirationDate = lockTime;

            int maxUser = 0;
            int currUser = 0;
            license.NumberofUserLock = LicenseServices.CheckNumberOfUsesLock(out maxUser, out currUser);
            license.NumberofUsers = maxUser;
            license.NumberofCurrUsers = currUser;

            int maxInstances = 0;
            license.NumberofInstanceLock = LicenseServices.CheckNumberOfInstancesLock(out maxInstances);
            license.NumberofInstance = maxInstances;

            string hardwareId = string.Empty;
            license.IsHardwareLock = LicenseServices.CheckHardwareLock(out hardwareId);
            license.HardwareIDFile = hardwareId;
            license.HardwareIDMachine = LicenseServices.GetHardwareID();

            license.IsHardwareIDMatching = LicenseServices.CompareHardwareID();
            return license;
        }
    }
}