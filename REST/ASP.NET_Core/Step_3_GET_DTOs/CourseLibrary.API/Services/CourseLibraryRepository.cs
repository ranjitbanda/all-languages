﻿using CourseLibrary.API.DataStore;
using CourseLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseLibrary.API.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly IAuthorData _authorData;

        public CourseLibraryRepository(IAuthorData authorData)
        {
            _authorData = authorData ??
                throw new ArgumentNullException(nameof(authorData));
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _authorData.GetAuthors();
        }

        public void RestoreDataStore()
        {
            _authorData.RestoreDataStore();
        }


        public Author GetAuthor(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return _authorData.GetAuthors().FirstOrDefault(a => a.Id == authorId);
        }


        public bool AuthorExists(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return _authorData.GetAuthors().Any(a => a.Id == authorId);
        }

        public Course GetCourse(Guid authorId, Guid courseId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return _authorData.GetAuthors().Where(a => a.Id == authorId).First().Courses.Where(b => b.Id == courseId).FirstOrDefault();
            //return _context.Courses
            //  .Where(c => c.AuthorId == authorId && c.Id == courseId).FirstOrDefault();
        }

        public IEnumerable<Course> GetCourses(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return _authorData.GetAuthors().Where(a => a.Id == authorId).First().Courses;
            //return _context.Courses
            //            .Where(c => c.AuthorId == authorId)
            //            .OrderBy(c => c.Title).ToList();
        }
        ////// public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds)
        //////{
        //////    //if (authorIds == null)
        //////    //{
        //////    //    throw new ArgumentNullException(nameof(authorIds));
        //////    //}

        //////    //return _context.Authors.Where(a => authorIds.Contains(a.Id))
        //////    //    .OrderBy(a => a.FirstName)
        //////    //    .OrderBy(a => a.LastName)
        //////    //    .ToList();
        //////    return _authorData.GetAuthors();

        //////} 
        //public void AddCourse(Guid authorId, Course course)
        //{
        //    if (authorId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(authorId));
        //    }

        //    if (course == null)
        //    {
        //        throw new ArgumentNullException(nameof(course));
        //    }
        //    // always set the AuthorId to the passed-in authorId
        //    course.AuthorId = authorId;
        //    _context.Courses.Add(course); 
        //}         

        //public void DeleteCourse(Course course)
        //{
        //    _context.Courses.Remove(course);
        //}



        //public void UpdateCourse(Course course)
        //{
        //    // no code in this implementation
        //}

        //public void AddAuthor(Author author)
        //{
        //    if (author == null)
        //    {
        //        throw new ArgumentNullException(nameof(author));
        //    }

        //    // the repository fills the id (instead of using identity columns)
        //    author.Id = Guid.NewGuid();

        //    foreach (var course in author.Courses)
        //    {
        //        course.Id = Guid.NewGuid();
        //    }

        //    _context.Authors.Add(author);
        //}


        //public void DeleteAuthor(Author author)
        //{
        //    if (author == null)
        //    {
        //        throw new ArgumentNullException(nameof(author));
        //    }

        //    _context.Authors.Remove(author);
        //}



        //public void UpdateAuthor(Author author)
        //{
        //    // no code in this implementation
        //}

        //public bool Save()
        //{
        //    return (_context.SaveChanges() >= 0);
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //       // dispose resources when needed
        //    }
        //}
    }
}
