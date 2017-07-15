﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
    public class McqRepository : BaseRepository,IMcqRepository
    {
        private List<Mcq> _mcqs;

        //public McqRepository()
        //{
        //    _mcqs = new List<Mcq>() { /*Q.1*/ new Mcq() { McqID = 1, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0),YearwisePaperID = null, TopicWiseSrNo = 1, QuestionText1 = "The graph shows how the speed of a car changes with time.", QuestionImageLink = "Uploads\\MCQ\\Images\\Phy-q-1.PNG", QuestionText3 = "Between which two times is the car stationary?", CorrectAnswerID = 1, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 1, McqID = 1, SN = "A", Answer = "U and V",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 2, McqID = 1, SN = "B", Answer = "V and W" ,AnswerType="Text"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 3, McqID = 1, SN = "C", Answer = "W and X",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 4, McqID = 1, SN = "D", Answer = "X and Y",AnswerType="Text" }}},
        //                             /*Q.2*/ new Mcq() { McqID = 2, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 2, QuestionText1 = "A ruler is used to measure the length of an object.", QuestionImageLink = "Uploads\\MCQ\\Images\\Phy-q-2.PNG", QuestionText3 = "What is the length of the object?", CorrectAnswerID = 6, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 5, McqID = 2, SN = "A", Answer = "3.0 cm",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 6, McqID = 2, SN = "B", Answer = "4.0 cm" ,AnswerType="Text"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 7, McqID = 2, SN = "C", Answer = "5.0 cm",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 8, McqID = 2, SN = "D", Answer = "6.5 cm",AnswerType="Text" }}},
        //                             /*Q.3*/ new Mcq() { McqID = 3, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 3, QuestionText1 = "A student is told to measure the density of a liquid and also of a large cube of metal.", QuestionImageLink = null, QuestionText2 = "Which pieces of equipment are sufficient to be able to take the measurements needed?", CorrectAnswerID = 11, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 9, McqID = 3, SN = "A", Answer = "balance, measuring cylinder and ruler",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 10, McqID = 3, SN = "B", Answer = "balance and thermometer" ,AnswerType="Text"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 11, McqID = 3, SN = "C", Answer = "measuring cylinder and ruler",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 12, McqID = 3, SN = "D", Answer = "measuring cylinder, ruler and thermometer",AnswerType="Text" }}},
        //                             /*Q.4*/ new Mcq() { McqID = 4, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 4, QuestionText1 = "The diagrams show four blocks with the same mass.", QuestionImageLink = null, QuestionText2 = "Which block is made from the least dense material?", CorrectAnswerID = 16, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 13, McqID = 4, SN = "A", Answer = "Uploads\\MCQ\\Images\\Phy-q-4-A.PNG",AnswerType="Image" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 14, McqID = 4, SN = "B", Answer = "Uploads\\MCQ\\Images\\Phy-q-4-B.PNG" ,AnswerType="Image"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 15, McqID = 4, SN = "C", Answer = "Uploads\\MCQ\\Images\\Phy-q-4-C.PNG",AnswerType="Image" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 16, McqID = 4, SN = "D", Answer = "Uploads\\MCQ\\Images\\Phy-q-4-D.PNG",AnswerType="Image" }}},
        //                             /*Q.5*/ new Mcq() { McqID = 5, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 5, QuestionText1 = "A child is standing on the platform of a station.", QuestionImageLink = "Uploads\\MCQ\\Images\\Phy-q-5.PNG", QuestionText3 = "A train travelling at 30 m / s takes 3.0 s to pass the child.", QuestionText4="What is the length of the train?",CorrectAnswerID = 17, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 17, McqID = 5, SN = "A", Answer = "10 m",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 18, McqID = 5, SN = "B", Answer = "27 m" ,AnswerType="Text"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 19, McqID = 5, SN = "C", Answer = "30 m",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 20, McqID = 5, SN = "D", Answer = "90 m",AnswerType="Text" }}},
        //                             /*Q.6*/ new Mcq() { McqID = 6, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 6, QuestionText1 = "Which combination of forces produces a resultant force acting towards the right?", QuestionImageLink = null, QuestionText2 = null, CorrectAnswerID = 22, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 21, McqID = 6, SN = "A", Answer = "Uploads\\MCQ\\Images\\Phy-q-6-A.PNG",AnswerType="Image" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 22, McqID = 6, SN = "B", Answer = "Uploads\\MCQ\\Images\\Phy-q-6-B.PNG" ,AnswerType="Image"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 23, McqID = 6, SN = "C", Answer = "Uploads\\MCQ\\Images\\Phy-q-6-C.PNG",AnswerType="Image" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 24, McqID = 6, SN = "D", Answer = "Uploads\\MCQ\\Images\\Phy-q-6-D.PNG",AnswerType="Image" }}},
        //                             /*Q.7*/ new Mcq() { McqID = 7, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 7, QuestionText1 = "A student adds weights to an elastic cord. He measures the length of the cord for each weight.", QuestionImageLink = "Uploads\\MCQ\\Images\\Phy-q-7.PNG", QuestionText2 = "He then plots a graph from the results, as shown.", QuestionText3="Which length has he plotted on the vertical axis?", CorrectAnswerID = 27, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 25, McqID = 7, SN = "A", Answer = "measured length",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 26, McqID = 7, SN = "B", Answer = "original length" ,AnswerType="Text"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 27, McqID = 7, SN = "C", Answer = "(measured length – original length)",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 28, McqID = 7, SN = "D", Answer = "(measured length + original length)",AnswerType="Text" }}},
        //                             /*Q.8*/ new Mcq() { McqID = 8, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 8, QuestionText1 = "The weight of an object is to be found using the balance shown in the diagram.", QuestionImageLink = "Uploads\\MCQ\\Images\\Phy-q-8.PNG", QuestionText3 = "What is the best estimate of the weight of the object?", CorrectAnswerID = 32, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 29, McqID = 8, SN = "A", Answer = "0.27 N",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 30, McqID = 8, SN = "B", Answer = "0.29 N" ,AnswerType="Text"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 31, McqID = 8, SN = "C", Answer = "0.31 N",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 32, McqID = 8, SN = "D", Answer = "0.58 N",AnswerType="Text" }}},
        //                             /*Q.9*/ new Mcq() { McqID = 9, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 9, QuestionText1 = "A uniform rod rests on a pivot at its centre. The rod is not attached to the pivot. Forces are then applied to the rod in four different ways, as shown. The weight of the rod can be ignored.", QuestionImageLink = null, QuestionText2 = "Which diagram shows the rod in equilibrium?", CorrectAnswerID = 33, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 33, McqID = 9, SN = "A", Answer = "Uploads\\MCQ\\Images\\Phy-q-9-A.PNG",AnswerType="Image" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 34, McqID = 9, SN = "B", Answer = "Uploads\\MCQ\\Images\\Phy-q-9-B.PNG" ,AnswerType="Image"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 35, McqID = 9, SN = "C", Answer = "Uploads\\MCQ\\Images\\Phy-q-9-C.PNG",AnswerType="Image" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 36, McqID = 9, SN = "D", Answer = "Uploads\\MCQ\\Images\\Phy-q-9-D.PNG",AnswerType="Image" }}},
        //                             /*Q.10*/ new Mcq() { McqID = 10, TopicwisePaperID = 2, TimeToSolve = new TimeSpan(0,1,0), YearwisePaperID = null, TopicWiseSrNo = 10, QuestionText1 = "A force F moves a load from the bottom of a slope to the top.", QuestionImageLink = "Uploads\\MCQ\\Images\\Phy-q-10.PNG", QuestionText3 = "The work done by the force depends on the size of the force, and on a distance.", QuestionText4="What is this distance?", CorrectAnswerID = 38, HintText = "This is Hint", Marks = 1, SolutionText = "This is solution text", IsVisible = true, CreatedBy = 1, CreatedOn = DateTime.Now, McqAnswers = new List<McqAnswer>() { new McqAnswer() { McqAnswerID = 37, McqID = 10, SN = "A", Answer = "p",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 38, McqID = 10, SN = "B", Answer = "q" ,AnswerType="Text"},
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 39, McqID = 10, SN = "C", Answer = "r",AnswerType="Text" },
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new McqAnswer() { McqAnswerID = 40, McqID = 10, SN = "D", Answer = "p + q",AnswerType="Text" }}},};
        //}


        public IEnumerable<Mcq> GetAll()
        {
            //return _mcqs;
            IEnumerable<Mcq> lstMcq;
            lstMcq = this.DB.ExecuteSprocAccessor<Mcq>("usp_GetAllMcq");
            return lstMcq;
        }

        public Mcq GetById(IdentifiableData id)
        {
            return _mcqs.Where<Mcq>(x => x.McqID == id.LId).SingleOrDefault<Mcq>();
        }

        public void Add(Mcq mcq)
        {
            _mcqs.Add(mcq);
        }

        public void Update(Mcq mcq)
        {
            _mcqs.Where<Mcq>(x => x.McqID == mcq.McqID).ToList().ForEach(x => x = mcq);
        }

        public void Delete(IdentifiableData id)
        {
            _mcqs.RemoveAll(x => x.McqID == id.LId);
        }
    }
}