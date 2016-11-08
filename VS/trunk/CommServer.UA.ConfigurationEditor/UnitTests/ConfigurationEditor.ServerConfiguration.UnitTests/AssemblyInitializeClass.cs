﻿
using CAS.UA.Server.ServerConfiguration;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests
{
  [TestClass]
  [DeploymentItem(m_Path, m_Path)]
  public class AssemblyInitializeClass
  {
    internal static string FilePath { get { return Path.Combine(m_Path, m_ConfigurationFileName); } }
    internal const string m_Path = @"EmbeddedExample\DemoConfiguration";
    internal const string m_ConfigurationFileName = @"BoilerExample.uasconfig";
    private static TestContext m_Context;

    [AssemblyInitialize()]
    public static void AssemblyInitializeMethod(TestContext context)
    {
      m_Context = context;
      IServiceLocator serviceLocator = new Instrumentation.ServiceLocation();
      ServiceLocator.SetLocatorProvider(() => serviceLocator);
    }
    [ClassCleanup]
    public static void ClassCleanupMethod()
    {
      if (Main.EntryPoint == null)
        throw new System.ApplicationException($"Program error {nameof(Main.EntryPoint)} is empty.");
    }
    [TestMethod]
    public void DeploymentTest()
    {
      FileInfo file = new FileInfo(FilePath);
      Assert.IsTrue(file.Exists);
      Assert.IsNotNull(m_Context);
    }
  }
}
