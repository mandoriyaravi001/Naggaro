using DataAccessLayer.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class UserDataConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
                        (
                            new User { UserID = 1, FullName = "Lena", Email = "lena@gmail.com", Password = "Lena123@" },
                            new User { UserID = 2, FullName = "Ben", Email = "ben@gmail.com", Password = "ben123@" },
                            new User { UserID = 3, FullName = "Elias", Email = "elias@yahoo.com", Password = "elias@123" },
                            new User { UserID = 4, FullName = "Lukas", Email = "lukas@rediff.com", Password = "likas123#" },
                            new User { UserID = 5, FullName = "Tobias", Email = "tobias@gmail.com", Password = "B12345@" },
                            new User { UserID = 6, FullName = "Jonas", Email = "jonas@gmail.com", Password = "jonas@12345" },
                            new User { UserID = 7, FullName = "Laura", Email = "laura@gmail.com", Password = "Blaura@123" }
                        );
        }
    }

    public class EventDataConfiguration : IEntityTypeConfiguration<Event>
    {
        void IEntityTypeConfiguration<Event>.Configure(EntityTypeBuilder<Event> builder)
        {
            

            builder.HasData
            (
                new Event { EventID = 1, Title = "Python", Date = System.DateTime.Parse("2020-08-1"), Location = "Indore", StartTime = "09:00", Type = "Public", DurationInHours = 3, Description = "", OtherDetails = "", InviteByEmail = "tikiyo@gmail.com", UserID = 1 },
                new Event { EventID = 2, Title = "Java", Date = System.DateTime.Parse("2017-06-15"), Location = "Bhopal", StartTime = "10:00", Type = "Public", DurationInHours = 2, Description = "", OtherDetails = "", InviteByEmail = "abc@rediff.com,bcd@yahoo.com", UserID = 1 },
                new Event { EventID = 3, Title = "Makar Sankranti", Date = System.DateTime.Parse("2020-01-14"), Location = "MP", StartTime = "08:00", Type = "Private", DurationInHours = 2, Description = "", OtherDetails = "", InviteByEmail = "jonh@gmail.com,aaannn@gmail.com", UserID = 2 },
                new Event { EventID = 4, Title = "Uncommon Sense with Jeeveshu Ahluwalia ", Date = System.DateTime.Parse("2020-10-17"), Location = "Indore", StartTime = "06:30", Type = "Public", DurationInHours = 2, Description = "", OtherDetails = "", InviteByEmail = "", UserID = 2 },
                new Event { EventID = 5, Title = "Josh Clapham Memorial Show", Date = System.DateTime.Parse("2019-01-30"), Location = "Germany", StartTime = "10:00", Type = "Private", DurationInHours = 4, Description = "", OtherDetails = "", InviteByEmail = "minati@yahoo.com", UserID = 3 },
                new Event { EventID = 6, Title = "Tu Kar Lega Stand Up Special By Sundeep Sharma", Date = System.DateTime.Parse("2021-06-12"), Location = "India", StartTime = "11:30", Type = "Public", DurationInHours = 3, Description = "", OtherDetails = "", InviteByEmail = "sundeep@rediff.com", UserID = 8 },
                new Event { EventID = 7, Title = "Other Minds Festival 25", Date = System.DateTime.Parse("2021-09-14"), Location = "Sydeny,Australia", StartTime = "18:00", Type = "Public", DurationInHours = 4, Description = "", OtherDetails = "", InviteByEmail = "", UserID = 3 },
                new Event { EventID = 8, Title = "Festival Voix De Femmes", Date = System.DateTime.Parse("2019-10-07"), Location = "Delhi", StartTime = "13:00", Type = "Public", DurationInHours = 1, Description = "", OtherDetails = "", InviteByEmail = "sum@nagarro.com", UserID = 3 },
                new Event { EventID = 9, Title = "Zivert - Tour in Deutschland", Date = System.DateTime.Parse("2017-03-21"), Location = "Berlin", StartTime = "01:00", Type = "Private", DurationInHours = 3, Description = "", OtherDetails = "", InviteByEmail = "nino@gmail.com", UserID = 4 },
                new Event
                {
                    EventID = 10,
                    Title = "Dummy single day feature event",
                    Date = System.DateTime.Parse("2021-10-18"),
                    Location = "India",
                    StartTime = "09:30",
                    Type = "Public",
                    DurationInHours = 1,
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    OtherDetails = " Lorem Ipsum has been the industry’s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                    InviteByEmail = "",
                    UserID = 8
                },
                new Event { EventID = 11, Title = "Business Plan	", Date = System.DateTime.Parse("2019-06-25"), Location = "Bhopal", StartTime = "04:00", Type = "Public", DurationInHours = 1, Description = "", OtherDetails = "", InviteByEmail = "lon123@gmail.com,ba1234@nagarro.com", UserID = 7 },
                new Event { EventID = 12, Title = "Digital Marketing Course	", Date = System.DateTime.Parse("2019-06-15"), Location = "Indore", StartTime = "05:00", Type = "Public", DurationInHours = 4, Description = "", OtherDetails = "", InviteByEmail = "yanli@rediff.com,arturo@yahoo.com", UserID = 7 },
                new Event { EventID = 13, Title = "Online Quiz", Date = System.DateTime.Parse("2022-10-01"), Location = "New Delhi", StartTime = "08:00", Type = "Private", DurationInHours = 3, Description = "", OtherDetails = "", InviteByEmail = "carson@gmail.com", UserID = 8 },
                new Event { EventID = 14, Title = "Year Book", Date = System.DateTime.Parse("2016-12-05"), Location = "Ghaziabad", StartTime = "14:00", Type = "Public", DurationInHours = 2, Description = "", OtherDetails = "", InviteByEmail = "", UserID = 8 },
                new Event { EventID = 15, Title = "Memorial Show", Date = System.DateTime.Parse("2015-01-30"), Location = "Shahdara", StartTime = "21:00", Type = "Private", DurationInHours = 4, Description = "", OtherDetails = "", InviteByEmail = "arturo@yahoo.com,baroliya@nagarro.com", UserID = 3 }

            );  
            
        }
    }
    public class CommentDataConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData
                        (
                            new Comment { CommentID = 1, Comments = "Nice Event...!", DateTime = System.DateTime.Parse("2020-09-30"), EventID = 1 },
                            new Comment { CommentID = 2, Comments = "I like it...!", DateTime = System.DateTime.Parse("2020-10-11"), EventID = 1 },
                            new Comment { CommentID = 3, Comments = "Superb Event", DateTime = System.DateTime.Parse("2020-09-27"), EventID = 2 },
                            new Comment { CommentID = 4, Comments = "Great...", DateTime = System.DateTime.Parse("2018-10-05"), EventID = 2 },
                            new Comment { CommentID = 5, Comments = "Nice", DateTime = System.DateTime.Parse("2020-01-01"), EventID = 2 },
                            new Comment { CommentID = 6, Comments = "Thanks for it.", DateTime = System.DateTime.Parse("2020-11-01"), EventID = 1 },
                            new Comment { CommentID = 7, Comments = "Gazab..(`.`)", DateTime = System.DateTime.Parse("2019-06-16"), EventID = 5 },
                            new Comment { CommentID = 8, Comments = "Cool Event", DateTime = System.DateTime.Parse("2019-01-31"), EventID = 5 },
                            new Comment { CommentID = 9, Comments = "You are Great", DateTime = System.DateTime.Parse("2019-07-11"), EventID = 8 },
                            new Comment { CommentID = 10, Comments = "Waiting for it...", DateTime = System.DateTime.Parse("2020-03-08"), EventID = 6 },
                            new Comment { CommentID = 11, Comments = "Super cool", DateTime = System.DateTime.Parse("2020-02-27"), EventID = 9 },
                            new Comment { CommentID = 12, Comments = "Nice Event...!", DateTime = System.DateTime.Parse("2019-09-30"), EventID = 8 },
                            new Comment { CommentID = 13, Comments = "Very interesting", DateTime = System.DateTime.Parse("2020-01-31"), EventID = 8 },
                            new Comment { CommentID = 14, Comments = "Nice Event...!", DateTime = System.DateTime.Parse("2019-06-09"), EventID = 9 },
                            new Comment { CommentID = 15, Comments = "Cool", DateTime = System.DateTime.Parse("2018-05-01"), EventID = 9 }
                        );
        }
    }
}
