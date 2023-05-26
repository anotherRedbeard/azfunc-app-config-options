using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class BlobTrigger1
    {

        [FunctionName("BlobTrigger1")]
        public void Run(
            [BlobTrigger("dotnet/{name}", Connection = "TestApp:Settings:ConnectionString")]Stream myBlob,
            string name,
            ILogger log)
        {
            log.LogWarning($"C# Blob trigger function processed blob\nName: {name}\nSize: {myBlob.Length} Bytes");
        }
    }
}
