﻿// <auto-generated />
using System;
using ArcelikWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArcelikWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ArcelikWebApi.Models.AiApplication", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ConversationRetentionPeriod")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EnableUploadPdfFile")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("ModalTemperature")
                        .HasColumnType("float");

                    b.Property<string>("Pdfs_Urls")
                        .HasColumnType("longtext");

                    b.Property<string>("SelectedModel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SystemPrompt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("UseKnowledgebase")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("WelcomeMessage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("AiApplications");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.ApplicationSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LandingUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SupportedFileTypes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("ApplicationSettings");

                    b.HasData(
                        new
                        {
                            id = 1,
                            LandingUrl = "Somelink will be here",
                            SupportedFileTypes = "Pdf"
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.Choices", b =>
                {
                    b.Property<int>("ChoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ChoiceText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("ChoiceID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Choices");

                    b.HasData(
                        new
                        {
                            ChoiceID = 1,
                            ChoiceText = "Berlin",
                            QuestionID = 1
                        },
                        new
                        {
                            ChoiceID = 2,
                            ChoiceText = "Paris",
                            QuestionID = 1
                        },
                        new
                        {
                            ChoiceID = 3,
                            ChoiceText = "London",
                            QuestionID = 1
                        },
                        new
                        {
                            ChoiceID = 4,
                            ChoiceText = "Madrid",
                            QuestionID = 1
                        },
                        new
                        {
                            ChoiceID = 5,
                            ChoiceText = "2",
                            QuestionID = 2
                        },
                        new
                        {
                            ChoiceID = 6,
                            ChoiceText = "5",
                            QuestionID = 2
                        },
                        new
                        {
                            ChoiceID = 7,
                            ChoiceText = "8",
                            QuestionID = 2
                        },
                        new
                        {
                            ChoiceID = 8,
                            ChoiceText = "11",
                            QuestionID = 2
                        },
                        new
                        {
                            ChoiceID = 9,
                            ChoiceText = "Rome",
                            QuestionID = 3
                        },
                        new
                        {
                            ChoiceID = 10,
                            ChoiceText = "Athens",
                            QuestionID = 3
                        },
                        new
                        {
                            ChoiceID = 11,
                            ChoiceText = "Jerusalem",
                            QuestionID = 3
                        },
                        new
                        {
                            ChoiceID = 12,
                            ChoiceText = "Istanbul",
                            QuestionID = 3
                        },
                        new
                        {
                            ChoiceID = 13,
                            ChoiceText = "2",
                            QuestionID = 4
                        },
                        new
                        {
                            ChoiceID = 14,
                            ChoiceText = "4",
                            QuestionID = 4
                        },
                        new
                        {
                            ChoiceID = 15,
                            ChoiceText = "6",
                            QuestionID = 4
                        },
                        new
                        {
                            ChoiceID = 16,
                            ChoiceText = "8",
                            QuestionID = 4
                        },
                        new
                        {
                            ChoiceID = 17,
                            ChoiceText = "Red",
                            QuestionID = 5
                        },
                        new
                        {
                            ChoiceID = 18,
                            ChoiceText = "Black",
                            QuestionID = 5
                        },
                        new
                        {
                            ChoiceID = 19,
                            ChoiceText = "Blue",
                            QuestionID = 5
                        },
                        new
                        {
                            ChoiceID = 20,
                            ChoiceText = "Yellow",
                            QuestionID = 5
                        },
                        new
                        {
                            ChoiceID = 21,
                            ChoiceText = "CC#",
                            QuestionID = 6
                        },
                        new
                        {
                            ChoiceID = 22,
                            ChoiceText = "Python",
                            QuestionID = 6
                        },
                        new
                        {
                            ChoiceID = 23,
                            ChoiceText = "Javax",
                            QuestionID = 6
                        },
                        new
                        {
                            ChoiceID = 24,
                            ChoiceText = "JavaScript",
                            QuestionID = 6
                        },
                        new
                        {
                            ChoiceID = 25,
                            ChoiceText = "True",
                            QuestionID = 7
                        },
                        new
                        {
                            ChoiceID = 26,
                            ChoiceText = "False",
                            QuestionID = 7
                        },
                        new
                        {
                            ChoiceID = 27,
                            ChoiceText = "True",
                            QuestionID = 8
                        },
                        new
                        {
                            ChoiceID = 28,
                            ChoiceText = "False",
                            QuestionID = 8
                        },
                        new
                        {
                            ChoiceID = 29,
                            ChoiceText = "True",
                            QuestionID = 9
                        },
                        new
                        {
                            ChoiceID = 30,
                            ChoiceText = "False",
                            QuestionID = 9
                        },
                        new
                        {
                            ChoiceID = 31,
                            ChoiceText = "1",
                            QuestionID = 13
                        },
                        new
                        {
                            ChoiceID = 32,
                            ChoiceText = "2",
                            QuestionID = 13
                        },
                        new
                        {
                            ChoiceID = 33,
                            ChoiceText = "4",
                            QuestionID = 13
                        },
                        new
                        {
                            ChoiceID = 34,
                            ChoiceText = "3",
                            QuestionID = 13
                        },
                        new
                        {
                            ChoiceID = 35,
                            ChoiceText = "Red",
                            QuestionID = 14
                        },
                        new
                        {
                            ChoiceID = 36,
                            ChoiceText = "Green",
                            QuestionID = 14
                        },
                        new
                        {
                            ChoiceID = 37,
                            ChoiceText = "Yellow",
                            QuestionID = 14
                        },
                        new
                        {
                            ChoiceID = 38,
                            ChoiceText = "Blue",
                            QuestionID = 14
                        },
                        new
                        {
                            ChoiceID = 39,
                            ChoiceText = "Java",
                            QuestionID = 15
                        },
                        new
                        {
                            ChoiceID = 40,
                            ChoiceText = "C++",
                            QuestionID = 15
                        },
                        new
                        {
                            ChoiceID = 41,
                            ChoiceText = "JavaScript",
                            QuestionID = 15
                        },
                        new
                        {
                            ChoiceID = 42,
                            ChoiceText = "Python",
                            QuestionID = 15
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.CorrectChoices", b =>
                {
                    b.Property<int>("CorrectChoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChoiceID")
                        .HasColumnType("int");

                    b.Property<int>("PartialScore")
                        .HasColumnType("int");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("CorrectChoiceID");

                    b.HasIndex("ChoiceID")
                        .IsUnique();

                    b.HasIndex("QuestionID");

                    b.ToTable("CorrectChoices");

                    b.HasData(
                        new
                        {
                            CorrectChoiceID = 1,
                            ChoiceID = 2,
                            PartialScore = 10,
                            QuestionID = 1
                        },
                        new
                        {
                            CorrectChoiceID = 2,
                            ChoiceID = 5,
                            PartialScore = 10,
                            QuestionID = 2
                        },
                        new
                        {
                            CorrectChoiceID = 3,
                            ChoiceID = 10,
                            PartialScore = 10,
                            QuestionID = 3
                        },
                        new
                        {
                            CorrectChoiceID = 4,
                            ChoiceID = 13,
                            PartialScore = 2,
                            QuestionID = 4
                        },
                        new
                        {
                            CorrectChoiceID = 5,
                            ChoiceID = 14,
                            PartialScore = 2,
                            QuestionID = 4
                        },
                        new
                        {
                            CorrectChoiceID = 6,
                            ChoiceID = 15,
                            PartialScore = 2,
                            QuestionID = 4
                        },
                        new
                        {
                            CorrectChoiceID = 7,
                            ChoiceID = 16,
                            PartialScore = 2,
                            QuestionID = 4
                        },
                        new
                        {
                            CorrectChoiceID = 8,
                            ChoiceID = 17,
                            PartialScore = 2,
                            QuestionID = 5
                        },
                        new
                        {
                            CorrectChoiceID = 9,
                            ChoiceID = 19,
                            PartialScore = 2,
                            QuestionID = 5
                        },
                        new
                        {
                            CorrectChoiceID = 10,
                            ChoiceID = 20,
                            PartialScore = 2,
                            QuestionID = 5
                        },
                        new
                        {
                            CorrectChoiceID = 11,
                            ChoiceID = 22,
                            PartialScore = 2,
                            QuestionID = 6
                        },
                        new
                        {
                            CorrectChoiceID = 12,
                            ChoiceID = 24,
                            PartialScore = 2,
                            QuestionID = 6
                        },
                        new
                        {
                            CorrectChoiceID = 13,
                            ChoiceID = 26,
                            PartialScore = 5,
                            QuestionID = 7
                        },
                        new
                        {
                            CorrectChoiceID = 14,
                            ChoiceID = 27,
                            PartialScore = 5,
                            QuestionID = 8
                        },
                        new
                        {
                            CorrectChoiceID = 15,
                            ChoiceID = 29,
                            PartialScore = 5,
                            QuestionID = 9
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.CorrectSorting", b =>
                {
                    b.Property<int>("CorrectSortingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("SortingOrder")
                        .HasColumnType("int");

                    b.Property<int>("SortingScore")
                        .HasColumnType("int");

                    b.HasKey("CorrectSortingID");

                    b.HasIndex("QuestionID")
                        .IsUnique();

                    b.ToTable("CorrectSorting");

                    b.HasData(
                        new
                        {
                            CorrectSortingID = 1,
                            QuestionID = 13,
                            SortingOrder = 31323433,
                            SortingScore = 10
                        },
                        new
                        {
                            CorrectSortingID = 2,
                            QuestionID = 14,
                            SortingOrder = 38363735,
                            SortingScore = 10
                        },
                        new
                        {
                            CorrectSortingID = 3,
                            QuestionID = 15,
                            SortingOrder = 40394241,
                            SortingScore = 10
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.CorrectText", b =>
                {
                    b.Property<int>("CorrectTextID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CorrectTextAnswer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("TextScore")
                        .HasColumnType("int");

                    b.HasKey("CorrectTextID");

                    b.HasIndex("QuestionID")
                        .IsUnique();

                    b.ToTable("CorrectText");

                    b.HasData(
                        new
                        {
                            CorrectTextID = 1,
                            CorrectTextAnswer = "Madrid",
                            QuestionID = 10,
                            TextScore = 5
                        },
                        new
                        {
                            CorrectTextID = 2,
                            CorrectTextAnswer = "8",
                            QuestionID = 11,
                            TextScore = 5
                        },
                        new
                        {
                            CorrectTextID = 3,
                            CorrectTextAnswer = "programming",
                            QuestionID = 12,
                            TextScore = 5
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.Questions", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("QuestionID");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionID = 1,
                            QuestionText = "What is the capital of France?",
                            QuestionType = "MultipleChoice"
                        },
                        new
                        {
                            QuestionID = 2,
                            QuestionText = "Which of the following are prime numbers?",
                            QuestionType = "MultipleChoice"
                        },
                        new
                        {
                            QuestionID = 3,
                            QuestionText = "Which city is known as the 'Eternal City'?",
                            QuestionType = "MultipleChoice"
                        },
                        new
                        {
                            QuestionID = 4,
                            QuestionText = "Select the even numbers:",
                            QuestionType = "MultipleChoiceAndAnswers"
                        },
                        new
                        {
                            QuestionID = 5,
                            QuestionText = "Which colors are in a rainbow?",
                            QuestionType = "MultipleChoiceAndAnswers"
                        },
                        new
                        {
                            QuestionID = 6,
                            QuestionText = "Choose the correct programming languages:",
                            QuestionType = "MultipleChoiceAndAnswers"
                        },
                        new
                        {
                            QuestionID = 7,
                            QuestionText = "Is the Earth flat?",
                            QuestionType = "TrueFalse"
                        },
                        new
                        {
                            QuestionID = 8,
                            QuestionText = "Do cats meow?",
                            QuestionType = "TrueFalse"
                        },
                        new
                        {
                            QuestionID = 9,
                            QuestionText = "Is water wet?",
                            QuestionType = "TrueFalse"
                        },
                        new
                        {
                            QuestionID = 10,
                            QuestionText = "The capital of Spain is ________.",
                            QuestionType = "FillInTheBlank"
                        },
                        new
                        {
                            QuestionID = 11,
                            QuestionText = "The sum of 5 and 3 is ________.",
                            QuestionType = "FillInTheBlank"
                        },
                        new
                        {
                            QuestionID = 12,
                            QuestionText = "C# is a ________ language.",
                            QuestionType = "FillInTheBlank"
                        },
                        new
                        {
                            QuestionID = 13,
                            QuestionText = "Sort the following numbers in ascending order:",
                            QuestionType = "Sorting"
                        },
                        new
                        {
                            QuestionID = 14,
                            QuestionText = "Arrange these colors alphabetically: Blue, Red, Green, Yellow.",
                            QuestionType = "Sorting"
                        },
                        new
                        {
                            QuestionID = 15,
                            QuestionText = "Order these programming languages by release date: C++, Java, Python, JavaScript.",
                            QuestionType = "Sorting"
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Users", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsPassed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("QuizPoint")
                        .HasColumnType("int");

                    b.Property<int>("WatchedTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("WatchedVideoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BlobStorageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.Choices", b =>
                {
                    b.HasOne("ArcelikWebApi.Models.Quiz.Questions", "Questions")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.CorrectChoices", b =>
                {
                    b.HasOne("ArcelikWebApi.Models.Quiz.Choices", "Choices")
                        .WithOne("CorrectChoices")
                        .HasForeignKey("ArcelikWebApi.Models.Quiz.CorrectChoices", "ChoiceID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ArcelikWebApi.Models.Quiz.Questions", "Questions")
                        .WithMany("CorrectChoices")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Choices");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.CorrectSorting", b =>
                {
                    b.HasOne("ArcelikWebApi.Models.Quiz.Questions", "Questions")
                        .WithOne("CorrectSorting")
                        .HasForeignKey("ArcelikWebApi.Models.Quiz.CorrectSorting", "QuestionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.CorrectText", b =>
                {
                    b.HasOne("ArcelikWebApi.Models.Quiz.Questions", "Questions")
                        .WithOne("CorrectText")
                        .HasForeignKey("ArcelikWebApi.Models.Quiz.CorrectText", "QuestionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.Choices", b =>
                {
                    b.Navigation("CorrectChoices")
                        .IsRequired();
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Quiz.Questions", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("CorrectChoices");

                    b.Navigation("CorrectSorting")
                        .IsRequired();

                    b.Navigation("CorrectText")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
