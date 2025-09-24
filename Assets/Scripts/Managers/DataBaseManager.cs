using Firebase.Database;
using UnityEngine;

namespace Managers
{
    public class DataBaseManager : MonoBehaviour
    {
        private string _userId;
        
        private DatabaseReference _reference;
        void Start() 
        {
            _userId = SystemInfo.deviceUniqueIdentifier;    
            _reference = FirebaseDatabase.DefaultInstance.RootReference;
            
            AddNewUser(_userId,"Teste00", 1001);
        }
        
        private void AddNewUser(string userId, string name, int score) {
            var user = new User(name, score);
            var json = JsonUtility.ToJson(user);
            _reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
        }
    }
}