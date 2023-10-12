using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class FeedbackRepo : IFeedbackRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public FeedbackRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(FeedbackModel feedbackModel)
        {
            var currentSubmission = _context.Submissions.FirstOrDefault(x => x.SubmissionID == feedbackModel.SubmissionID);
            var currentAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentID == currentSubmission.AssignmentID);
            var currentCourse = _context.Courses.FirstOrDefault(x => x.CourseID == currentAssignment.CourseID);
            bool check = _context.TutorAssignments.Any(x => x.TutorID == feedbackModel.TutorID && x.CourseID == currentCourse.CourseID);
            if (check)
            {
                Feedback feedback = new Feedback()
                {
                    SubmissionID = feedbackModel.SubmissionID,
                    TutorID = feedbackModel.TutorID,
                    FeedbackDate = feedbackModel.FeedbackDate,
                    Comments = feedbackModel.Comments,
                    Score = feedbackModel.Score,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType CreateRandomFeedback()
        {
            var lstTutor = _context.Tutors.ToList();
            foreach (var tutor in lstTutor)
            {
                var lstTutorAssignment = _context.TutorAssignments.Where(x => x.TutorID == tutor.TutorID).ToList();
                foreach (var tutorAssignment in lstTutorAssignment)
                {
                    var lstAssignment = _context.Assignments.Where(x => x.CourseID ==  tutorAssignment.CourseID).ToList();
                    foreach (var assignment in lstAssignment)
                    {
                        var lstSubmission = _context.Submissions.Where(x => x.AssignmentID == assignment.AssignmentID).ToList();
                        foreach (var submission in lstSubmission)
                        {
                            Random random = new Random();
                            _context.Feedbacks.Add(new Feedback()
                            {
                                SubmissionID = submission.SubmissionID,
                                TutorID = tutor.TutorID,
                                FeedbackDate = DateTime.Now,
                                Comments = "string",
                                Score = random.Next(0, 11),
                                createAt = DateTime.Now,
                                updateAt = DateTime.Now
                            });
                            _context.SaveChanges();
                        }
                    }
                }
            }
            return ErrorType.Succeed;
        }

        public ErrorType Delete(int id)
        {
            var currentFeedback = _context.Feedbacks.FirstOrDefault(x => x.FeedbackID == id);
            if (currentFeedback != null)
            {
                _context.Feedbacks.Remove(currentFeedback);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<Feedback> GetAll(Pagination pagination)
        {
            var res = PageResult<Feedback>.ToPageResult(pagination, _context.Feedbacks.AsQueryable());
            pagination.TotalCount = _context.Feedbacks.AsQueryable().Count();
            return new PageResult<Feedback>(pagination, res);
        }

        public PageResult<Feedback> GetByDate(Pagination pagination, DateTime date)
        {
            var res = PageResult<Feedback>.ToPageResult(pagination, _context.Feedbacks.Where(x => x.FeedbackDate.Date == date.Date).AsQueryable());
            pagination.TotalCount = _context.Feedbacks.Where(x => x.FeedbackDate.Date == date.Date).AsQueryable().Count();
            return new PageResult<Feedback>(pagination, res);
        }

        public PageResult<Feedback> GetByGrade(Pagination pagination, float grade)
        {
            var res = PageResult<Feedback>.ToPageResult(pagination, _context.Feedbacks.Where(x => x.Score == grade).AsQueryable());
            pagination.TotalCount = _context.Feedbacks.Where(x => x.Score == grade).AsQueryable().Count();
            return new PageResult<Feedback>(pagination, res);
        }

        public Feedback GetById(int id)
        {
            var currentFeedback = _context.Feedbacks.FirstOrDefault(x => x.FeedbackID == id);
            if (currentFeedback != null) return currentFeedback;
            return null;
        }

        public PageResult<Feedback> GetBySubId(Pagination pagination, int id)
        {
            var res = PageResult<Feedback>.ToPageResult(pagination, _context.Feedbacks.Where(x => x.SubmissionID == id).AsQueryable());
            pagination.TotalCount = _context.Feedbacks.Where(x => x.SubmissionID == id).AsQueryable().Count();
            return new PageResult<Feedback>(pagination, res);
        }

        public PageResult<Feedback> GetByTutorId(Pagination pagination, int id)
        {
            var res = PageResult<Feedback>.ToPageResult(pagination, _context.Feedbacks.Where(x => x.TutorID == id).AsQueryable());
            pagination.TotalCount = _context.Feedbacks.Where(x => x.TutorID == id).AsQueryable().Count();
            return new PageResult<Feedback>(pagination, res);
        }

        public ErrorType Update(int id, FeedbackModel feedbackModel)
        {
            var currentFeedback = _context.Feedbacks.FirstOrDefault(x => x.FeedbackID == id);
            if (currentFeedback != null)
            {
                var currentSubmission = _context.Submissions.FirstOrDefault(x => x.SubmissionID == feedbackModel.SubmissionID);
                var currentAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentID == currentSubmission.AssignmentID);
                var currentCourse = _context.Courses.FirstOrDefault(x => x.CourseID == currentAssignment.CourseID);
                bool check = _context.TutorAssignments.Any(x => x.TutorID == feedbackModel.TutorID && x.CourseID == currentCourse.CourseID);
                if (check)
                {
                    currentFeedback.SubmissionID = feedbackModel.SubmissionID;
                    currentFeedback.TutorID = feedbackModel.TutorID;
                    currentFeedback.FeedbackDate = feedbackModel.FeedbackDate;
                    currentFeedback.Comments = feedbackModel.Comments;
                    currentFeedback.Score = feedbackModel.Score;
                    currentFeedback.updateAt = DateTime.Now;
                    _context.Feedbacks.Update(currentFeedback);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }
    }
}
