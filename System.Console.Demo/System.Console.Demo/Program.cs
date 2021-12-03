var coreAssemblyInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(object).Assembly.Location);
Console.WriteLine($"런타임 버전 {coreAssemblyInfo.ProductVersion}");
Console.WriteLine($"위치 : {typeof(object).Assembly.Location}");
Console.WriteLine("=============================================");
Console.WriteLine("Console.JungdoTest : " + Console.JungdoTest);

Console.WriteLine("abcd");
