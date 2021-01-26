using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cvManagement.Models
{
    public class userProfile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public int SourceId { get; set; }
        public DateTime ApplyDate { get; set; }
        public int CvResult { get; set; }
        public DateTime InterviewDate { get; set; }
        public int InterviewResult { get; set; }
        public int Status { get; set; }
        public string CvLink { get; set; }
        public string Note { get; set; }

        public userProfile() { }

        public userProfile(int id, string name, int positionId, int sourceId, DateTime applyDate, int cvResult, DateTime interviewDate, int interviewResult, int status, string cvLink, string note)
        {
            Id = id;
            Name = name;
            PositionId = positionId;
            SourceId = sourceId;
            ApplyDate = applyDate;
            CvResult = cvResult;
            InterviewDate = interviewDate;
            InterviewResult = interviewResult;
            Status = status;
            CvLink = cvLink;
            Note = note;
        }
    }
}