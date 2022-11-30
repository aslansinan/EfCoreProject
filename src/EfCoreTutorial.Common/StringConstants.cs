using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreTutorial.Common
{
    public static class StringConstants
    {
        public static string DbConnectionString { get; } = "Data Source=localhost\\SQLEXPRESS01;Database=EfCoreTutorial;Trusted_Connection=True;TrustServerCertificate=true;Encrypt=True;";
    }
}
