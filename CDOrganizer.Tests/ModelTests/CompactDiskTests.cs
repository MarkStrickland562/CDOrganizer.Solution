using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CDOrganizer.Models;

namespace CDOrganizer.Tests
{
  [TestClass]
  public class CompactDiskTest : IDisposable
  {
    public void Dispose()
    {
      CompactDisk.ClearAll();
    }

    [TestMethod]
    public void CompactDiskConstructor_CreatesInstanceOfCompactDisk_CompactDisk()
    {
      CompactDisk newCompactDisk = new CompactDisk("disktitle");
      Assert.AreEqual(typeof(CompactDisk), newCompactDisk.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      //Arrange
      string title = "disktitle";
      CompactDisk newCompactDisk = new CompactDisk(title);

      //Act
      string result = newCompactDisk.GetTitle();

      //Assert
      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetTitle_SetTitle_String()
    {
      //Arrange
      string title = "disktitle";
      CompactDisk newCompactDisk = new CompactDisk(title);

      //Act
      string updatedTitle = "newtitle";
      newCompactDisk.SetTitle(updatedTitle);
      string result = newCompactDisk.GetTitle();

      //Assert
      Assert.AreEqual(updatedTitle, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_CompactDiskList()
    {
      // Arrange
      List<CompactDisk> newList = new List<CompactDisk> { };

      // Act
      List<CompactDisk> result = CompactDisk.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsCompactDisks_CompactDiskList()
    {
      //Arrange
      string title1 = "myfirsttitle";
      string title2 = "mysecondtitle";
      CompactDisk newCompactDisk1 = new CompactDisk(title1);
      CompactDisk newCompactDisk2 = new CompactDisk(title2);
      List<CompactDisk> newList = new List<CompactDisk> { newCompactDisk1, newCompactDisk2 };

      //Act
      List<CompactDisk> result = CompactDisk.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_CompactDisksInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string title1 = "myfirsttitle";
      CompactDisk newCompactDisk = new CompactDisk(title1);

      //Act
      int result = newCompactDisk.GetId();

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectCompactDisk_CompactDisk()
    {
      //Arrange
      string title1 = "myfirsttitle";
      string title2 = "mysecondtitle";
      CompactDisk newCompactDisk1 = new CompactDisk(title1);
      CompactDisk newCompactDisk2 = new CompactDisk(title2);

      //Act
      CompactDisk result = CompactDisk.Find(2);

      //Assert
      Assert.AreEqual(newCompactDisk2, result);
    }
  }
}
