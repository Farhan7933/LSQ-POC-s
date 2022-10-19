using Amazon.DynamoDBv2.DataModel;

namespace DynamoDB.Practice.Models
{
    [DynamoDBTable("test")]
    public class User
    {
        [DynamoDBHashKey]
        public string username { get; set; }
        public string msg_quota { get; set; }
        public string msg_sent { get; set; }
    }
}
