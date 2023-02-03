using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4_Team2556_WebAPI.Data.ConfigurationSeed
{
    //public class CandidatesSeed : IEntityTypeConfiguration<Candidate>
    //{
    //    public void Configure(EntityTypeBuilder<Candidate> builder)
    //    {
            

    //        builder.HasData
    //        (
    //           new Candidate
    //           {
    //               CandidateId = 1,
    //               FirstName = "Alexandros",
    //               MiddleName = "Nikolaos",
    //               LastName = "Lepeniotis",
    //               Gender = "Male",
    //               NativeLanguage = "Greek",
    //               BirthDate = new DateTime(1992, 02, 02),
    //               PhotoIdType = "National Id",
    //               PhotoIdNumber = "AA 123456",
    //               PhotoIssueDate = new DateTime(2009, 01, 01),
    //               Email = "alex@alex.com",
    //               AddressLine = "Korai 5",
    //               AddressLine2 = "2nd Floor",
    //               CountryOfResidence = "Greece",
    //               Province = "Attiki",
    //               City = "Athens",
    //               PostalCode = "12345",
    //               LandlineNumber = "+302109090999",
    //               MobileNumber = "+306912345678",
                   
    //           },

    //           new Candidate
    //           {
    //               CandidateId = 2,
    //               FirstName = "Mpampis",
    //               MiddleName = null,
    //               LastName = "Papadimitriou",
    //               Gender = "Male",
    //               NativeLanguage = "Greek",
    //               BirthDate = new DateTime(1998, 01, 01),
    //               PhotoIdType = "National Id",
    //               PhotoIdNumber = "AB 999999",
    //               PhotoIssueDate = new DateTime(2015, 05, 05),
    //               Email = "mpa@mpampis.com",
    //               AddressLine = "Axeloou 7",
    //               AddressLine2 = "Ground Floor",
    //               CountryOfResidence = "Greece",
    //               Province = "Thessaloniki",
    //               City = "Kalamaria",
    //               PostalCode = "12345",
    //               LandlineNumber = "+30231009090",
    //               MobileNumber = "+306912345678"
    //           },

    //           new Candidate
    //           {
    //               CandidateId = 3,
    //               FirstName = "Kostas",
    //               MiddleName = null,
    //               LastName = "Kostopoulos",
    //               Gender = "Male",
    //               NativeLanguage = "Greek",
    //               BirthDate = new DateTime(1980, 05, 12),
    //               PhotoIdType = "National Id",
    //               PhotoIdNumber = "AH 111111",
    //               PhotoIssueDate = new DateTime(2015, 09, 25),
    //               Email = "kostas@kostopoulos.com",
    //               AddressLine = "Pentelis 2",
    //               AddressLine2 = "4th Floor",
    //               CountryOfResidence = "Greece",
    //               Province = "Attiki",
    //               City = "Athens",
    //               PostalCode = "54321",
    //               LandlineNumber = "+302108888888",
    //               MobileNumber = "+306945454545"
    //           },

    //           new Candidate
    //           {
    //                CandidateId = 4,
    //                FirstName = "Maria",
    //                MiddleName = "Eleni",
    //                LastName = "Papadopoulou",
    //                Gender = "Female",
    //                NativeLanguage = "Greek",
    //                BirthDate = new DateTime(1972, 12, 12),
    //                PhotoIdType = "Passport",
    //                PhotoIdNumber = "AHQ4567FG",
    //                PhotoIssueDate = new DateTime(2022, 10, 10),
    //                Email = "maria-eleni@papadopoulou.com",
    //                AddressLine = "Markou Mpotsari 67",
    //                AddressLine2 = "1st Floor",
    //                CountryOfResidence = "Greece",
    //                Province = "Attiki",
    //                City = "Athens",
    //                PostalCode = "23456",
    //                LandlineNumber = "+3021000000",
    //                MobileNumber = "+306989898809"
    //           });

    //    }
    //}
}
