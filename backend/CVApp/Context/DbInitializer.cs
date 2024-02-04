using System.Globalization;
using CVApp.Models;

namespace CVApp.Context;

public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Users.Any())
        {
            return;
        }

        var users = new User[]
        {
            new User
            {
                Name = "Windu Nursetyadi", Email = "nursetyadiwindu@gmail.com", Phone = "0859106520495",
                Location = "Bekasi", Label = "Software Developer", Website = "https://www.windunursetyadi.com",
                Summary =
                    "A passionate software developer with 5 years of experience in the industry. I have a strong background in developing web applications and mobile applications. I am a fast learner and a team player. I am also a good communicator and a problem solver."
            }
        };
        foreach (var user in users)
        {
            context.Users.Add(user);
        }
        context.SaveChanges();

        var socials = new Social[]
        {
            new Social
            {
                Name = "LinkedIn", Url = "https://www.linkedin.com/in/windu-nursetyadi", UserId = 1
            },
            new Social
            {
                Name = "GitHub", Url = "https://www.github.com/W4RD28", UserId = 1
            }
        };
        foreach (var social in socials)
        {
            context.Socials.Add(social);
        }
        context.SaveChanges();

        var educations = new Education[]
        {
            new Education
            {
                UserId = 1, StudyType = "Bachelor of Computer Science", Institution = "Universitas Padjadjaran",
                StartDate = new DateOnly(2019, 8, 14), EndDate = new DateOnly(2023, 8, 11),
                GPA = 3.21f, Area = "Jatinangor, Sumedang, West Java, Indonesia"
            }
        };
        foreach (var education in educations)
        {
            context.Educations.Add(education);
        }
        context.SaveChanges();

        var works = new Work[]
        {
            new Work
            {
                UserId = 1, Company = "PT. XYZ", Position = "Software Developer", StartDate = DateOnly.Parse("2023-04-14"),
                Location = "Bekasi", Description = "Developing web applications for clients"
            },
            new Work
            {
                UserId = 1, Company = "PT. ABC", Position = "Mobile Developer", StartDate = DateOnly.Parse("2022-08-14"),
                EndDate = DateOnly.Parse("2023-03-11"),
                Location = "Bekasi", Description = "Developing mobile applications for internal and client use"
            }
        };
        foreach (var work in works)
        {
            context.Works.Add(work);
        }
        context.SaveChanges();

        var projects = new Project[]
        {
            new Project
            {
                UserId = 1, Name = "CVApp", StartDate = new DateOnly(2022, 7, 14), EndDate = new DateOnly(2022, 8, 1),
                Description = "A web application to create a curriculum vitae"
            },
            new Project
            {
                UserId = 1, Name = "CVApp Mobile", StartDate = new DateOnly(2023, 8, 14), EndDate = new DateOnly(2023, 8, 30),
                Description = "A mobile application to create a curriculum vitae"
            }
        };
        foreach (var project in projects)
        {
            context.Projects.Add(project);
        }
        context.SaveChanges();

        var certifications = new Certification[]
        {
            new Certification
            {
                UserId = 1, Name = "Microsoft Certified: Azure Fundamentals", Authority = "Microsoft",
                Date = DateOnly.Parse("2023-08-14"), ExpirationDate = DateOnly.Parse("2025-08-11"),
                Url = "https://www.youracclaim.com/badges/123456"
            }
        };
        foreach (var certification in certifications)
        {
            context.Certifications.Add(certification);
        }
        context.SaveChanges();

        var languages = new Language[]
        {
            new Language
            {
                UserId = 1, Name = "English", Proficiency = "Professional"
            },
            new Language
            {
                UserId = 1, Name = "Indonesian", Proficiency = "Native"
            }
        };
        foreach (var language in languages)
        {
            context.Languages.Add(language);
        }
        context.SaveChanges();

        var skills = new Skill[]
        {
            new Skill
            {
                UserId = 1, Name = "C#"
            },
            new Skill
            {
                UserId = 1, Name = "ASP.NET Core"
            },
            new Skill
            {
                UserId = 1, Name = "JavaScript"
            },
            new Skill
            {
                UserId = 1, Name = "React"
            },
            new Skill
            {
                UserId = 1, Name = "React Native"
            },
            new Skill
            {
                UserId = 1, Name = "SQL Server"
            }
        };
        foreach (var skill in skills)
        {
            context.Skills.Add(skill);
        }
        context.SaveChanges();
    }
}