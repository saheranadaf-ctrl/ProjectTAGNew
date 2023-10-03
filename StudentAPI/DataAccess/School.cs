using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.DataAccess;

public partial class School
{
    [Key]
    [Required(ErrorMessage = "Student ID is required.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "Student ID must be 8 characters long.")]
    [RegularExpression("^S\\d{7}$", ErrorMessage = "Student ID must start with 'S' followed by 7 digits.")]
    public string StudentId { get; set; } = null!;

    [Required(ErrorMessage = "Gender is required.")]
    public string? Gender { get; set; }

    [Required(ErrorMessage = "Nationality is required.")]
    public string? NationalIty { get; set; }

    [Required(ErrorMessage = "Place of Birth is required.")]
    public string? PlaceofBirth { get; set; }

    [Required(ErrorMessage = "Stage ID is required.")]
    public string? StageId { get; set; }

    [Required(ErrorMessage = "Grade ID is required.")]
    public string? GradeId { get; set; }

    [Required(ErrorMessage = "Section ID is required.")]
    public string? SectionId { get; set; }

    [Required(ErrorMessage = "Topic is required.")]
    public string? Topic { get; set; }

    [Required(ErrorMessage = "Semester is required.")]
    public string? Semester { get; set; }


    [Required(ErrorMessage = "Relation is required.")]
    public string? Relation { get; set; }

    [Required(ErrorMessage = "Raised Hands is required.")]
    [Range(0, 100, ErrorMessage = "Raised Hands must be between 0 and 100.")]
    public double? Raisedhands { get; set; }

    [Required(ErrorMessage = "Visited Resources is required.")]
    [Range(0, 100, ErrorMessage = "Visited Resources must be between 0 and 100.")]
    public double? VisItedResources { get; set; }

    [Required(ErrorMessage = "Announcements View is required.")]
    [Range(0, 100, ErrorMessage = "Announcements View must be between 0 and 100.")]
    public double? AnnouncementsView { get; set; }

    [Required(ErrorMessage = "Discussion is required.")]
    [Range(0, 100, ErrorMessage = "Discussion must be between 0 and 100.")]
    public double? Discussion { get; set; }


    [Required(ErrorMessage = "Parent Answering Survey is required.")]
    public string? ParentAnsweringSurvey { get; set; }

    [Required(ErrorMessage = "Parent School Satisfaction is required.")]
    public string? ParentschoolSatisfaction { get; set; }


    [Required(ErrorMessage = "Student Absence Days is required.")]
    public string? StudentAbsenceDays { get; set; }


    [Required(ErrorMessage = "Student Marks is required.")]
    [Range(0, 100, ErrorMessage = "Student Marks must be between 0 and 100.")]
    public double? StudentMarks { get; set; }


    [Required(ErrorMessage = "Class is required.")]
    public string? Class { get; set; }
}
