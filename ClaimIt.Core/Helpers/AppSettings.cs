using System;
using System.Collections.Generic;
using System.Linq;
using ClaimIt.Core.Models;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ClaimIt.Core.Helpers
{
    public class AppSettings
    {
        private static ISettings Settings => CrossSettings.Current;

        #region ParticipantPasswords

        static string ParticipantPasswords
        {
            get => Settings.GetValueOrDefault(nameof(ParticipantPasswords), string.Empty);
            set => Settings.AddOrUpdateValue(nameof(ParticipantPasswords), value);
        }

        #endregion




        public static void SetPassword(string id, string password)
        {
            var data = new List<KeyValuePair<string, string>>();

            if (!String.IsNullOrEmpty(ParticipantPasswords))
            {
                data = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(ParticipantPasswords);
            }

            data.Add(new KeyValuePair<string, string>(id, password));

            ParticipantPasswords = JsonConvert.SerializeObject(data);
        }

        public static bool VerifiedPassword(string id, string password)
        {
            var data = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(ParticipantPasswords);

            return data.Any(p => p.Key.Equals(id) && p.Value.Equals(password));
        }

        public static bool HasPassword(string id)
        {
            if (String.IsNullOrEmpty(ParticipantPasswords))
            {
                return false;
            }

            var data = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(ParticipantPasswords);

            return data.Any(p => p.Key.Equals(id));

        }
    }
}
