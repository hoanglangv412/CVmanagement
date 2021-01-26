using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [cvManagement.Models.CustomValidationAttribute.ValidDate(ErrorMessage = "Ngày không được lớn hơn ngày hiện tại.")]
        public DateTime ApplyDate { get; set; }
        public int CvResult { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InterviewDate { get; set; }
        public int InterviewResult { get; set; }
        public int Status { get; set; }
        public string CvLink { get; set; }
        public string Note { get; set; }
        public List<userProfile> ListProfile { get; set; }

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