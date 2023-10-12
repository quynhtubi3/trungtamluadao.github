﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrungTamLuaDao.Context;

#nullable disable

namespace TrungTamLuaDao.Migrations
{
    [DbContext(typeof(TrungTamLuaDaoContext))]
    partial class TrungTamLuaDaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrungTamLuaDao.Data.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MultipleChoiceQuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("RightAnswer")
                        .HasColumnType("bit");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AnswerID");

                    b.HasIndex("MultipleChoiceQuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentID"));

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExamTypeID")
                        .HasColumnType("int");

                    b.Property<double>("MinGrade")
                        .HasColumnType("float");

                    b.Property<int>("WorkTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("ExamTypeID");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CourseEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CourseStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Decentralization", b =>
                {
                    b.Property<int>("DecentralizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DecentralizationID"));

                    b.Property<string>("AuthorityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("DecentralizationID");

                    b.ToTable("Decentralizations");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusTypeID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TutorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StatusTypeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.ExamType", b =>
                {
                    b.Property<int>("ExamTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamTypeID"));

                    b.Property<string>("ExamTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ExamTypeID");

                    b.ToTable("ExamTypes");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Fee", b =>
                {
                    b.Property<int>("FeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeeID"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("FeeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Feedback", b =>
                {
                    b.Property<int>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackID"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("SubmissionID")
                        .HasColumnType("int");

                    b.Property<int>("TutorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("FeedbackID");

                    b.HasIndex("TutorID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Lecture", b =>
                {
                    b.Property<int>("LectureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectureID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("LectureContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LectureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LectureTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LectureTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("LectureID");

                    b.HasIndex("CourseID");

                    b.HasIndex("LectureTypeID");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.LectureType", b =>
                {
                    b.Property<int>("LectureTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectureTypeID"));

                    b.Property<string>("LectureTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("LectureTypeID");

                    b.ToTable("LectureType");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Material", b =>
                {
                    b.Property<int>("MaterialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("MaterialLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaterialTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("MaterialID");

                    b.HasIndex("CourseID");

                    b.HasIndex("MaterialTypeId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.MaterialType", b =>
                {
                    b.Property<int>("MaterialTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialTypeID"));

                    b.Property<string>("MaterialTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("MaterialTypeID");

                    b.ToTable("MaterialTypes");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.MultipleChoiceQuestion", b =>
                {
                    b.Property<int>("MultipleChoiceQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MultipleChoiceQuestionID"));

                    b.Property<int>("AssignmentID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ManyChoices")
                        .HasColumnType("bit");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("MultipleChoiceQuestionID");

                    b.HasIndex("AssignmentID");

                    b.ToTable("MultipleChoiceQuestions");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.PaymentHistory", b =>
                {
                    b.Property<int>("PaymentHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentHistoryID"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentTypeID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentHistoryID");

                    b.HasIndex("PaymentTypeID");

                    b.HasIndex("StudentID");

                    b.ToTable("PaymentHistorys");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentTypeID"));

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("creatAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentTypeID");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.StatusType", b =>
                {
                    b.Property<int>("StatusTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusTypeID"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StatusTypeID");

                    b.ToTable("StatusTypes");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalMoney")
                        .HasColumnType("int");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentID");

                    b.HasIndex("accountID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Submission", b =>
                {
                    b.Property<int>("SubmissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubmissionID"));

                    b.Property<int>("AssignmentID")
                        .HasColumnType("int");

                    b.Property<int>("ExamTimes")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("SubmissionID");

                    b.HasIndex("AssignmentID");

                    b.HasIndex("StudentID");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Tutor", b =>
                {
                    b.Property<int>("TutorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorID"));

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TutorID");

                    b.HasIndex("accountID");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.TutorAssignment", b =>
                {
                    b.Property<int>("TutorAssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorAssignmentID"));

                    b.Property<DateTime>("AssignmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfStudent")
                        .HasColumnType("int");

                    b.Property<int>("TutorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TutorAssignmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TutorID");

                    b.ToTable("TutorAssignments");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.account", b =>
                {
                    b.Property<int>("accountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("accountID"));

                    b.Property<int>("DecentralizationId")
                        .HasColumnType("int");

                    b.Property<string>("ResetPasswordToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetPasswordTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("accountID");

                    b.HasIndex("DecentralizationId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Answer", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.MultipleChoiceQuestion", "MultipleChoiceQuestion")
                        .WithMany("Answers")
                        .HasForeignKey("MultipleChoiceQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MultipleChoiceQuestion");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Assignment", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Course", "Courses")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrungTamLuaDao.Data.ExamType", "ExamType")
                        .WithMany("Assignments")
                        .HasForeignKey("ExamTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("ExamType");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Enrollment", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrungTamLuaDao.Data.StatusType", "StatusType")
                        .WithMany("Enrollments")
                        .HasForeignKey("StatusTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrungTamLuaDao.Data.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("StatusType");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Fee", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Student", "Student")
                        .WithMany("Fees")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Feedback", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Tutor", "Tutor")
                        .WithMany("Feedbacks")
                        .HasForeignKey("TutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Lecture", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Course", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrungTamLuaDao.Data.LectureType", "LectureType")
                        .WithMany("Lectures")
                        .HasForeignKey("LectureTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("LectureType");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Material", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Course", "Course")
                        .WithMany("Materials")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrungTamLuaDao.Data.MaterialType", "MaterialType")
                        .WithMany("Materials")
                        .HasForeignKey("MaterialTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("MaterialType");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.MultipleChoiceQuestion", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Assignment", "Assignment")
                        .WithMany("MultipleChoiceQuestion")
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.PaymentHistory", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.PaymentType", "PaymentType")
                        .WithMany("PaymentHistorys")
                        .HasForeignKey("PaymentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrungTamLuaDao.Data.Student", "Student")
                        .WithMany("PaymentHistory")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentType");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Student", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.account", "account")
                        .WithMany("Students")
                        .HasForeignKey("accountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Submission", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Assignment", "Assignment")
                        .WithMany("Submission")
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrungTamLuaDao.Data.Student", "Student")
                        .WithMany("Submissions")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Tutor", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.account", "account")
                        .WithMany("Tutors")
                        .HasForeignKey("accountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.TutorAssignment", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Course", "Courses")
                        .WithMany("TutorAssignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrungTamLuaDao.Data.Tutor", "Tutor")
                        .WithMany("TutorAssignments")
                        .HasForeignKey("TutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.account", b =>
                {
                    b.HasOne("TrungTamLuaDao.Data.Decentralization", "Decentralization")
                        .WithMany("accounts")
                        .HasForeignKey("DecentralizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Decentralization");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Assignment", b =>
                {
                    b.Navigation("MultipleChoiceQuestion");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Enrollments");

                    b.Navigation("Lectures");

                    b.Navigation("Materials");

                    b.Navigation("TutorAssignments");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Decentralization", b =>
                {
                    b.Navigation("accounts");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.ExamType", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.LectureType", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.MaterialType", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.MultipleChoiceQuestion", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.PaymentType", b =>
                {
                    b.Navigation("PaymentHistorys");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.StatusType", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Student", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Fees");

                    b.Navigation("PaymentHistory");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.Tutor", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("TutorAssignments");
                });

            modelBuilder.Entity("TrungTamLuaDao.Data.account", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Tutors");
                });
#pragma warning restore 612, 618
        }
    }
}
