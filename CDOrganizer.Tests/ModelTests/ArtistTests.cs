using Microsoft.VisualStudio.TestTools.UnitTesting;
using CDOrganizer.Models;
using System.Collections.Generic;
using System;

namespace CDOrganizer.Tests
{
  [TestClass]
  public class ArtistTest : IDisposable
  {

    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test Artist");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      string result = newArtist.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsArtistId_Int()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      int result = newArtist.GetId();

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistObjects_ArtistList()
    {
      //Arrange
      string name01 = "Prince";
      string name02 = "Lady Gaga";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);
      List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };

      //Act
      List<Artist> result = Artist.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
     public void Find_ReturnsCorrectArtist_Artist()
     {
       //Arrange
       string name01 = "Prince";
       string name02 = "Lady Gaga";
       Artist newArtist1 = new Artist(name01);
       Artist newArtist2 = new Artist(name02);

       //Act
       Artist result = Artist.Find(2);

       //Assert
       Assert.AreEqual(newArtist2, result);
     }

     [TestMethod]
     public void GetCompactDisk_ReturnsEmptyCompactDiskList_CompactDiskList()
     {
       //Arrange
       string name = "Prince";
       Artist newArtist = new Artist(name);
       List<CompactDisk> newList = new List<CompactDisk> { };

       //Act
       List<CompactDisk> result = newArtist.GetCompactDisks();

       //Assert
       CollectionAssert.AreEqual(newList, result);
     }

     [TestMethod]
     public void AddCompactDisk_AssociatesCompactDiskWithArtist_CompactDiskList()
     {
       //Arrange
       string title = "testtitle";
       CompactDisk newCompactDisk = new CompactDisk(title);
       List<CompactDisk> newList = new List<CompactDisk> { newCompactDisk };
       string name = "Prince";
       Artist newArtist = new Artist(name);
       newArtist.AddCompactDisk(newCompactDisk);

       //Act
       List<CompactDisk> result = newArtist.GetCompactDisks();

       //Assert
       CollectionAssert.AreEqual(newList, result);
     }
  }
}
