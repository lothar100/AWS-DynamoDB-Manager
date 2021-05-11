using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using AWS_DynamoDB_Manager.Classes.Extensions;
using AWS_DynamoDB_Manager.Classes.Utils;
using System.Collections.Generic;
using System.Linq;

namespace AWS_DynamoDB_Manager.Classes
{
    public static class Profiles
    {
        private static NetSDKCredentialsFile _netSDKFile = new NetSDKCredentialsFile();
        private static SharedCredentialsFile _sharedFile = new SharedCredentialsFile();

        public static (AWSCredentials Credentials, CredentialProfile Profile, ICredentialProfileSource Source) Current => loadCurrent();
        private static (AWSCredentials, CredentialProfile, ICredentialProfileSource) loadCurrent()
        {
            CredentialProfile profile = null;
            ICredentialProfileSource profileSource = _sharedFile;
            if (Manager.Settings.profileSource.Equals("private")) profileSource = _netSDKFile;

            if (profileSource.TryGetProfile(Manager.Settings.profileName ?? "", out profile))
            {
                return (profile.GetAWSCredentials(profileSource), profile, profileSource);
            }

            if (_sharedFile.TryGetProfile("default", out profile))
            {
                return (profile.GetAWSCredentials(_sharedFile), profile, _sharedFile);
            }

            return default;
        }

        public static List<string> ProfileNames => getProfileNames();
        private static List<string> getProfileNames()
        {
            var secureList = _netSDKFile.ListProfileNames().PrefixAll(Constants.LOCK_PREFIX);
            var openList = _sharedFile.ListProfileNames();

            return secureList.Concat(openList).ToList();
        }

        private static ICredentialProfileStore getStore(bool encrypted)
        {
            if (encrypted) return _netSDKFile;
            return _sharedFile;
        }

        public static bool profileExists(string name, bool encrypted = false)
        {
            return getStore(encrypted).ListProfileNames().Contains(name);
        }

        public static void createProfile(string name, string access, string secret, bool encrypted = false)
        {
            var options = new CredentialProfileOptions
            {
                AccessKey = access,
                SecretKey = secret
            };
            var profile = new CredentialProfile(name, options);
            getStore(encrypted).RegisterProfile(profile);
        }

        public static void deleteProfile(string name, bool encrypted = false)
        {
            getStore(encrypted).UnregisterProfile(name);
        }
    }
}
