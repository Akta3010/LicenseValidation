using License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseValidation.Services
{
    internal class LicenseServices
    {
        // Check if a valid license file is available
        public static bool IsValidLicenseAvailable()
        {
            return License.Status.Licensed;
        }

        // Read additonal license information from a license license
        public static List<KeyValuePair<string, string>> ReadAdditonalLicenseInformation()
        {
            List<KeyValuePair<string, string>> keyValue = new List<KeyValuePair<string, string>>();

            // Check first if a valid license file is found
            if (License.Status.Licensed && License.Status.KeyValueList != null)
            {
                // Read additional license information

                for (int i = 0; i < License.Status.KeyValueList.Count; i++)
                {
                    string? keyVal = Convert.ToString(License.Status.KeyValueList.GetKey(i));
                    string key = keyVal;
                    string? val = Convert.ToString(License.Status.KeyValueList.GetByIndex(i));
                    string value = val;

                    keyValue.Add(new KeyValuePair<string, string>(key, value));
                }
            }

            return keyValue;
        }

        // Check the license status of Evaluation Lock
        public static bool CheckEvaluationLock(out EvaluationType evType, out int time, out int time_current)
        {
            bool lock_enabled = License.Status.Evaluation_Lock_Enabled;
            evType = License.Status.Evaluation_Type;
            time = License.Status.Evaluation_Time;
            time_current = License.Status.Evaluation_Time_Current;

            return lock_enabled;
        }

        // Check the license status of Expiration Date Lock
        public static bool CheckExpirationDateLock(out DateTime expirationDate)
        {
            bool lock_enabled = License.Status.Expiration_Date_Lock_Enable;
            expirationDate = License.Status.Expiration_Date;

            return lock_enabled;
        }

        // Check the license status of Number Of Uses Lock
        public static bool CheckNumberOfUsesLock(out int max_uses, out int current_uses)
        {
            bool lock_enabled = License.Status.Number_Of_Uses_Lock_Enable;
            max_uses = License.Status.Number_Of_Uses;
            current_uses = License.Status.Number_Of_Uses_Current;

            return lock_enabled;
        }

        // Check the license status of Number Of Instances Lock
        public static bool CheckNumberOfInstancesLock(out int max_instances)
        {
            bool lock_enabled = License.Status.Number_Of_Instances_Lock_Enable;
            max_instances = License.Status.Number_Of_Instances;

            return lock_enabled;
        }

        // Check the license status of Hardware Lock
        public static bool CheckHardwareLock(out string lic_hardware_id)
        {
            bool lock_enabled = License.Status.Hardware_Lock_Enabled;
            lic_hardware_id = string.Empty;
            if (lock_enabled)
            {
                // Get Hardware ID which is stored inside the license file
                lic_hardware_id = License.Status.License_HardwareID;
            }

            return lock_enabled;
        }

        // Get Hardware ID of the current machine
        public static string GetHardwareID()
        {
            return License.Status.HardwareID;
        }

        // Compare current Hardware ID with Hardware ID stored in License File
        public static bool CompareHardwareID()
        {
            if (License.Status.HardwareID == License.Status.License_HardwareID)
                return true;
            else
                return false;
        }

        // Invalidate the license. Please note, your protected software does not accept a license file anymore!
        //public static void InvalidateLicense()
        //{
        //    string confirmation_code = License.Status.InvalidateLicense();
        //}

        //// Check if a confirmation code is valid
        //public static bool CheckConfirmationCode(string confirmation_code)
        //{
        //    return License.Status.CheckConfirmationCode(License.Status.HardwareID,
        //    confirmation_code);
        //}

        //// Reactivate an invalidated license.
        //public static bool ReactivateLicense(string reactivation_code)
        //{
        //    return License.Status.ReactivateLicense(reactivation_code);
        //}

        //// Load the license.
        //public static void LoadLicense(string filename)
        //{
        //    License.Status.LoadLicense(filename);
        //}

        //// Load the license.
        //public static void LoadLicense(byte[] license)
        //{
        //    License.Status.LoadLicense(license);
        //}

        //// Get the license.
        //public static byte[] GetLicense()
        //{
        //    return License.Status.License;
        //}
    }
}
