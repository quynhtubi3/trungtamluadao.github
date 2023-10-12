using Microsoft.EntityFrameworkCore;
using TrungTamLuaDao.Data;

namespace TrungTamLuaDao.Context
{
    public class TrungTamLuaDaoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DUONGDOO\\SQLEXPRESS; Database = TrungTamLuaDao; Trusted_Connection = True; TrustServerCertificate = True;");
        }
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Decentralization> Decentralizations { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<ExamType> ExamTypes { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Submission> Submissions { get; set; }
        public virtual DbSet<TutorAssignment> TutorAssignments { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }
        public virtual DbSet<LectureType> LecturesTypes { get; set;}
        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistorys { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
    }
}
