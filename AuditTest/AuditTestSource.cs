using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Audit;
using Audit.DataAdapters;

namespace AuditTest
{
    public class AuditTestSource
    {
        public static object[] SaveCases =
        {
            new object[]
            {
                new FileDataAdapter
                {
                    DirectoryPath = ConfigurationManager.AppSettings["TestFileDirectoryPath"],
                    FilenamePrefix = "AuditTest_"
                },
                new AuditEventUser
                {
                    FirstName = "Test User",
                    UserName = "testUser"
                },
                new SampleProduct
                {
                    Name = "Sample Product1",
                    Price = 100
                },
                "ProductUpdate",
                "Product Updated"
               
            }
        };
    }
}
