

using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoConnect.Models
{
    public class Student
    {
        [BsonId]
        protected ObjectId Id { get; set; }

        // name in Mongo
        [BsonElement("firstname")]
        public string? FirstName { get; set; }

        [BsonElement("lastname")]
        public string? LastName { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("age")]
        public int? Age { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }



        public Student(string? firstName, string? lastName, string? email, int? age, string? description)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Description = description;
        }
    }
}
